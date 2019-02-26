
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using CustomSlideEx.DataProviders;
using Android.Icu.Text;
using Android.Support.Design.Widget;
using Android.Graphics;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace CustomSlideEx
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_detail);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var productId = Intent.GetStringExtra(MainActivity.PRODUCT_ID);
            var product = DataProvider.GetProduct(productId);

            var tv = FindViewById<TextView>(Resource.Id.nameText);
            tv.Text = product.Name;

            var descView = FindViewById<TextView>(Resource.Id.descriptionText);
            descView.Text = product.Description;

            var formatter = NumberFormat.CurrencyInstance;
            var price = formatter.Format(product.Price);
            var priceText = FindViewById<TextView>(Resource.Id.priceText);
            priceText.Text = price;

            var iv = FindViewById<ImageView>(Resource.Id.imageView);
            var bitmap = getBitmapFromAsset(product.ProductId);
            iv.SetImageBitmap(bitmap);

            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += delegate
            {
                var rootView = FindViewById<CoordinatorLayout>(Resource.Id.coordinator);
                Snackbar.Make(rootView, "Replace with your own action", Snackbar.LengthLong).SetAction("Action", (t) => { }).Show();
            };

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        protected override void OnPause()
        {
            base.OnPause();
            OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        Bitmap getBitmapFromAsset(string id)
        {
            var assetManager = Assets;
            try
            {
                return BitmapFactory.DecodeStream(Assets.Open($"{id}.png"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
