using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace KatsuYuzu.TileLogoMaker.Models
{
    public class ApplicationContext : INotifyPropertyChanged
    {
        public ApplicationContext(ProductInfo productInfo)
        {
            ProductInfo = productInfo;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProductInfo ProductInfo { get; private set; }

        public Material Material
        {
            get { return _material; }
            private set
            {
                if (value == _material) return;
                _material = value;
                OnPropertyChanged();
                // ReSharper disable once ExplicitCallerInfoArgument
                OnPropertyChanged("CanSave");
            }
        }
        private Material _material;

        public bool CanSave { get { return Material != null && !Material.HasError; } }

        public string RootDirectory
        {
            get
            {
                return Material == null
                    ? string.Empty
                    : Path.ChangeExtension(Material.Path, null);
            }
        }

        public void BrowseFile()
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "サポートされているすべての形式 (*.xaml;)|*.xaml;"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Material = new Material(dialog.FileName);
            }
        }

        public void Save()
        {
            if (!CanSave)
            {
                throw new InvalidOperationException();
            }

            // TODO: 設定ファイル化（設定次第で他プラットフォームのアイコンに対応）
            var logos = new[]
            {
                new LogoInfo
                {
                    SubDirectoryName = "Windows 8.1", 
                    Name = "Square70x70Logo", 
                    Width = 70, 
                    Height = 70,
                    OffsetY = 0,
                    LogoScale = 0.7,
                    SupportedTileScales = TileScales.All
                },
                new LogoInfo
                {
                    SubDirectoryName = "Windows 8.1", 
                    Name = "Logo", 
                    Width = 150, 
                    Height = 150,
                    OffsetY = 0,
                    LogoScale = 0.7,
                    SupportedTileScales = TileScales.All
                },
                new LogoInfo
                {
                    SubDirectoryName = "Windows 8.1", 
                    Name = "Wide310x150Logo", 
                    Width = 310, 
                    Height = 150,
                    OffsetY = 0,
                    LogoScale = 0.7,
                    SupportedTileScales = TileScales.All
                },
                new LogoInfo
                {
                    SubDirectoryName = "Windows 8.1", 
                    Name = "Square150x150Logo", 
                    Width = 150, 
                    Height = 150,
                    OffsetY = 0,
                    LogoScale = 0.7,
                    SupportedTileScales = TileScales.All
                },
                new LogoInfo
                {
                    SubDirectoryName = "Windows 8.1", 
                    Name = "Square310x310Logo", 
                    Width = 310, 
                    Height = 310,
                    OffsetY = 0,
                    LogoScale = 0.7,
                    SupportedTileScales = TileScales.All
                },
                new LogoInfo
                {
                    SubDirectoryName = "Windows 8.1", 
                    Name = "SmallLogo", 
                    Width = 30, 
                    Height = 30,
                    OffsetY = 0,
                    LogoScale = 0.7,
                    SupportedTileScales = TileScales.All
                },
                new LogoInfo
                {
                    SubDirectoryName = "Windows 8.1", 
                    Name = "StoreLogo", 
                    Width = 50, 
                    Height = 50,
                    OffsetY = 0,
                    LogoScale = 0.7,
                    SupportedTileScales = TileScales.GreaterThan100
                },
                new LogoInfo
                {
                    SubDirectoryName = "Windows 8.1", 
                    Name = "LockScreen", 
                    Width = 24, 
                    Height = 24,
                    OffsetY = 0,
                    LogoScale = 0.7,
                    SupportedTileScales = TileScales.GreaterThan100
                },
                new LogoInfo
                {
                    SubDirectoryName = "Windows 8.1", 
                    Name = "SplashScreen", 
                    Width = 620, 
                    Height = 300,
                    OffsetY = 0,
                    LogoScale = 0.7,
                    SupportedTileScales = TileScales.GreaterThan100
                },
            };

            foreach (var logo in logos)
            {
                Material.Image.Save(RootDirectory, logo);
            }

            using (var process = Process.Start(RootDirectory)) { }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
