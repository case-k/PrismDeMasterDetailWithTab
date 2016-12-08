using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismDeMasterDetailWithTab.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PrismDeMasterDetailWithTab.ViewModels
{
    public class MDRootPageViewModel : BindableBase
    {
        public List<TMenuItem> MenuItems { get; }
        public TMenuItem SelectedMenuItem { get; set; }
        public ICommand PochiCommand { get; }

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
        }


        async private void Pochi()
        {
            if (SelectedMenuItem == null)
                return;

            var parameters = new NavigationParameters();
            parameters["selectedmenuitem"] = SelectedMenuItem;

            await _navigationService.NavigateAsync("NavigationPage/DetailPage/SubPage", parameters);
        }
    }
}
