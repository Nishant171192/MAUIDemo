using Android.App;
using Android.Content.PM;
//using com.kpmgus.linkworkforcemobile;
using Android.OS;
using com.kpmgus.linkworkforcemobile.Shared.Helpers;

namespace com.kpmgus.linkworkforcemobile;
    [Activity(Label = "MAUI",
    Name = "com.kpmgus.linkworkforcemobile.MainActivity",
    Theme = "@style/Maui.SplashTheme",
    Exported = true,
    MainLauncher = true,
    LaunchMode = LaunchMode.SingleTask,
    ScreenOrientation = ScreenOrientation.Portrait,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
public class MainActivity : MauiAppCompatActivity
{
    private App _application;

    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        App.ParentWindow = this;
    }
}

