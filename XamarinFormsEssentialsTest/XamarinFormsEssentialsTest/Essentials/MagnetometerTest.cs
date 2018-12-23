using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Essentials
{
    public class MagnetometerTest:INotifyPropertyChanged
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

        public MagnetometerTest()
        {
            Magnetometer.ReadingChanged += Magnetometer_ReadingChanged;
        }

        private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            var data = e.Reading;

            this.Message = $@"Magnetometer:
    MagneticField X: {data.MagneticField.X}
    MagneticField Y: {data.MagneticField.Y}
    MagneticField Z: {data.MagneticField.Z}";
        }

        public void ToggleMagnetometer()
        {
            try
            {
                if (Magnetometer.IsMonitoring)
                {
                    Magnetometer.Stop();
                }
                else
                {
                    Magnetometer.Start(speed);
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
