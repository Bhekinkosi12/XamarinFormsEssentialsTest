using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using XamarinFormsSensorTest.Essentials;
using XamarinFormsSensorTest.Sensors;

namespace XamarinFormsSensorTest
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();


            //加速度センサーの起動
            var acl = new AccelerometerTest();
            acl.ToggleAccelerometer();
            this.label1.BindingContext = acl;

            //アプリ情報
            var appInfo = new AppInfoTest();
            this.label2.BindingContext = appInfo;
            appInfo.UpdateMessage();

            //気圧
            var bm = new BarometerTest();
            bm.ToggleBarometer();
            this.label3.BindingContext = bm;

            //バッテリー情報
            var ba = new BatteryTest();
            this.label4.BindingContext = ba;
            ba.UpdateMessage();

            //コンパス情報
            var compass = new CompassTest();
            compass.ToggleCompass();
            this.label5.BindingContext = compass;

            //ネットワーク情報
            var network = new NetworkAccessTest();
            this.label6.BindingContext = network;
            network.UpdateMessage();

            //ディスプレイ情報
            var displayInfo = new DisplayInfoTest();
            this.label7.BindingContext = displayInfo;
            displayInfo.UpdateMessage();

            //デバイス情報
            var deviceInfo = new DeviceInfoTest();
            this.label8.BindingContext = deviceInfo;
            deviceInfo.UpdateMessage();

            //地理情報
            //あれ、経緯度→地名はオフラインでもいける？
            var geocoding=new GeocodingTest();
            this.label9.BindingContext = geocoding;
            geocoding.UpdateMessage();

            //GPS情報
            var geoloc=new GeoLocationTest();
            this.label10.BindingContext = geoloc;
            
            //ジャイロ
            var gyro=new GyroscopeTest();
            gyro.ToggleGyroscope();
            this.label11.BindingContext = gyro;

            //磁力計
            var mag=new MagnetometerTest();
            mag.ToggleMagnetometer();
            this.label12.BindingContext = mag;

            //向きセンサー
            var ori=new OrientationSensorTest();
            ori.ToggleOrientationSensor();
            this.label13.BindingContext = ori;
        }

        private void Button1_OnClicked(object sender, EventArgs e)
        {
            var sendEmail = new SendEmailTest();

            var recipients = new List<string>
            {
                "hogehoge1@hoge.com",
                "hogehoge2@hoge.com"
            };
            sendEmail.SendEmail("これはテストタイトル", "テストボディ", recipients);


        }

        private bool flashLightState;
        private void Button2_OnClicked(object sender, EventArgs e)
        {
            if (flashLightState)
            {
                FlashLightTest.TurnOff();
                flashLightState = false;
            }
            else
            {
                FlashLightTest.TurnOn();
                flashLightState = true;
            }
        }

        private void Button3_OnClicked(object sender, EventArgs e)
        {
            AppInfo.ShowSettingsUI();
        }

        private async void Button4_OnClicked(object sender, EventArgs e)
        {
            var map=new MapTest();
            //await map.NavigateTo(47.645160, -122.1306032);
            

            //CountryName, AdminArea, Thoroughfare, Localityが必要
            var placemark=new Placemark
            {
                CountryName="日本",
                AdminArea    = "新潟",
                Thoroughfare = "原信",
                Locality = "長岡"
            };

            await map.OpenMapWithPlacemark(placemark);
        }

        private async void Button5_OnClicked(object sender, EventArgs e)
        {
            var map = new MapTest();

            //CountryName, AdminArea, Thoroughfare, Localityが必要
            var placemark = new Placemark
            {
                CountryName = "日本",
                AdminArea = "新潟",
                Thoroughfare = "原信",
                Locality = "長岡"
            };
            
            await map.NavigateTo(placemark);
        }

        private void Button6_OnClicked(object sender, EventArgs e)
        {
            VibrationTest.VibrateDefault();
        }

        private void Button7_OnClicked(object sender, EventArgs e)
        {
           VibrationTest.Vibrate(TimeSpan.FromSeconds(2));
        }
    }
}
