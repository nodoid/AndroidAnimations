using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using ViewPagerEx.Models;
using ViewPagerEx.DataProviders;
using Android.Support.V4.View;
using Android.Support.V4.App;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using Fragment = Android.Support.V4.App.Fragment;
using ViewPagerEx.Transformers;
using Android.Support.V7.App;

namespace ViewPagerEx
{
    [Activity(Label = "ViewPagerEx", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {

        ViewPager viewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            viewPager.SetPageTransformer(true, new ZoomPageTransformer());
            var viewPagerAdapter = new ViewPagerAdapter(SupportFragmentManager);

            viewPager.Adapter = viewPagerAdapter;
        }

        public override void OnBackPressed()
        {
            if (viewPager.CurrentItem == 0)
                base.OnBackPressed();
            else
                viewPager.SetCurrentItem(viewPager.CurrentItem - 1, true);
        }

        class ViewPagerAdapter : FragmentStatePagerAdapter
        {
            string TAG = "Adapter";
            List<Product> products = DataProvider.productList;
            int numPages = DataProvider.productList.Count;

            public ViewPagerAdapter(FragmentManager fm) : base(fm)
            { }

            public override Fragment GetItem(int position) => ItemFragment.Create(products[position]);

            public override int Count => numPages;
        }
    }
}

