using Prism.Unity;
using PrismDeMasterDetailWithTab.ViewModels;
using PrismDeMasterDetailWithTab.Views;
using Xamarin.Forms;

namespace PrismDeMasterDetailWithTab
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainPage/MDRootPage/NavigationPage/DetailPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();

            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<MDRootPage>();
            //Container.RegisterTypeForNavigation<MasterPage>();  // 無くていいっぽい
            //Container.RegisterTypeForNavigation<DetailPage>();
            Container.RegisterTypeForNavigation<SubPage>();

            // M/DのDのみを差し替えてみる
            Container.RegisterTypeForNavigationOnIdiom<DetailPage, MDRootPageViewModel>("DetailPage", phoneView: typeof(DetailPage_Phone));
        }
    }
}
