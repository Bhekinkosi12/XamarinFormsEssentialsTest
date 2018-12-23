using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Sensors
{
    public class DisplayInfoTest : INotifyPropertyChanged
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

        public DisplayInfoTest()
        {
            DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            UpdateMessage();
        }

        public void UpdateMessage()
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            var height = displayInfo.Height;
            var width = displayInfo.Width;
            var density = displayInfo.Density;
            var orientation = displayInfo.Orientation;
            var rotation = displayInfo.Rotation;


            this.Message = $@"DisplayInfo:
    Height; {height}
    Width: {width}
    Density: {density}
    Orientation: {orientation}
    Rotation: {rotation}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
