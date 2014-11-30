using Codeplex.Reactive;
using Codeplex.Reactive.Extensions;
using KatsuYuzu.TileLogoMaker.Models;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;

namespace KatsuYuzu.TileLogoMaker.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly ApplicationContext _appContext;

        public MainWindowViewModel(ApplicationContext appContext)
        {
            _appContext = appContext;

            Title =
                _appContext.ProductInfo.Product
                + " - "
                + _appContext.ProductInfo.Version + "（アルファ）";

            BrowseFileCommand = new ReactiveCommand();
            BrowseFileCommand.Subscribe(_ => _appContext.BrowseFile());

            SaveCommand = _appContext
                .ObserveProperty(x => x.CanSave)
                .ToReactiveCommand();
            SaveCommand.Subscribe(_ => _appContext.Save());

            Image = _appContext
                .ObserveProperty(x => x.Material)
                .Where(x => x != null)
                .Select(x => x.Image)
                .ToReactiveProperty();

            ErrorMessage = _appContext
                .ObserveProperty(x => x.Material)
                .Where(x => x != null)
                .Select(x => x.ErrorMessages.FirstOrDefault())
                .ToReactiveProperty();

            SelectedFile = _appContext
                .ObserveProperty(x => x.Material)
                .Where(x => x != null)
                .Select(x => x.Path)
                .ToReactiveProperty();

            Status = SelectedFile
                .Where(x => x != null)
                .Select(x => @"""" + SelectedFile.Value + @""" が開かれました")
                .Merge(SaveCommand.Select(_ => "ロゴが保存されました"))
                .ToReactiveProperty("[素材を開く] をクリックしてください");
        }

        public string Title { get; private set; }
        public ReactiveProperty<string> Status { get; private set; }

        public ReactiveProperty<UIElement> Image { get; private set; }
        public ReactiveProperty<string> ErrorMessage { get; private set; }

        public ReactiveProperty<string> SelectedFile { get; private set; }

        public ReactiveCommand BrowseFileCommand { get; private set; }

        public ReactiveCommand SaveCommand { get; private set; }
    }
}
