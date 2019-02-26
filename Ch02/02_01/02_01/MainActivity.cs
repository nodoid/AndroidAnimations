using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views.Animations;

namespace AnimateXML_01
{
    [Activity(Label = "AnimateXML", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, Animation.IAnimationListener
    {
        ImageView imageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            imageView = FindViewById<ImageView>(Resource.Id.faceIcon);

            var btnRun = FindViewById<Button>(Resource.Id.btnRun);
            btnRun.Click += delegate
            {
                var animation = AnimationUtils.LoadAnimation(this, Resource.Animation.grow);

                animation.SetAnimationListener(this);

                imageView.StartAnimation(animation);
            };
        }

        public void OnAnimationEnd(Animation animation)
        {
            imageView.ScaleX = 2;
            imageView.ScaleY = 2;
        }

        public void OnAnimationRepeat(Animation animation)
        {

        }

        public void OnAnimationStart(Animation animation)
        {

        }
    }
}

