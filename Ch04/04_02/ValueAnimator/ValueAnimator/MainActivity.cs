using Android.App;
using Android.Widget;
using Android.OS;

namespace ValueAnimation
{
    [Activity(Label = "ValueAnimator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, Android.Animation.ValueAnimator.IAnimatorUpdateListener
    {
        TextView mlog;
        ScrollView mscroll;

        public void OnAnimationUpdate(Android.Animation.ValueAnimator animation)
        {
            displayMessage("timestamp: " + animation.CurrentPlayTime +
                ", value: " + animation.AnimatedValue);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            mscroll = FindViewById<ScrollView>(Resource.Id.scrollLog);
            mlog = FindViewById<TextView>(Resource.Id.tvLog);

            var btnRun = FindViewById<Button>(Resource.Id.btnRun);
            var btnClear = FindViewById<Button>(Resource.Id.btnClear);

            mlog.Text = "";

            btnRun.Click += delegate
            {
                var animator = Android.Animation.ValueAnimator.OfFloat(1f, 20f);
                animator.SetDuration(2000);
                animator.AddUpdateListener(this);

                animator.RepeatCount = Android.Animation.ValueAnimator.Infinite;
                animator.Start();
            };

            btnClear.Click += delegate
            {
                mlog.Text = "";
                mscroll.ScrollTo(0, mscroll.Bottom);
            };
        }

        void displayMessage(string message)
        {
            mlog.Append(message + "\n");
            mscroll.ScrollTo(0, mscroll.Bottom);
        }
    }
}

