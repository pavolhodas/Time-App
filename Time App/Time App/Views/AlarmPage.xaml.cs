using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Time_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmPage : ContentPage
    {
        public AlarmPage()
        {
            InitializeComponent();
            BindingContext = new AlarmViewModels();
        }
    }
}