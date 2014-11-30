using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xaml;

namespace KatsuYuzu.TileLogoMaker.Models
{
    public class Material
    {
        public Material(string path)
        {
            Path = path;

            if (File.Exists(path))
            {
                try
                {
                    Image = Load(path);
                }
                catch (Exception ex)
                {
                    _errorMessages.Add(ex.Message);
                }
            }
            else
            {
                _errorMessages.Add("ファイルが見つかりませんでした。");
            }
        }

        public string Path { get; private set; }
        public UIElement Image { get; private set; }

        public bool HasError { get { return ErrorMessages.Any(); } }
        public IReadOnlyCollection<string> ErrorMessages { get { return _errorMessages; } }
        private readonly List<string> _errorMessages = new List<string>();

        private UIElement Load(string path)
        {
            using (var reader = new XamlXmlReader(path))
            using (var writer = new XamlObjectWriter(reader.SchemaContext))
            {
                while (reader.Read())
                {
                    writer.WriteNode(reader);
                }
                return (UIElement)writer.Result;
            }
        }
    }
}
