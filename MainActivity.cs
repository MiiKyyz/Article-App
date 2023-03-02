using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.Navigation;




namespace News_Project
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {

        List<AndroidX.Fragment.App.Fragment> fragments = new List<AndroidX.Fragment.App.Fragment>()
        {

            new MainPageFragment(),
            new NewsPageFragment(),
            new BookFragment(),


        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

           

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame, fragments[0]).Commit();
            
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

    

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            switch (id)
            {

                case Resource.Id.main_page:
                    NewsMainPage.cloase_threads = true;
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame, fragments[0]).Commit();
                    break;
                case Resource.Id.news_page:
                    NewsMainPage.State = false;
                    NewsMainPage.cloase_threads = false;
                    NewsMainPage.Loop_State = 0;
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame, fragments[1]).Commit();
                    break;
                 case Resource.Id.book_page:
                    NewsMainPage.State = false;
                    NewsMainPage.cloase_threads = false;
                    NewsMainPage.Loop_State = 0;
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame, fragments[2]).Commit();
                    break;


                     

                    


            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

