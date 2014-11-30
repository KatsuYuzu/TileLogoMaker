
namespace KatsuYuzu.TileLogoMaker.Models
{
    /// <summary>
    /// ロゴ情報を表します。
    /// </summary>
    class LogoInfo
    {
        /// <summary>
        /// 名前を取得または設定します。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// サブディレクトリ名を取得または設定します。
        /// </summary>
        public string SubDirectoryName { get; set; }

        /// <summary>
        /// サポートされるタイルのスケールを取得または設定します。
        /// </summary>
        public TileScales SupportedTileScales { get; set; }

        /// <summary>
        /// 幅を取得または設定します。
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 高さを取得または設定します。
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 幅、高さに対するロゴのスケールを取得または設定します。
        /// </summary>
        public double LogoScale { get; set; }

        /// <summary>
        /// y 軸の方向の移動距離を取得または設定します。スケール 100 のときの値を設定してください。
        /// </summary>
        public double OffsetY { get; set; }
    }
}
