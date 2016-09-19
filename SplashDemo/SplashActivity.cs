using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using System.Threading.Tasks;
using System.Threading;

namespace SplashDemo
{
    /// <summary>
    /// Define the application  label and theme. The theme must be the one created in the "Style.xml" file.
    /// </summary>
    [Activity(Label = "@string/ApplicationName", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        static readonly string DATE_FMT = "dd/MM/yyyy hh:mm:ss:ffff";

        // override just for log, is not necessary
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug("SplashDemo", "SplashActivity.OnCreate");
        }

        protected override void OnResume()
        {
            base.OnResume();

            // runs in a separate thread, or will freeze!
            Task startupWork = new Task(() =>
            {
                Log.Debug("SplashDemo", "Init DataBase - " + DateTime.Now.ToString(DATE_FMT));
                try
                {
                    // Do something cool here, like init your database...
                    Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                    Log.Error("SplashDemo", "Shit happens... " + ex.Message);
                    throw;
                }

                Log.Debug("SplashDemo", "Done Loading DataBase - " + DateTime.Now.ToString(DATE_FMT));
            });

            startupWork.ContinueWith(t =>            
            {
                // when the separate thread finish, we start our real main activity.
                Log.Debug("SplashDemo", "Starting MainActivity - " + DateTime.Now.ToString(DATE_FMT));
                var main = new Intent(Application.Context, typeof(MainActivity));                
                StartActivity(main);

            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}