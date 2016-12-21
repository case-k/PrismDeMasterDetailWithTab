using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismDeMasterDetailWithTab.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismDeMasterDetailWithTab.ViewModels
{
    public class MDRootPageViewModel : BindableBase
    {
        private string _now;
        public string NOW
        {
            get { return _now; }
            set { SetProperty(ref _now, value); }
        }
        public List<TMenuItem> MenuItems { get; }
        public TMenuItem SelectedMenuItem { get; set; }
        public ICommand PochiCommand { get; }
        public ICommand TestCommand { get; }

        private INavigationService _navigationService;


        public MDRootPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            MenuItems = new List<TMenuItem>();
            for (int i = 0; i < 100; i++)
            {
                MenuItems.Add(new TMenuItem() { Title = $"title-{i}", Detail = $"detail-{i}" });
            }

            SelectedMenuItem = null;
            PochiCommand = new DelegateCommand(Pochi);
            TestCommand = new DelegateCommand(Test);

            // バインドの確認用
            //Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            //{
            //    NOW = DateTime.Now.ToString();
            //    return true;
            //});
        }


        async private void Pochi()
        {
            if (SelectedMenuItem == null)
                return;

            //NOW = SelectedMenuItem.Title;  // ←これが画面に反映されない ←された

            var parameters = new NavigationParameters();
            parameters["selectedmenuitem"] = SelectedMenuItem;

            await _navigationService.NavigateAsync("NavigationPage/DetailPage/SubPage", parameters);
        }

        private void Test()
        {
            NOW = "バインドされてるっぽい";
        }
    }
}
