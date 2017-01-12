using Prism.Mvvm;
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

            if (Device.Idiom == TargetIdiom.Phone)
                NavigationService.NavigateAsync("MainPage/MDRootPage/NavigationPage/DetailPage_Phone");
            else
                NavigationService.NavigateAsync("MainPage/MDRootPage/NavigationPage/DetailPage");

            // よくよく考えてみたらDetailPageは自動でMDRootにバインドされるんだから、難しいことする必要なかった
            // デバイス毎のDetail切替は普通に呼び分けるだけでOK
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();

            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<MDRootPage>();
            //Container.RegisterTypeForNavigation<MasterPage>();  // 無くていいっぽい
            Container.RegisterTypeForNavigation<DetailPage>();
            Container.RegisterTypeForNavigation<DetailPage_Phone>();
            Container.RegisterTypeForNavigation<SubPage>();

            // M/DのDのみを差し替えてみる
            //Container.RegisterTypeForNavigationOnIdiom<DetailPage, MDRootPageViewModel>("DetailPage", phoneView: typeof(DetailPage_Phone), tabletView: typeof(DetailPage));

            Container.RegisterTypeForNavigation<SecondPage>();
            Container.RegisterTypeForNavigation<ThirdPage>();
        }
    }
}
