using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;
using System.Collections.Generic;

namespace News_and_articles
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        BottomNavigationView navigation;

        List<AndroidX.Fragment.App.Fragment> panels;

        [System.Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            //NewYorkTime ny = new NewYorkTime();


            //ny.stories();


            panels = new List<AndroidX.Fragment.App.Fragment>();

            panels.Add(new Stories_Fragment());
            panels.Add(new Newspaper_Fragment());
            panels.Add(new Popular_Fragment());
           
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame_panel, panels[0]).Commit();
      

        }

        public void TextFonts(string FontType, TextView txt_fonts)
        {

            Typeface txt = Typeface.CreateFromAsset(Assets, FontType);
            
             
            txt_fonts.SetTypeface(txt, TypefaceStyle.Normal);

        }



        public bool OnNavigationItemSelected(IMenuItem item)
        {

           
            switch (item.ItemId)
            {
                case Resource.Id.Stories:


                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame_panel, panels[0]).Commit();

                    return true;

                case Resource.Id.newspaper:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame_panel, panels[1]).Commit();
                    return true;

                case Resource.Id.Popular:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frame_panel, panels[2]).Commit();

                    return true;

                
            }

            return false;
        }

    }
}