using Android.OS;
using Android.Views;
using ViewPagerEx.Models;
using Android.Widget;
using Android.Icu.Text;

namespace ViewPagerEx
{
    public class ItemFragment : Android.Support.V4.App.Fragment
    {
        static string PRODUCT_ID = "productId";
        static string PRODUCT_NAME = "productName";
        static string PRODUCT_DESC = "productDesc";
        static string PRODUCT_PRICE = "productPrice";

        public static ItemFragment Create(Product product)
        {
            var args = new Bundle();
            args.PutString(PRODUCT_ID, product.ProductId);
            args.PutString(PRODUCT_NAME, product.Name);
            args.PutString(PRODUCT_DESC, product.Description);
            args.PutDouble(PRODUCT_PRICE, product.Price);

            var fragment = new ItemFragment
            {
                Arguments = args
            };

            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = (ViewGroup)inflater.Inflate(Resource.Layout.fragment_detail, container, false);
            var args = Arguments;

            var nameText = rootView.FindViewById<TextView>(Resource.Id.nameText);
            nameText.Text = args.GetString(PRODUCT_NAME);

            var descText = rootView.FindViewById<TextView>(Resource.Id.descriptionText);
            descText.Text = args.GetString(PRODUCT_DESC);

            var formatter = NumberFormat.CurrencyInstance;
            var price = formatter.Format(args.GetDouble(PRODUCT_PRICE));
            var textPrice = rootView.FindViewById<TextView>(Resource.Id.priceText);
            textPrice.Text = price;

            var prodId = args.GetString(PRODUCT_ID);
            var imageResource = Activity.Resources.GetIdentifier(prodId, "drawable", Activity.PackageName);
            var iv = rootView.FindViewById<ImageView>(Resource.Id.imageView);
            iv.SetImageResource(imageResource);

            return rootView;
        }
    }
}
