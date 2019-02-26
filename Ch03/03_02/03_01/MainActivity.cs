using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Graphics.Drawables;

namespace AnimateDrawable
{
    [Activity(Label = "AnimateDrawable", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var btnRun = FindViewById<Button>(Resource.Id.btnRun);
            var btnClear = FindViewById<Button>(Resource.Id.btnClear);

            var imageView = FindViewById<ImageView>(Resource.Id.animation);
            imageView.Visibility = ViewStates.Invisible;
            imageView.SetBackgroundResource(Resource.Drawable.monkey_animation);

            var monkeyAnimation = (AnimationDrawable)imageView.Background;
            monkeyAnimation.OneShot = true;

            btnRun.Click += delegate
            {
                imageView.Visibility = ViewStates.Visible;
                if (monkeyAnimation.IsRunning)
                {
                    monkeyAnimation.Stop();
                }
                monkeyAnimation.Start();
            };

            btnClear.Click += delegate
            {
                monkeyAnimation.Stop();
            };
        }
    }
}

