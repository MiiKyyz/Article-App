using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace News_Project
{
    internal class ArticleSearchAdapter : BaseAdapter
    {

        public static Dictionary<int, ImageView> Images_transition = new Dictionary<int, ImageView>();
        private List<string> Headlines = new List<string>();
        private List<string> ByLine = new List<string>();
        private List<Bitmap> img = new List<Bitmap>();
        private LayoutInflater layoutInflater;
        private AnimationManager animationManager = new AnimationManager();
        public ArticleSearchAdapter(Context context, List<string> Headlines, List<string> ByLine, List<Bitmap> img)
        {
            this.Headlines = Headlines;
            this.ByLine = ByLine;
            this.img = img;
            
            layoutInflater = LayoutInflater.FromContext(context);
        }


        public override int Count => Headlines.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            convertView = layoutInflater.Inflate(Resource.Layout.article_search_adapter, parent, false);


            TextView Headline = convertView.FindViewById<TextView>(Resource.Id.headLine_article);
            TextView by_line = convertView.FindViewById<TextView>(Resource.Id.ByLine_article);
            ImageView imgs = convertView.FindViewById<ImageView>(Resource.Id.img_article);

            Headline.Text = $"{Headlines[position]}";
            by_line.Text = $"Article Witten {ByLine[position]}";

            imgs.SetImageBitmap(img[position]);
            
            animationManager.NewsAdapterAnim(convertView).Start();

            imgs.Id = position;

            try
            {
                Images_transition.Add(imgs.Id, imgs);
            }
            catch
            {

                Images_transition[imgs.Id] = imgs;
            }

            

            return convertView;



        }
    }
}