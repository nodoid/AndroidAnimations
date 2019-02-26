using Android.App;
using Android.OS;
using Android.Support.V7.App;
using CardFlipEx.Models;
using CardFlipEx.DataProviders;
using Android.Views;
using System.Collections.Generic;
using CardFlipEx.Interfaces;
using Android.Content;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace CardFlipEx
{
    [Activity(Label = "CardFlipEx", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity, IListEventHandler
    {
        public static string PRODUCT_ID = "PRODUCT_ID";
        List<Product> products = DataProvider.productList;
        AboutFragment aboutFragment;
        bool showingAbout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var fragment = new ItemListFragment();
            FragmentManager.BeginTransaction().Add(Resource.Id.fragment_container, fragment).Commit();

            var adapter = new ProductListAdapter(this, products);
            fragment.ListAdapter = adapter;
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
                    ViewAbout();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            if (showingAbout)
            {
                FragmentManager.PopBackStack();
                showingAbout = false;
            }
            else
                base.OnBackPressed();
        }

        public void OnListItemClick(int position)
        {
            var intent = new Intent(this, typeof(DetailActivity));
            var prod = products[position];
            intent.PutExtra(PRODUCT_ID, prod.ProductId);
            StartActivity(intent);
        }

        void ViewAbout()
        {
            if (showingAbout)
            {
                FragmentManager.PopBackStack();
                showingAbout = false;
                return;
            }

            aboutFragment = new AboutFragment();
            FragmentManager.BeginTransaction().SetCustomAnimations
                (Resource.Animator.card_flip_right_in, Resource.Animator.card_flip_right_out,
                Resource.Animator.card_flip_left_in, Resource.Animator.card_flip_left_out).Replace(Resource.Id.fragment_container, aboutFragment).AddToBackStack(null).Commit();
            showingAbout = true;
        }
    }
}

