using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;






namespace News_Project
{
    public class StoriesAdapter : BaseAdapter
    {

        public static Dictionary<int, ImageView> img_transition = new Dictionary<int, ImageView>();
        private List<string> Titles = new List<string>(); 
        private List<string> byline = new List<string>();
        private List<Bitmap> Images = new List<Bitmap>();
        LayoutInflater inflate;
        public StoriesAdapter(Context context, List<string> Titles, List<string> byline, List<Bitmap> Images)
        {
            this.byline = byline;
            this.Titles = Titles;
            this.Images = Images;
            inflate = LayoutInflater.FromContext(context);
            
        }


        public override int Count => Titles.Count;

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
            convertView = inflate.Inflate(Resource.Layout.stories_adapter, parent, false);

            TextView title_txt = convertView.FindViewById<TextView>(Resource.Id.headLine_article_stories);
            TextView ByLine_txt = convertView.FindViewById<TextView>(Resource.Id.ByLine_stories);
            ImageView img_stories = convertView.FindViewById<ImageView>(Resource.Id.img_stories);


            title_txt.Text = $"{Titles[position]}";
            ByLine_txt.Text = $"{byline[position]}";
            img_stories.SetImageBitmap(Images[position]);

            img_stories.Id = position;


            try
            {
                img_transition.Add(img_stories.Id, img_stories);

            }
            catch
            {

                img_transition[img_stories.Id] = img_stories;
            }


            AnimationManager animationManager = new AnimationManager();


            animationManager.NewsAdapterAnim(convertView).Start();

            return convertView;

        }
    }
}