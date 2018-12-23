using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Sensors
{
    public class BarometerTest:INotifyPropertyChanged
    {
        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged("Message");
                }
            }
        }


        private SensorSpeed speed = SensorSpeed.UI;

        public BarometerTest()
        {
            Barometer.ReadingChanged += Barometer_ReadingChanged;

        }

        private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            var data = e.Reading;
            var pressure = data.PressureInHectopascals;
            
            this.Message=$@"Barometer:
    Pressure: {pressure}";
        }

        public void ToggleBarometer()
        {
            try
            {
                if (Barometer.IsMonitoring)
                    Barometer.Stop();
                else
                {
                    Barometer.Start(speed);
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                this.Message = $@"Barometer:
その機能はありません";
            }
            catch (Exception ex)
            {
                this.Message = $@"Barometer:
何かエラーです";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
