using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndroidX.AppCompat.App;
using System.Threading.Tasks;
using Java.Lang;

namespace News_and_articles
{
    [Activity(Label = "News", Theme = "@style/Theme.AppCompat.NoActionBar", MainLauncher = true, Icon = "@drawable/logo")]
    public class IntroActivity : AppCompatActivity
    {


        ImageView car, chain, people;
        TextView txt, txt_mini;
        LinearLayout back;
        NewsWork anim = new NewsWork();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.intro_layout);
            // Create your application here


            txt = FindViewById<TextView>(Resource.Id.txt_title);
            txt_mini = FindViewById<TextView>(Resource.Id.txt_mini);
            car = FindViewById<ImageView>(Resource.Id.img_car);
            chain = FindViewById<ImageView>(Resource.Id.img_chain);
            people = FindViewById<ImageView>(Resource.Id.img_people);
            back = FindViewById<LinearLayout>(Resource.Id.back_img);

            anim.AnimationIntro(car, chain, people, back, txt_mini, txt, txt, txt);

            intro();



        }
        private void intro()
        {

            Task start_new = new Task(() =>
            {

                Thread.Sleep(5000);



            });

            start_new.ContinueWith(m =>
            {

                StartActivity(new Intent(Application.Context, typeof(MainActivity)));


            }, TaskScheduler.FromCurrentSynchronizationContext());
            start_new.Start();



        }

    }
}