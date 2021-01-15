using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Time_App.ViewModels
{

    class MainViewModels : INotifyPropertyChanged
    {
        DateTime dateTime;

        public event PropertyChangedEventHandler PropertyChanged;


        private string _labelText = "Hello";
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
            LabelText = "Miro Žbirka";
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
