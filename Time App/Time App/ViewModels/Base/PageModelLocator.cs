using System;
using System.Collections.Generic;
using System.Text;
using Time_App.Services.Navigation;
using TinyIoC;
using Xamarin.Forms;

namespace Time_App.ViewModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewLookup;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _viewLookup = new Dictionary<Type, Type>();

            //Register pages and page models
            Register<LoginViewModels, LoginPage>();
            //Register<MainViewModels, MainPage>();
            Register<AlarmViewModels, AlarmPage>();
            //Register<StopkyViewModels, StopkyPage>();
            //Register<TimerViewModels, TimerPage>();


            //Register services (services are registered as Singletons default)
            _container.Register<INavigationService, NavigationService>();
        }

        public static T Resolve<T>() where T : class 
        {
            return _container.Resolve<T>();
        }

        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = _viewLookup[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = _container.Resolve(pageModelType);
            page.BindingContext = pageModel;
            return page;
        }

        static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            _viewLookup.Add(typeof(TPageModel), typeof(TPage));
            _container.Register<TPageModel>();
        }
    }
}
