using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Sensors
{
    public class AccelerometerTest : INotifyPropertyChanged
    {
        private SensorSpeed speed = SensorSpeed.UI;

        private float _x;
        public float X
        {
            get { return _x; }
            set
            {
                if (this._x != value)
                {
                    this._x = value;
                    OnPropertyChanged("X");
                }
            }
        }

        private float _y;
        public float Y
        {
            get { return _y; }
            set
            {
                if (this._y != value)
                {
                    this._y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        private float _z;
        public float Z
        {
            get { return _z; }
            set
            {
                if (this._z != value)
                {
                    this._z = value;
                    OnPropertyChanged("Z");
                }
            }
        }

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                if (_message != value)
                {
                    this._message = value;
                    OnPropertyChanged("Message");
                }
            }
        }


        public AccelerometerTest()
        {
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            //Console.WriteLine($"Reading: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}");
            this.X = data.Acceleration.X;
            this.Y = data.Acceleration.Y;
            this.Z = data.Acceleration.Z;

            this.Message =
                $@"Accelerometer: 
    X: {this.X}
    Y: {this.Y}
    Z: {this.Z}";
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                this.Message = @"Accelerometer:
    その機能はありません";
            }
            catch (Exception ex)
            {
                this.Message = @"Accelerometer:
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
