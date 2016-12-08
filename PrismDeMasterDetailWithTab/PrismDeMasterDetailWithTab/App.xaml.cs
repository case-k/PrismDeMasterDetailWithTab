using Prism.Unity;
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

            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();

            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<MDRootPage>();
            //Container.RegisterTypeForNavigation<MasterPage>();  // 無くていいっぽい
            Container.RegisterTypeForNavigation<DetailPage>();
            Container.RegisterTypeForNavigation<SubPage>();
        }
    }
}
