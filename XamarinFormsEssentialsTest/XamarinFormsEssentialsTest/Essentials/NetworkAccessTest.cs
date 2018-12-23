using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Sensors
{
    public class NetworkAccessTest:INotifyPropertyChanged
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

        public NetworkAccessTest()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            UpdateMessage();
        }

        public void UpdateMessage()
        {
            var access = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;

            var accessString = "";
            switch (access)
            {
                case NetworkAccess.ConstrainedInternet:
                    accessString = "制限付きインターネットアクセス";
                    break;
                case NetworkAccess.Internet:
                    accessString = "ローカルとインターネットのアクセス";
                    break;
                case NetworkAccess.Local:
                    accessString = "ローカル ネットワークのみ";
                    break;
                case NetworkAccess.None:
                    accessString = "使用できる接続がありません";
                    break;
                case NetworkAccess.Unknown:
                default:
                    accessString = "わかりません";
                    break;
            }

            this.Message = $@"Network:
    Access: {accessString}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
