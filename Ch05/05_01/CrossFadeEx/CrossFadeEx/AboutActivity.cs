
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace CrossFadeEx
{
    [Activity]
    public class AboutActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_about);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }
    }
}
