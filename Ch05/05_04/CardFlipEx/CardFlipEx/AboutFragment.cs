
using Android.App;
using Android.OS;
using Android.Views;

namespace CardFlipEx
{
    public class AboutFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.content_about, container, false);
        }
    }
}
