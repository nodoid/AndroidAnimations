using Android.App;
using Android.Widget;
using Android.OS;
using Android.Animation;

namespace ObjectAnimatorEx
{
    [Activity(Label = "ObjectAnimatorEx", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var btnRun = FindViewById<Button>(Resource.Id.btnRun);
            var imageView = FindViewById<ImageView>(Resource.Id.faceIcon);

            btnRun.Click += delegate
            {
                var animatorX = ObjectAnimator.OfFloat(imageView, "scaleX", 1f, 2f).SetDuration(1000);
                animatorX.Start();

                var animatorY = ObjectAnimator.OfFloat(imageView, "scaleY", 1f, 2f);
                animatorY.Start();
            };
        }
    }
}

