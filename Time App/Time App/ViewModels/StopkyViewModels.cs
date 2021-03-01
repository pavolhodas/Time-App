using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_App.ViewModels;
using Time_App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Time_App.ViewModels
{
    public  class StopkyViewModels : INotifyPropertyChanged
    {
        Stopwatch stopwatch;

        private readonly List<DateTime> tapTimes;
        private string WhileNotStart = "START";
        private string DefaultTime = "00:00:00.000";
        private string DefaultColor = "#909090";
        private string SecondaryColor = "#9ac16e";
        private string firstLabel = "0.0";
        private string secondLabel = "0.0";
        private string thirdLabel = "0.0";

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
        public string lblLap1
        {
            get => DefaultTime;
            set
            {
                DefaultTime = value;
                PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(nameof(lblLap1)));
            }
        }

        public string txtLap1
        {
            get => DefaultTime;
            set
            {
                DefaultTime = value;
                PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(nameof(txtLap1)));
            }
        }

        public string lblLap2
        {
            get => DefaultTime;
            set
            {
                DefaultTime = value;
                PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(nameof(lblLap2)));
            }
        }

        public string txtLap2
        {
            get => DefaultTime;
            set
            {
                DefaultTime = value;
                PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(nameof(txtLap2)));
            }
        }

        public string lblLap3
        {
            get => DefaultTime;
            set
            {
                DefaultTime = value;
                PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(nameof(lblLap3)));
            }
        }
        public string txtLap3
        {
            get => DefaultTime;
            set
            {
                DefaultTime = value;
                PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(nameof(txtLap3)));
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
            lblLap3 = lblStopwatch;
            lblLap1 = lblStopwatch;
            lblLap2 = lblStopwatch;

            firstLabel = "0.0";
            secondLabel = "0.0";
            thirdLabel = "0.0";

            txtLap1 = DefaultColor;

            //tapTimes.Add(DateTime.Now);
            //tapTimes.Clear();
        });
        public Command btnLap_Clicked => new Command(() =>
        {
            tapTimes.Add(DateTime.Now);
            //if (tapTimes.Count == 1)
            //{
            //    lblLap1 = this.lblStopwatch;
            //    txtLap1 = SecondaryColor;
            //}
            //else if (tapTimes.Count == 2 || tapTimes.Count == 5 || tapTimes.Count == 8 || tapTimes.Count == 11) //label: 2
            //{
            //    lblLap2 = this.lblStopwatch;
            //    txtLap2 = SecondaryColor;
            //    txtLap1 = DefaultColor;
            //}

            //else if(tapTimes.Count == 3 || tapTimes.Count == 6 || tapTimes.Count == 9 || tapTimes.Count == 12) //label: 3
            //{
            //    lblLap3 = this.lblStopwatch;
            //    txtLap3 = SecondaryColor;
            //    txtLap2 = DefaultColor;
            //}
            //else if (tapTimes.Count == 4 || tapTimes.Count == 7 || tapTimes.Count == 10)    //label: 1
            //{
            //lblLap1 = this.lblStopwatch;
            //txtLap1 = SecondaryColor;
            //txtLap3 = DefaultColor;
            //}
            //else
            //{
            //lblLap3 = lblStopwatch;
            //txtLap3 = SecondaryColor;
            //}

            if (firstLabel == "0.0")
            {
                firstLabel = lblStopwatch;
                txtLap1 = SecondaryColor;
            }
            else if (secondLabel == "0.0")
            {
                secondLabel = firstLabel;
                firstLabel = lblStopwatch;
                txtLap1 = SecondaryColor;
            }
            else
            {
                thirdLabel = secondLabel;
                secondLabel = firstLabel;
                firstLabel = lblStopwatch;
                txtLap1 = SecondaryColor;
            }


            lblLap1 = firstLabel;
            if (secondLabel != "0.0")
            {
                lblLap2 = secondLabel;
            }

            if (thirdLabel != "0.0")
            {
                lblLap3 = thirdLabel;
            }

        });

        public StopkyViewModels()
        {
            tapTimes = new List<DateTime>();
            stopwatch = new Stopwatch();
            lblStopwatch = "00:00:00.000";
        }
    }
}