using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace XamarinFormsSensorTest.Sensors
{

    public class DetectShakeTest : INotifyPropertyChanged
    {
        SensorSpeed speed = SensorSpeed.Game;


        private System.Drawing.Color _backgroundColor;
        public System.Drawing.Color BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                OnPropertyChanged();
            }
        }

        public DetectShakeTest()
        {
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            var rand = new Random(DateTime.Now.Millisecond);

            var r = rand.Next(255);
            var g = rand.Next(255);
            var b = rand.Next(255);

            BackgroundColor = System.Drawing.Color.FromArgb(50, r, g, b);

        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                {
                    //Accelerometer.Stop();
                }
                else
                {
                    Accelerometer.Start(speed);
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

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
