using System.Collections.Generic;

namespace KatsuYuzu.TileLogoMaker.Models
{
    public class Settings
    {
        public IReadOnlyCollection<LogoInfo> Logos { get { return _logos; } }

        // TODO: 設定ファイル化（設定次第で他プラットフォームのアイコンに対応）
        private readonly LogoInfo[] _logos =
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
                OffsetY = -10,
                LogoScale = 0.45,
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
                OffsetY = -10,
                LogoScale = 0.2,
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
    }
}
