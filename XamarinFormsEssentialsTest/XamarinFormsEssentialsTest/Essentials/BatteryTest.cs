using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Sensors
{
    public class BatteryTest:INotifyPropertyChanged
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

        public BatteryTest()
        {
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }

        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
 UpdateMessage();
            
        }


        public void UpdateMessage()
        {
            var level = Battery.ChargeLevel;
            var state = Battery.State;
            var source = Battery.PowerSource;


            var stateString = "";
            switch (state)
            {
                case BatteryState.Charging:
                    // Currently charging
                    stateString = "充電中";
                    break;
                case BatteryState.Full:
                    // Battery is full
                    stateString = "満タン";
                    break;
                case BatteryState.Discharging:
                case BatteryState.NotCharging:
                    // Currently discharging battery or not being charged
                    stateString = "放電中";
                    break;
                case BatteryState.NotPresent:
                // Battery doesn't exist in device (desktop computer)
                case BatteryState.Unknown:
                    // Unable to detect battery state
                    stateString = "わかりません";
                    break;
            }


            var sourceString = "";
            switch (source)
            {
                case BatteryPowerSource.Battery:
                    // Being powered by the battery
                    sourceString = "バッテリー使ってる";
                    break;
                case BatteryPowerSource.AC:
                    // Being powered by A/C unit
                    sourceString = "ACアダプタにつながってる";
                    break;
                case BatteryPowerSource.Usb:
                    // Being powered by USB cable
                    sourceString = "USBにつながってる";
                    break;
                case BatteryPowerSource.Wireless:
                    // Powered via wireless charging
                    sourceString = "ワイヤレス給電";
                    break;
                case BatteryPowerSource.Unknown:
                    // Unable to detect power source
                    sourceString = "わかりません";
                    break;
            }

            this.Message = $@"Battery: 
    Level: {level}
    State: {stateString}
    Source: {sourceString}";
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
