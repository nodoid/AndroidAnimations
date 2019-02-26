using Android.App;
using Android.Widget;
using Android.OS;
using Android.Animation;

namespace AnimateXML_02
{
    [Activity(Label = "AnimateXML_02", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, Animator.IAnimatorListener
    {
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            var btnRun = FindViewById<Button>(Resource.Id.btnRun);
            var imageView = FindViewById<ImageView>(Resource.Id.faceIcon);

            btnRun.Click += delegate
            {
                imageView.Animate().ScaleX(2).ScaleY(2).RotationX(180).RotationY(180).TranslationX(200).TranslationY(200).SetDuration(2000).SetListener(this);
            };

        }
    }

}

