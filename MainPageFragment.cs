using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace News_Project
{
    public class MainPageFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        
        private View view;
        private ViewSwitcher viewSwitcher, view_switcher_shared, view_switcher_emailed, view_switcher_viewed;
        private NewsMainPage MainNewsManager = new NewsMainPage();
   

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            view = inflater.Inflate(Resource.Layout.main_page_layout, container, false);
            viewSwitcher = view.FindViewById<ViewSwitcher>(Resource.Id.view_switcher);
            view_switcher_shared = view.FindViewById<ViewSwitcher>(Resource.Id.view_switcher_shared);
            view_switcher_emailed = view.FindViewById<ViewSwitcher>(Resource.Id.view_switcher_emailed);
            view_switcher_viewed = view.FindViewById<ViewSwitcher>(Resource.Id.view_switcher_viewed);

             
            viewSwitcher.SetInAnimation(Context, Resource.Animation.abc_slide_in_top);
            viewSwitcher.SetOutAnimation(Context, Resource.Animation.abc_slide_out_bottom);

            view_switcher_shared.SetInAnimation(Context, Resource.Animation.abc_slide_in_top);
            view_switcher_shared.SetOutAnimation(Context, Resource.Animation.abc_slide_out_bottom);

            view_switcher_emailed.SetInAnimation(Context, Resource.Animation.abc_slide_in_top);
            view_switcher_emailed.SetOutAnimation(Context, Resource.Animation.abc_slide_out_bottom);

            view_switcher_viewed.SetInAnimation(Context, Resource.Animation.abc_slide_in_top);
            view_switcher_viewed.SetOutAnimation(Context, Resource.Animation.abc_slide_out_bottom);

            NewsMainPage.State = false;
            NewsMainPage.Loop_State = 0;


            MainNewsManager.NewsPanel(Activity, Context, container, viewSwitcher, view_switcher_shared, view_switcher_emailed, view_switcher_viewed);
            _ = MainNewsManager.MainNews();

           

            
            

            


            return view;
        }

        
       

    }
}