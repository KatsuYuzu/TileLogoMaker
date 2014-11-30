using System;
using System.Reflection;

namespace KatsuYuzu.TileLogoMaker.Models
{
    /// <summary>
    /// アセンブリの情報を表します。
    /// </summary>
    public sealed class AssemblyInfo
    {
        private readonly Assembly _assembly;

        public AssemblyInfo(Assembly assembly)
        {
            _assembly = assembly;
        }

        /// <summary>
        /// メジャー番号、マイナー番号、ビルド番号、リビジョン番号を取得します。
        /// </summary>
        public Version Version
        {
            get
            {
                return _version
                    ?? (_version = _assembly.GetName().Version);
            }
        }
        private Version _version;

        /// <summary>
        /// タイトル情報を取得します。
        /// </summary>
        public string Title
        {
            get
            {
                return _title
                    ?? (_title = _assembly.GetAttributeValue<AssemblyTitleAttribute>(a => a.Title));
            }
        }
        private string _title;

        /// <summary>
        /// 説明情報を取得します。
        /// </summary>
        public string Description
        {
            get
            {
                return _description
                    ?? (_description = _assembly.GetAttributeValue<AssemblyDescriptionAttribute>(a => a.Description));
            }
        }
        private string _description;

        /// <summary>
        /// 会社名情報を取得します。
        /// </summary>
        public string Company
        {
            get
            {
                return _company
                    ?? (_company = _assembly.GetAttributeValue<AssemblyCompanyAttribute>(a => a.Company));
            }
        }
        private string _company;

        /// <summary>
        /// 製品名情報を取得します。
        /// </summary>
        public string Product
        {
            get
            {
                return _product
                    ?? (_product = _assembly.GetAttributeValue<AssemblyProductAttribute>(a => a.Product));
            }
        }
        private string _product;

        /// <summary>
        /// 著作権情報を取得します。
        /// </summary>
        public string Copyright
        {
            get
            {
                return _copyright
                    ?? (_copyright = _assembly.GetAttributeValue<AssemblyCopyrightAttribute>(a => a.Copyright));
            }
        }
        private string _copyright;

    }
}
