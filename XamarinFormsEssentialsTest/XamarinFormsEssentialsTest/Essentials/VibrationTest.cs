using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinFormsSensorTest.Essentials
{
    public static class VibrationTest
    {
        public static void VibrateDefault()
        {
            try
            {
                Vibration.Vibrate();
            }
            catch(FeatureNotSupportedException fnsEx)
            { }
            catch(Exception ex)
            { }
        }

        public static void Vibrate(TimeSpan duration)
        {
            try
            {
                Vibration.Vibrate(duration);
            }
            catch (FeatureNotSupportedException fnsEx)
            { }
            catch (Exception ex)
            { }
        }
    }
}
