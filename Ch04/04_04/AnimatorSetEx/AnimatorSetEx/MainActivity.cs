using Android.App;
using Android.Widget;
using Android.OS;
using Android.Animation;

namespace AnimatorSetEx
{
    [Activity(Label = "AnimatorSetEx", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var btnRun = FindViewById<Button>(Resource.Id.btnRun);

            var imageView = FindViewById<ImageView>(Resource.Id.faceIcon);

            btnRun.Click += delegate
            {
                var animatorX = ObjectAnimator.OfFloat(imageView, "scaleX", 1f, 2f).SetDuration(1000);
                var animatorY = ObjectAnimator.OfFloat(imageView, "scaleY", 1f, 2f).SetDuration(1000);

                var animatorSet = new AnimatorSet();
                //animatorSet.PlaySequentially(animatorX, animatorY);

                animatorSet.PlayTogether(animatorX, animatorY);

                animatorSet.SetDuration(3000);
                animatorSet.Start();
            };
        }
    }
}

