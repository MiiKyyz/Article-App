using Android.Animation;
using Android.Views;
using Android.Widget;
using System;
namespace News_Project
{
    public class AnimationManager
    {

        private ObjectAnimator anim_1, anim_2, anim_3, anim_4, adapter_anim, book_adapter, news_adapter;
        private AnimatorSet set = new AnimatorSet();


        public ObjectAnimator NewsAdapterAnim(View view)
        {

            news_adapter = ObjectAnimator.OfFloat(view, "scaleX", 0f, 1f);
            news_adapter.SetDuration(400);



            return news_adapter;
        }


        public ObjectAnimator BookAdapterAnim(View view)
        {

            book_adapter = ObjectAnimator.OfFloat(view, "scaleX", 0f, 1f);
            book_adapter.SetDuration(500);



            return book_adapter;
        }

        public ObjectAnimator LoadingAdapter(ImageView img)
        {
            adapter_anim = ObjectAnimator.OfFloat(img, "rotation", 0, 13360);
            adapter_anim.SetDuration(10000);
            adapter_anim.RepeatCount = (int)MathF.Pow(10, 5);

            return adapter_anim;
        }

        public void AdapterCancel()
        {

            adapter_anim.End();

        }

        public AnimatorSet LoadingAnimation(ImageView[] img)
        {



            anim_1 = ObjectAnimator.OfFloat(img[0], "rotation", 0, 13360);
            anim_1.RepeatCount = (int)MathF.Pow(10, 5);

            anim_2 = ObjectAnimator.OfFloat(img[1], "rotation", 0, 13360);
            anim_2.RepeatCount = (int)MathF.Pow(10, 5);

            anim_3 = ObjectAnimator.OfFloat(img[2], "rotation", 0, 13360);
            anim_3.RepeatCount = (int)MathF.Pow(10, 5);

            anim_4 = ObjectAnimator.OfFloat(img[3], "rotation", 0, 13360);
            anim_4.RepeatCount = (int)MathF.Pow(10, 5);



            set.PlayTogether(anim_1, anim_2, anim_3, anim_4);
            set.SetDuration(15000);
            return set;
        }

        public void Canceler()
        {

            set.End();

        }

    }
}