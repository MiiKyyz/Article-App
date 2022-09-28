using Android.Animation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Java.Util.Zip;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace News_and_articles
{
    public class NewsWork
    {
        ObjectAnimator animator, car_anim, chaim_anim, people_anim, back_anim, txt_anim, mini_x, mini_y,
            mini_rota;
        AnimatorSet set = new AnimatorSet();
        public void Loding(ImageView img)
        {

            


            animator =  ObjectAnimator.OfFloat(img, "rotation", 0, 360);
            animator.SetDuration(1000);
            animator.Start();
            animator.RepeatCount = (int)MathF.Pow(10, 5);

        }

        public void Stop(ImageView img)
        {
            animator = ObjectAnimator.OfFloat(img, "rotation", 0, 360);
           
    
          
            animator.End();


        }


        public void AnimationIntro(ImageView car, ImageView chain, ImageView people, LinearLayout back, TextView txt, TextView txt_x, TextView txt_y, TextView rota)
        {

            car_anim = ObjectAnimator.OfFloat(car, "translationX", 1500, -800);
            car_anim.SetDuration(3000);
           


            chaim_anim = ObjectAnimator.OfFloat(chain, "translationX", 1500+400, -400);
            chaim_anim.SetDuration(3000);
          

            people_anim = ObjectAnimator.OfFloat(people, "translationX", 1500 + 300, 320);
            people_anim.SetDuration(3000);


            back_anim = ObjectAnimator.OfFloat(back, "alpha", 0f, 1f);
            back_anim.SetDuration(4000);
            Random random = new Random();

            int number = random.Next(1,3);

            switch (number)
            {

                case 1:
                    txt_anim = ObjectAnimator.OfFloat(txt, "scaleX", 0f, 1f);
                    txt_anim.SetDuration(4000);
                    break;
                case 2:
                    txt_anim = ObjectAnimator.OfFloat(txt, "scaleY", 0f, 1f);
                    txt_anim.SetDuration(4000);
                    break;
            }

            mini_x = ObjectAnimator.OfFloat(txt_x, "scaleY", 0f, 1f);
            mini_x.SetDuration(4000);

            mini_y = ObjectAnimator.OfFloat(txt_y, "scaleX", 0f, 1f);
            mini_y.SetDuration(4000);

            mini_rota = ObjectAnimator.OfFloat(rota, "rotation", 0, 360);
            mini_rota.SetDuration(4000);



            set.PlayTogether(car_anim, chaim_anim, people_anim, back_anim, txt_anim,
                mini_x, mini_y, mini_rota);
            set.Start();
        }




        public Bitmap GetBitmapFromUrl(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] bytes = webClient.DownloadData(url);
                if (bytes != null && bytes.Length > 0)
                {
                    return BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                }
            }
            return null;
        }

    }
}