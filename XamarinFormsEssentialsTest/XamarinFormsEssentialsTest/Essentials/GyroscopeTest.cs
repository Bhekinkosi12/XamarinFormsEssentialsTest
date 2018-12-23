using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Essentials
{
    public class GyroscopeTest : INotifyPropertyChanged
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

        public GyroscopeTest()
        {
            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
        }

        private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            var data = e.Reading;

            this.Message = $@"Gyroscope:
    AngularVelocity X: {data.AngularVelocity.X}
    AngularVelocity Y: {data.AngularVelocity.Y}
    AngularVelocity Z: {data.AngularVelocity.Z}";
        }

        public void ToggleGyroscope()
        {
            try
            {
                if (Gyroscope.IsMonitoring)
                    Gyroscope.Stop();
                else
                {
                    Gyroscope.Start(speed);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
            }
            catch (Exception ex)
            {

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
