using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using Android.Widget;
using Android.Content;
using CrossFadeEx.Models;
using CrossFadeEx.DataProviders;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;

namespace CrossFadeEx
{
    [Activity(Label = "CrossFadeEx", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        const int MENU_ITEM_LOGOUT = 1001;
        public static string product_id { get; set; } = "PRODUCT_ID";

        CoordinatorLayout coordinatorLayout;
        List<Product> products = DataProvider.productList;
        FloatingActionButton fab;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            coordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.coordinator);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            SetSupportActionBar(toolbar);

            var adapter = new ProductListAdapter(this, products);
            var lv = FindViewById<ListView>(Resource.Id.listView);
            lv.Adapter = adapter;
            lv.ItemClick += (sender, e) =>
            {
                var intent = new Intent(this, typeof(DetailActivity));
                var product = products[e.Position];
                intent.PutExtra(product_id, product.ProductId);
                StartActivity(intent);
                OverridePendingTransition(Android.Resource.Animation.FadeIn, Android.Resource.Animation.FadeOut);
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var id = item.ItemId;

            switch (id)
            {
                case Resource.Id.action_about:
                    startAboutActivity();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        void startAboutActivity()
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }
    }
}

