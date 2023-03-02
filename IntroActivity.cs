using Android.Animation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Icu.Number;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Android.Graphics.Paint;

namespace News_Project
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/Theme.AppCompat.NoActionBar")]
    public class IntroActivity : AppCompatActivity
    {


        private RelativeLayout relativeLayout;
        private TextView textView;
        private List<int> imgs = new List<int>()
        {

            Resource.Drawable.background,
            Resource.Drawable.background_2,
            Resource.Drawable.background_3,
            Resource.Drawable.background_4,


        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.intro_layout);
            // Create your application here

            relativeLayout = FindViewById<RelativeLayout>(Resource.Id.relativeLayout);
            textView = FindViewById<TextView>(Resource.Id.textView);

            PanelAnim();

            TextFonts();

            Random random = new Random();

            int num = random.Next(0, imgs.Count);


            relativeLayout.SetBackgroundResource(imgs[num]);
        }
        public void TextFonts()
        {

            Typeface txt = Typeface.CreateFromAsset(Assets, "DancingScript-Bold.ttf");

            textView.SetTypeface(txt, TypefaceStyle.Normal);

        }


        private void PanelAnim()
        {

            ObjectAnimator background_alpha = ObjectAnimator.OfFloat(relativeLayout, "alpha", 0f, 1f);
            ObjectAnimator scaleX_anim = ObjectAnimator.OfFloat(textView, "scaleX", 0f, 1f);
            ObjectAnimator scaleY_anim = ObjectAnimator.OfFloat(textView, "scaleY", 0f, 1f);
            ObjectAnimator translationY_anim = ObjectAnimator.OfFloat(textView, "y", 0, 560);
            AnimatorSet animatorSet = new AnimatorSet();


            animatorSet.PlayTogether(background_alpha, scaleX_anim, scaleY_anim, translationY_anim);
            animatorSet.SetDuration(3500);
            animatorSet.Start();



            Task startup = new Task(() =>
            {
                Thread.Sleep(4000);
            });


            startup.ContinueWith(t =>
            {

                StartActivity(new Intent(Application.Context, typeof(MainActivity)));

            }, TaskScheduler.FromCurrentSynchronizationContext());
            startup.Start();

        }

    }
}