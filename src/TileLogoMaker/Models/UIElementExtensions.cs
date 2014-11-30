using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KatsuYuzu.TileLogoMaker.Models
{
    // ReSharper disable once InconsistentNaming
    static class UIElementExtensions
    {
        /// <summary>
        /// 保存します。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="rootDirectoryPath"></param>
        /// <param name="logo"></param>
        public static void Save(this UIElement source, string rootDirectoryPath, LogoInfo logo)
        {
            var directoryPath = Path.Combine(rootDirectoryPath, logo.SubDirectoryName);
            CreateDirectory(directoryPath);

            if (logo.SupportedTileScales.HasFlag(TileScales.Percent100))
            {
                source.Save(directoryPath, logo.Name, logo.Width, logo.Height, 1, logo.LogoScale, logo.OffsetY);
            }

            if (logo.SupportedTileScales.HasFlag(TileScales.Percent80))
            {
                source.Save(directoryPath, logo.Name, logo.Width * 0.8, logo.Height * 0.8, 0.8, logo.LogoScale, logo.OffsetY);
            }

            if (logo.SupportedTileScales.HasFlag(TileScales.Percent140))
            {
                source.Save(directoryPath, logo.Name, logo.Width * 1.4, logo.Height * 1.4, 1.4, logo.LogoScale, logo.OffsetY);
            }

            if (logo.SupportedTileScales.HasFlag(TileScales.Percent180))
            {
                source.Save(directoryPath, logo.Name, logo.Width * 1.8, logo.Height * 1.8, 1.8, logo.LogoScale, logo.OffsetY);
            }
        }

        /// <summary>
        /// 保存します。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="directoryPath"></param>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="tileScale"></param>
        /// <param name="logoScale"></param>
        /// <param name="offsetY"></param>
        private static void Save(this UIElement source, string directoryPath, string name, double width, double height, double tileScale, double logoScale, double offsetY)
        {
            var visualBrush = new VisualBrush(source) { Stretch = Stretch.Uniform };

            var visual = DrawLogo(width, height, tileScale, logoScale, offsetY, visualBrush);

            var renderTargetBitmap = new RenderTargetBitmap(
                (int)width, (int)height,
                96.0, 96.0,
                PixelFormats.Pbgra32);

            renderTargetBitmap.Render(visual);

            var path = CreateFilePath(directoryPath, name, tileScale);

            SaveToFile(renderTargetBitmap, path);
        }

        /// <summary>
        /// ファイルに保存します。
        /// </summary>
        /// <param name="renderTargetBitmap"></param>
        /// <param name="path"></param>
        private static void SaveToFile(RenderTargetBitmap renderTargetBitmap, string path)
        {
            var pngBitmapEncoder = new PngBitmapEncoder();
            pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                pngBitmapEncoder.Save(fs);
            }
        }

        /// <summary>
        /// ファイルパスを作成します。
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="name"></param>
        /// <param name="tileScale"></param>
        /// <returns></returns>
        private static string CreateFilePath(string directoryPath, string name, double tileScale)
        {
            return Path.Combine(
                directoryPath,
                string.Format("{0}.scale-{1}.png", name, (int)(tileScale * 100)));
        }

        /// <summary>
        /// ディレクトリを作成します。
        /// </summary>
        /// <param name="path"></param>
        private static void CreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return;
            }

            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// ロゴを描画します。
        /// </summary>
        /// <param name="visualBrush"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="tileScale"></param>
        /// <param name="logoScale"></param>
        /// <param name="offsetY"></param>
        /// <returns></returns>
        private static DrawingVisual DrawLogo(
            double width,
            double height,
            double tileScale,
            double logoScale,
            double offsetY,
            VisualBrush visualBrush)
        {
            var drawingVisual = new DrawingVisual();

            using (var drawingContext = drawingVisual.RenderOpen())
            {
                // 一辺
                var side = (width < height) ? width : height;
                var scaledSide = side * logoScale;

                // 移動
                drawingContext.PushTransform(
                    new TranslateTransform(
                        width / 2 - scaledSide / 2,
                        height / 2 - scaledSide / 2 + offsetY * tileScale));

                // 描画
                drawingContext.DrawRectangle(
                    visualBrush,
                    null,
                    new Rect(new Size(scaledSide, scaledSide)));
            }

            return drawingVisual;
        }
    }
}
