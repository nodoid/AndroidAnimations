using System;
using System.Collections.Generic;
using CrossFadeEx.Models;
using Android.Views;
using Android.Widget;
using Android.Icu.Text;
using Android.Graphics;
using Android.App;
using Android.Content;

namespace CrossFadeEx
{
    public class ProductListAdapter : BaseAdapter<Product>
    {
        List<Product> Products;
        Context context;

        public ProductListAdapter(Context ctext, List<Product> prods)
        {
            Products = prods;
            context = ctext;
        }

        public override int Count => Products.Count;

        public override Product this[int position] => Products[position];

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.list_item, parent, false);

            var product = Products[position];

            var nameText = convertView.FindViewById<TextView>(Resource.Id.nameText);
            nameText.Text = product.Name;

            var formatter = NumberFormat.CurrencyInstance;
            var price = formatter.Format(product.Price);

            var priceText = convertView.FindViewById<TextView>(Resource.Id.priceText);
            priceText.Text = price;

            var iv = convertView.FindViewById<ImageView>(Resource.Id.imageView);
            var bitmap = getBitmapFromAsset(product.ProductId);
            iv.SetImageBitmap(bitmap);

            return convertView;
        }

        Bitmap getBitmapFromAsset(string productId)
        {
            var assetManager = Application.Context.Assets;

            try
            {
                var stream = assetManager.Open($"{productId}.png");
                return BitmapFactory.DecodeStream(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
