using System.Reflection;

namespace KatsuYuzu.TileLogoMaker.Models
{
    /// <summary>
    /// 製品の情報を表します。
    /// </summary>
    public sealed class ProductInfo
    {
        private readonly AssemblyInfo _assemblyInfo;

        public ProductInfo(Assembly assembly)
        {
            _assemblyInfo = new AssemblyInfo(assembly);
        }

        /// <summary>
        /// バージョン情報を取得します。
        /// </summary>
        public string Version
        {
            get
            {
                return _version
                    ?? (_version = string.Format("{0}", _assemblyInfo.Version.ToString(3)));
            }
        }
        private string _version;

        /// <summary>
        /// 製品名情報を取得します。
        /// </summary>
        public string Product { get { return _assemblyInfo.Product; } }

        /// <summary>
        /// 著作権情報を取得します。
        /// </summary>
        public string Copyright { get { return _assemblyInfo.Copyright; } }
    }
}
