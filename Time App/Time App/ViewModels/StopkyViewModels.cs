using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Time_App.ViewModels
{
    public partial class StopkyViewModels : INotifyPropertyChanged
    {
        Stopwatch stopwatch;

        private string WhileNotStart = "START";
        private string DefaultTime = "00:00:00.000";

        public event PropertyChangedEventHandler PropertyChanged;

        public string start
        {
            get => WhileNotStart;
            set
            {
                WhileNotStart = value;
                PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(nameof(start)));
            }
        }

        public string lblStopwatch 
        {
            get => DefaultTime; 
            set
            {
                DefaultTime = value;
                PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(nameof(lblStopwatch)));
            }
        }

        public Command btnStart_Clicked => new Command(() =>
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();

                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    lblStopwatch = stopwatch.Elapsed.ToString();

                    if (!stopwatch.IsRunning)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            }
        });

        public Command btnStop_Clicked => new Command(() =>
        {
            start = "RESUME";
            stopwatch.Stop();
        });

        public Command btnReset_Clicked => new Command(() =>
        {
            lblStopwatch = "00:00:00.000";
            start = "START";
            stopwatch.Reset();
        });

        public StopkyViewModels()
        {
            stopwatch = new Stopwatch();
            lblStopwatch = "00:00:00.000";
        }
    }
}