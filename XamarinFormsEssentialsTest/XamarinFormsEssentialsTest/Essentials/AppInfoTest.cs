using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Sensors
{
    public class AppInfoTest:INotifyPropertyChanged
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

        public void UpdateMessage()
        {
            var appName = AppInfo.Name;
            var buildString = AppInfo.BuildString;
            var packageName = AppInfo.PackageName;
            var version = AppInfo.Version;
            var versionString = AppInfo.VersionString;

            this.Message = $@"AppInfo:
    Name: {appName}
    BuildString: {buildString}
    PackageName: {packageName}
    Version: {version}
    VersionString: {versionString}";
        }

        public static void ShowSettingsUI()
        {
            AppInfo.ShowSettingsUI();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
