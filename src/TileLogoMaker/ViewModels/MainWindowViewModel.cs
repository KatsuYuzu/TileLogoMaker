using Codeplex.Reactive;
using KatsuYuzu.TileLogoMaker.Models;
using System;
using System.Reactive.Linq;
using System.Reflection;

namespace KatsuYuzu.TileLogoMaker.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var product = new ProductInfo(assembly);

            Title = new ReactiveProperty<string>(product.Product);

            ClickCommand = new ReactiveCommand();

            var clear = ClickCommand
                .Delay(TimeSpan.FromSeconds(2))
                .Select(_ => false);

            Status = ClickCommand
                .Select(_ => true)
                .Merge(clear)
                .Select(x => x ? "ボタンが押されました" : product.Version)
                .ToReactiveProperty(product.Version);
        }

        public ReactiveProperty<string> Title { get; private set; }
        public ReactiveProperty<string> Status { get; private set; }

        public ReactiveCommand ClickCommand { get; private set; }
    }
}
