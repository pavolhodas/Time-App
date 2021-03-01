using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Timers;
using Time_App.ViewModels.Base;
using Xamarin.Forms;

namespace Time_App.ViewModels
{
    public class TimerViewModels : INotifyPropertyChanged
    {
        Stopwatch stopWatch = new Stopwatch();
        private Timer time = new Timer();
        private bool timerRunning;
        private string _stopWatchHours;
        public string StopWatchHours
        {
            get { return _stopWatchHours; }
            set
            {
                _stopWatchHours = value;
                OnPropertyChanged("StopvatchHours");
            }
        }

        private string _stopWatchMinutes;
        public string StopWatchMinutes
        {
            get { return _stopWatchMinutes; }
            set
            {
                _stopWatchMinutes = value;
                OnPropertyChanged("StopvatchMinutes");
            }
        }

        private string _stopWatchSeconds;
        public string StopWatchSeconds
        {
            get { return _stopWatchSeconds; }
            set
            {
                _stopWatchSeconds = value;
                OnPropertyChanged("StopvatchSeconds");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public TimerViewModels()
        {
            stopWatch.Start();
            StopWatchHours = stopWatch.Elapsed.Hours.ToString();
            StopWatchMinutes = stopWatch.Elapsed.Minutes.ToString();
            StopWatchSeconds = stopWatch.Elapsed.Seconds.ToString();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                StopWatchHours = stopWatch.Elapsed.Hours.ToString();
                StopWatchMinutes = stopWatch.Elapsed.Minutes.ToString();
                StopWatchSeconds = stopWatch.Elapsed.Seconds.ToString();

                return true;
            });
        }
    }
}
