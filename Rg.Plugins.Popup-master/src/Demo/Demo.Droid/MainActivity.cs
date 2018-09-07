using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Debug = System.Diagnostics.Debug;

namespace Demo.Droid
{
    [Activity(Label = "Demo", Icon = "@drawable/icon", /*Theme = "@style/Theme.AppCompat.Light.NoActionBar",*/ MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Rg.Plugins.Popup.Popup.Init(this, bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            AppCenter.Start("{Your App Secret}", typeof(Analytics), typeof(Crashes));
        }

        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                Debug.WriteLine("Android back button: There are some pages in the PopupStack");
            }
            else
            {
                Debug.WriteLine("Android back button: There are not any pages in the PopupStack");
            }
        }
    }
}

