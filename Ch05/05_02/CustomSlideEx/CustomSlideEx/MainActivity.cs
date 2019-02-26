using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using CustomSlideEx.Models;
using CustomSlideEx.DataProviders;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;
using Android.Views;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace CustomSlideEx
{
    [Activity(Label = "CustomSlideEx", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        public static int MENU_ITEM_LOGOUT { get; set; } = 1001;
        public static string PRODUCT_ID { get; set; } = "PRODUCT_ID";
        CoordinatorLayout coordinatorLayout;

        List<Product> products = DataProvider.productList;
        FloatingActionButton floatingActionBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            coordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.coordinator);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            floatingActionBar = FindViewById<FloatingActionButton>(Resource.Id.fab);

            var adapter = new ProductListAdapter(this, products);

            var lv = FindViewById<ListView>(Resource.Id.listView);
            lv.Adapter = adapter;
            lv.ItemClick += (sender, e) =>
            {
                var intent = new Intent(this, typeof(DetailActivity));
                var product = products[e.Position];
                intent.PutExtra(PRODUCT_ID, product.ProductId);
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.slide_in_right, Resource.Animation.slide_out_left);
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var id = item.ItemId;
            switch (id)
            {
                case Resource.Id.action_about:
                    StartAboutActivity();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        void StartAboutActivity()
        {
            StartActivity(new Intent(this, typeof(AboutActivity)));
        }
    }
}

