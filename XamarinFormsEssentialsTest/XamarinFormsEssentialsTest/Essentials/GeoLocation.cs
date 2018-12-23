using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Essentials
{
    public class GeoLocationTest:INotifyPropertyChanged
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

        

        public GeoLocationTest()
        {
            //最短で10秒おきなのかな？
            //5秒に設定しても、更新は10秒だった。
            Xamarin.Forms.Device.StartTimer(new TimeSpan(0,0,10), () =>
            {
                UpdateMessage();

                return true;
            });
        }

        private async void UpdateMessage()
        {
            var lastKnown = await GetLastKnownLocation();
            var locationGps = await GetLocationFromGPS();

            //長岡の経緯度
            var lat = 37.4462652;
            var lon = 138.8512772;

            var distanceTo = await GetDistanceTo(lat, lon);

            this.Message = $@"Geolocation:
    LastKnow: 
        Lat: {lastKnown?.Latitude}
        Lon: {lastKnown?.Longitude}
        Accuracy: {lastKnown?.Accuracy}
        Altitude: {lastKnown?.Altitude}
        Course: {lastKnown?.Course}
        Speed: {lastKnown?.Speed}//m/s
        TimeStamp:{lastKnown?.Timestamp}
    GPS:
        Lat: {locationGps?.Latitude}
        Lon: {locationGps?.Longitude}
        Accuracy: {locationGps?.Accuracy}
        Altitude: {locationGps?.Altitude}
        Course: {locationGps?.Course}
        Speed: {locationGps?.Speed}
        TimeStamp: {locationGps?.Timestamp}
        DistanceTo: {distanceTo}";
        }

        public async Task<Location> GetLastKnownLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                return location;
            }
            catch(FeatureNotSupportedException fnsEx)
            { }
            catch (Exception e)
            {
               
            }

            return null;
        }


        public async Task<Location> GetLocationFromGPS()
        {
            try
            {
                var request=new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                return location;
            }
            catch (FeatureNotSupportedException fnsEx)
            {

            }
            catch (Exception ex)
            {

            }

            return null;
        }


        public async Task<double> GetDistanceTo(double latitude, double longitude)
        {
            var locationGps = await GetLocationFromGPS();

            var distance = locationGps.CalculateDistance(latitude, longitude, DistanceUnits.Kilometers);

            return distance;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
