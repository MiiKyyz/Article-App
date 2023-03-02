using Android.Graphics;
using Android.OS;
using Android.Views;
using Google.Android.Material.BottomNavigation;
using System.Collections.Generic;





namespace News_Project
{
    public class NewsPageFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        private View view;
        private BottomNavigationView tabs;

        List<AndroidX.Fragment.App.Fragment> NewsFragments = new List<AndroidX.Fragment.App.Fragment>()
        {

            new ArticleSearchFragment(),
            new StoriesFragment(),
            new TimesNewswireFragment()
        };    
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
       

            view = inflater.Inflate(Resource.Layout.news_page_layout, container, false);


            tabs = view.FindViewById<BottomNavigationView>(Resource.Id.navigation);

            tabs.NavigationItemSelected += Tabs_NavigationItemSelected;
            

            Activity.SupportFragmentManager.BeginTransaction().Replace(Resource.Id.NewsFrame, NewsFragments[0]).Commit();


            return view;
        }

        private void Tabs_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {

            switch (e.Item.ItemId)
            {
                case Resource.Id.news_article:
                    Activity.SupportFragmentManager.BeginTransaction().Replace(Resource.Id.NewsFrame, NewsFragments[0]).Commit();
                    
                    break;
                case Resource.Id.news_Stories:
                    Activity.SupportFragmentManager.BeginTransaction().Replace(Resource.Id.NewsFrame, NewsFragments[1]).Commit();

                    break;
                case Resource.Id.news_Times_Newswire:
                    Activity.SupportFragmentManager.BeginTransaction().Replace(Resource.Id.NewsFrame, NewsFragments[2]).Commit();

                    break;



            }


        }
    }
}