using KatsuYuzu.TileLogoMaker.Models;
using KatsuYuzu.TileLogoMaker.ViewModels;
using KatsuYuzu.TileLogoMaker.Views;
using System.Reflection;
using System.Windows;

namespace KatsuYuzu.TileLogoMaker
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        public static readonly ApplicationContext Context;

        static App()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var productInfo = new ProductInfo(assembly);
            Context = new ApplicationContext(productInfo, new Settings());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var vm = new MainWindowViewModel(Context);
            MainWindow = new MainWindow { DataContext = vm };
            MainWindow.Show();
        }
    }
}
