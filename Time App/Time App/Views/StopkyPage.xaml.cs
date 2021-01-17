using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Time_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopkyPage : ContentPage
    {
        Stopwatch stopwatch;
        public StopkyPage()
        {
            InitializeComponent();
            BindingContext = new StopkyViewModels();
            stopwatch = new Stopwatch();

            lblStopwatch.Text = "00:00:00.000";
        }
        private void btnStart_Clicked(object sender, EventArgs e)
        {
            if(!stopwatch.IsRunning)
            {
                stopwatch.Start();

                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    lblStopwatch.Text = stopwatch.Elapsed.ToString();

                    if(!stopwatch.IsRunning)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                    );
            }
        }

        private void btnStop_Clicked(object sender, EventArgs e)
        {
            btnStart.Text = "Resume";
            stopwatch.Stop();
        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            lblStopwatch.Text = "00:00:00.000";
            btnStart.Text = "Start";
            stopwatch.Reset();
        }
    }
}