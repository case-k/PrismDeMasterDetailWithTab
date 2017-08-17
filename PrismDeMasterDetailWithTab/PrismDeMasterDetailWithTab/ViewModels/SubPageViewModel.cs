using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismDeMasterDetailWithTab.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismDeMasterDetailWithTab.ViewModels
{
    public class SubPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _detail;
        public string Detail
        {
            get { return _detail; }
            set { SetProperty(ref _detail, value); }
        }


        public SubPageViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("selectedmenuitem"))
            {
                var SelectedMenuItem = (TMenuItem)parameters["selectedmenuitem"];
                Title = SelectedMenuItem.Title;
                Detail = SelectedMenuItem.Detail;
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }
    }
}
