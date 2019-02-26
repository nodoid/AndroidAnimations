using Android.App;
using Android.Widget;
using Android.OS;
using Android.Animation;
using Android.Views.Animations;

namespace InterpolatorsEx
{
    [Activity(Label = "InterpolatorsEx", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var btnRun = FindViewById<Button>(Resource.Id.btnRun);
            var canvas = FindViewById<RelativeLayout>(Resource.Id.animationCanvas);
            var imageView = FindViewById<ImageView>(Resource.Id.faceIcon);

            btnRun.Click += delegate
            {
                var screenHeight = canvas.Height;
                var targetY = screenHeight - imageView.Height;

                var animator = ObjectAnimator.OfFloat(imageView, "y", 0, targetY).SetDuration(1000);
                animator.SetInterpolator(new BounceInterpolator());
                animator.Start();
            };
        }
    }
}

