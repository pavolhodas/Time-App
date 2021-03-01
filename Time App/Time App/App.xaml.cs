using System;
using System.Threading.Tasks;
using Time_App.Services.Navigation;
using Time_App.ViewModels;
using Time_App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Time_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ShellApp();
            //MainPage = new LoginPage();
            //MainPage = new NavigationPage(new MainPage());
        }
        //Task InitNavigation()
        //{
        //    //var navService = PageModelLocator.Resolve<INavigationService>();
        //    //return navService.NavigateToAsync<LoginViewModels>();
        //}

        //protected override async void OnStart()
        //{
        //    await InitNavigation();
        //}

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
