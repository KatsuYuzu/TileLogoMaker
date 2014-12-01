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
        private readonly Settings _settings;

        public ApplicationContext(ProductInfo productInfo, Settings settings)
        {
            _settings = settings;
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

            foreach (var logo in _settings.Logos)
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
