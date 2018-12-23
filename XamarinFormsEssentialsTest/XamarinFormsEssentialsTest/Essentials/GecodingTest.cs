using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Essentials
{
    public class GeocodingTest : INotifyPropertyChanged
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


        public async Task<Location> GetLocationsFromAddress(string address)
        {
            try
            {
                //var address = "Nagaoka Niigata Japan";
                var locations = await Geocoding.GetLocationsAsync(address);

                var location = locations?.FirstOrDefault();

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

        /// <summary>
        /// オフラインでもいけるみたい？
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<Placemark> GetPlacemarkFromGeocode(double latitude, double longitude)
        {
            try
            {
                var placemarks = await Geocoding.GetPlacemarksAsync(latitude, longitude);

                var placemark = placemarks?.FirstOrDefault();

                return placemark;
            }
            catch (FeatureNotSupportedException fnsEx)
            {

            }
            catch (Exception e)
            {


            }

            return null;
        }

        public async void UpdateMessage()
        {
            try
            {
                var lat = 37.4462652;
                var lon = 138.8512772;
                var placemark = await GetPlacemarkFromGeocode(lat, lon);

                var address = "長岡市";
                var location = await GetLocationsFromAddress(address);


                this.Message = $@"Geocoding:
     Lat:{lat},Lon{lon} => 
        AdminArea: {placemark?.AdminArea}
        CountryCode: {placemark?.CountryCode}
        CountryName: {placemark?.CountryName}
        FeatureName: {placemark?.FeatureName}
        Locality: {placemark?.Locality}
        PostalCode: {placemark?.PostalCode}
        SubAdminArea: {placemark?.SubAdminArea}
        SubLocality: {placemark?.SubLocality}
        SubThoroughfare: {placemark?.SubThoroughfare}
        Thoroughfare: {placemark?.Thoroughfare}
        
     Address:{address} => 
        Lat:{location?.Latitude}
        Lon: {location?.Longitude}
        Alt: {location?.Altitude}
        Speed: {location?.Speed}
        Cource: {location?.Course}
        Accuracy: {location?.Accuracy}
";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                this.Message = $@"Geocoding:
    {e}";
            }

        }


        public event  PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
