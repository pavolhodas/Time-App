using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Time_App.ViewModels
{

    class MainViewModels : INotifyPropertyChanged
    {
        DateTime dateTime;

        public event PropertyChangedEventHandler PropertyChanged;


        private string _labelText = "Presný čas";
        public string LabelText
        {
            get => _labelText;
            set
            {
                _labelText = value;
                PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(nameof(LabelText)));
                }
        }
        public Command ButtonClickedCommand => new Command(() =>
        {
            LabelText = "Sklovensko";
        });

        public MainViewModels()
        {
            DateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                DateTime = DateTime.Now;
                return true;
            });
        }

        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }
            }
            get
            {
                return dateTime;
            }
        }

    }
}
