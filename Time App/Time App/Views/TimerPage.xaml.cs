using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Time_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Time_App
{
    [DesignTimeVisible(false)]
    public partial class TimerPage : ContentPage
    {
        public TimerPage()
        {
            InitializeComponent();

            BindingContext = new TimerViewModels();
        }

        
    }
}