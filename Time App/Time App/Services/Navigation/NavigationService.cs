using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Time_App.ViewModels.Base;
using Xamarin.Forms;

namespace Time_App.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        Task INavigationService.GoBackAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavigateToAsync<TPageModelBase>(object navigationData, bool setRoot)
        {
            var page = PageModelLocator.CreatePageFor(typeof(TPageModelBase));

            if(setRoot)
            {
                App.Current.MainPage = new NavigationPage(page);
            }else
            {
                if(App.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PushAsync(page);
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }

            if(page.BindingContext is PageModelBase pmBase)
            {
                await pmBase.InitializeAsync(navigationData);
            }
        }
    }
}
