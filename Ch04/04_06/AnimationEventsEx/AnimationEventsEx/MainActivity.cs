using Android.App;
using Android.Widget;
using Android.OS;
using Android.Animation;
using Android.Views.Animations;

namespace AnimationEventsEx
{
    [Activity(Label = "AnimationEventsEx", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, ValueAnimator.IAnimatorUpdateListener, ValueAnimator.IAnimatorListener
    {
        ImageView imageView;
        RelativeLayout canvas;
        string TAG { get; set; } = "AnimationEvents";

        public void OnAnimationCancel(Animator animation)
        {

        }

        public void OnAnimationEnd(Animator animation)
        {

        }

        public void OnAnimationRepeat(Animator animation)
        {

        }

        public void OnAnimationStart(Animator animation)
        {

        }

        public void OnAnimationUpdate(ValueAnimator animation)
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            var btnRun = FindViewById<Button>(Resource.Id.btnRun);
            imageView = FindViewById<ImageView>(Resource.Id.faceIcon);
            canvas = FindViewById<RelativeLayout>(Resource.Id.animationCanvas);

            btnRun.Click += delegate
            {
                var screenHeight = canvas.Height;
                var targetY = screenHeight - imageView.Height;

                var animator = ObjectAnimator.OfFloat(imageView, "y", 0, targetY);
                animator.SetDuration(1000);
                animator.SetInterpolator(new BounceInterpolator());
                animator.RepeatCount = 2;
                animator.AddUpdateListener(this);
                animator.AddListener(this);

                animator.Start();
            };
        }
    }
}

