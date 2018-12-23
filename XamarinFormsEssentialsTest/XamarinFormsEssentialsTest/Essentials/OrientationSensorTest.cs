using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Essentials
{
    public class OrientationSensorTest:INotifyPropertyChanged
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

        public OrientationSensorTest()
        {
            OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
        }

        //ここをよく読むこと。
        //https://docs.microsoft.com/ja-jp/xamarin/essentials/orientation-sensor?context=xamarin/xamarin-forms
        private void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            var data = e.Reading;

            this.Message = $@"OrientationSensor:
    Orientation:
        X: {data.Orientation.X}
        Y: {data.Orientation.Y}
        Z: {data.Orientation.Z}
        W: {data.Orientation.W}
        IsIdentity: {data.Orientation.IsIdentity}";
        }

        public void ToggleOrientationSensor()
        {
            try
            {
                if(OrientationSensor.IsMonitoring)
                    OrientationSensor.Stop();
                else
                {
                    OrientationSensor.Start(speed);
                }
            }
            catch(FeatureNotSupportedException fnsEx)
            { }
            catch(Exception ex)
            { }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
