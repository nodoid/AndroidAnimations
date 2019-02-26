using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Transitions;

namespace TransitionScenesEx
{
    [Activity(Label = "TransitionScenesEx", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        int currentScene = 1;
        Scene scene1, scene2;
        ViewGroup sceneRoot;
        TransitionManager transitionManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            sceneRoot = FindViewById<ViewGroup>(Resource.Id.scene_root);
            scene1 = Scene.GetSceneForLayout(sceneRoot, Resource.Layout.scene1, this);
            scene2 = Scene.GetSceneForLayout(sceneRoot, Resource.Layout.scene2, this);
            transitionManager = TransitionInflater.From(this).InflateTransitionManager(Resource.Transition.manager, sceneRoot);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_transition)
                RunTransition();
            return base.OnOptionsItemSelected(item);
        }

        void RunTransition()
        {
            if (currentScene == 1)
            {
                TransitionManager.Go(scene2);
                currentScene++;
            }
            else
            {
                TransitionManager.Go(scene1);
                currentScene--;
            }
        }
    }
}

