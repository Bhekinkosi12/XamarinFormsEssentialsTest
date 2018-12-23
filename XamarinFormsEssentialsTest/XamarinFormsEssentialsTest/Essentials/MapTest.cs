using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinFormsSensorTest.Essentials
{
    public class MapTest
    {
        public async Task OpenMapWithGeocode(double lat,double lon)
        {
            var location = new Location(lat,lon);

            var options = new MapLaunchOptions {Name = "Microsoft Building 25"};

            await Map.OpenAsync(location, options);
        }

        public async Task OpenMapWithPlacemark(Placemark placemark)
        {
            //こちらでもいいし、
            //var options=new MapLaunchOptions
            //{
            //    Name = "Hello"
            //};

            //await Map.OpenAsync(placemark, options);

            //こちらでもよい。
            await placemark.OpenMapsAsync();
        }

        public async Task NavigateTo(Placemark placemark)
        {
            var options = new MapLaunchOptions
            {
                Name = "Hello",
                NavigationMode = NavigationMode.Walking
            };

            await Map.OpenAsync(placemark, options);
        }
    }
}
