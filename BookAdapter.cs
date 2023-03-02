using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;




namespace News_Project
{
    public class BookAdapter : BaseAdapter
    {

    
        public static Dictionary<int, ImageView> images_transition = new Dictionary<int, ImageView>();
        private LayoutInflater layoutInflater;
        private List<string> TitleBook = new List<string>();
        private List<string> AuthorBook = new List<string>();
        
        private List<Bitmap> imgs = new List<Bitmap>();
        private AnimationManager animationManager = new AnimationManager();
        public BookAdapter(Context context, List<string> TitleBook, List<string> AuthorBook,  List<Bitmap> imgs)
        {
            this.TitleBook = TitleBook;
            this.AuthorBook = AuthorBook;
            this.imgs = imgs;

            layoutInflater = LayoutInflater.FromContext(context);


        }



        public override int Count => TitleBook.Count;

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
            convertView = layoutInflater.Inflate(Resource.Layout.book_adapter, parent, false);

            TextView title = convertView.FindViewById<TextView>(Resource.Id.TitleAdapter);
            ImageView img = convertView.FindViewById<ImageView>(Resource.Id.imageViewAdapter);
            TextView rank = convertView.FindViewById<TextView>(Resource.Id.RankAdapter);


            img.SetImageBitmap(imgs[position]);
            title.Text = TitleBook[position];
            rank.Text = $"Rank: {position+1} \n Author: {AuthorBook[position]}";

            
            animationManager.BookAdapterAnim(convertView).Start();

            img.Id = position;
            /* try
             {

                 images_transition.Add(img.Id,img);

             }
             catch
             {
                 images_transition[img.Id] = img;

             }*/

            images_transition[img.Id] = img;
            //Log.Info("miky", $"{images_transition.Count}");

            return convertView;
        }
    }
}