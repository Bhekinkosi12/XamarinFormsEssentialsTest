using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Sensors
{
    public class CompassTest:INotifyPropertyChanged
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

        public CompassTest()
        {
            Compass.ReadingChanged += Compass_ReadingChanged;
            
        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            var data = e.Reading;

            var hmn = data.HeadingMagneticNorth;

            this.Message = $@"Compass:
    HeadingMagneticNorth: {hmn}";
        }

        public void ToggleCompass()
        {
            try
            {
                if (Compass.IsMonitoring)
                    Compass.Stop();
                else
                {
                    Compass.Start(speed,applyLowPassFilter:true);
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
