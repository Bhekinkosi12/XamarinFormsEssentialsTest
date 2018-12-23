using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Annotations;

namespace XamarinFormsSensorTest.Essentials
{
    public static class FlashLightTest
    {
        public static async void TurnOn()
        {
            await Flashlight.TurnOnAsync();
        }

        public static async void TurnOff()
        {
            await Flashlight.TurnOffAsync();
        }

    }
}
