using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Time_App.Services.Navigation;
using Time_App.ViewModels.Base;
using Xamarin.Forms;

namespace Time_App.ViewModels
{
    public class LoginViewModels : PageModelBase
    {
        private ICommand _signInCommand;

        public ICommand SignInComand
        {
            get=> _signInCommand;
            set => SetProperty(ref _signInCommand, value);
        }

        private INavigationService _navigationService;
        public LoginViewModels(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SignInComand = new Command(OnSignInAction);
        }

        private void OnSignInAction(object obj)
        {
            _navigationService.NavigateToAsync<MainViewModels>();
        }
    }
}
