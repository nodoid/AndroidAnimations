
using Android.App;
using Android.OS;
using Android.Views;
using Android.Content;
using CardFlipEx.Interfaces;

namespace CardFlipEx
{
    public class ItemListFragment : ListFragment
    {
        IListEventHandler parentActivity;

        public ItemListFragment() { }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_item_list, container, false);
        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            parentActivity = (IListEventHandler)context;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            ListView.ItemClick += (sender, e) =>
            {
                parentActivity.OnListItemClick(e.Position);

            };
        }
    }
}
