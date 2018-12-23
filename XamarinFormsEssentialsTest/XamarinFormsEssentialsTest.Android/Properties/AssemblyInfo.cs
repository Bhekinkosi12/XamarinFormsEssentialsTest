using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Android.App;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("XamarinFormsSensorTest.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("XamarinFormsSensorTest.Android")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// Add some common permissions, these can be removed if not needed
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]


//センサー関連の設定はこちら
[assembly:UsesPermission(Android.Manifest.Permission.BatteryStats)]//バッテリー

[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]//ネットワーク

[assembly: UsesPermission(Android.Manifest.Permission.Flashlight)]//懐中電灯
[assembly: UsesPermission(Android.Manifest.Permission.Camera)]//懐中電灯
[assembly: UsesFeature("android.hardware.camera", Required = false)]//懐中電灯。懐中電灯がない端末からはGoogle Playに表示されなくなるのを防ぐため。
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)]//懐中電灯。懐中電灯がない端末からはGoogle Playに表示されなくなるのを防ぐため。

[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]//GPS
[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]//GPS
[assembly: UsesFeature("android.hardware.location", Required = false)]//GPS。懐中電灯と同じくGoogle Play対策かな
[assembly: UsesFeature("android.hardware.location.gps", Required = false)]//GPS。懐中電灯と同じくGoogle Play対策かな
[assembly: UsesFeature("android.hardware.location.network", Required = false)]//GPS。懐中電灯と同じくGoogle Play対策かな

[assembly: UsesPermission(Android.Manifest.Permission.Vibrate)]//バイブレータ