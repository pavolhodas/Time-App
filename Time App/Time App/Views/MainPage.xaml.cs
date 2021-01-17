using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Time_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModels();
            var grid = new Grid();
        }

        void Button_Clicked(object sended, System.EventArgs e)
        {
            Navigation.PushAsync(new StopkyPage());
        }

    }
}
