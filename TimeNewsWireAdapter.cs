using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;







namespace News_Project
{
    public class TimeNewsWireAdapter : BaseAdapter
    {
        public static Dictionary<int, ImageView> img_transitions = new Dictionary<int, ImageView>();
        private List<string> title = new List<string>();
        private List<string> byline = new List<string>();
        private List<Bitmap> Images = new List<Bitmap>();
        private LayoutInflater layoutInflater;
        public TimeNewsWireAdapter(Context context, List<string> title, List<string> byline, List<Bitmap> Images)
        {
            this.title = title;
            this.byline = byline;
            this.Images = Images;

            layoutInflater = LayoutInflater.FromContext(context);
        }


        public override int Count => title.Count;

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
            convertView = layoutInflater.Inflate(Resource.Layout.Time_news_wire_adapter, parent, false);

            TextView title_txt = convertView.FindViewById<TextView>(Resource.Id.title_adapter_wire);
            TextView byline_txt = convertView.FindViewById<TextView>(Resource.Id.byline_adapter_wire);

            ImageView img_adapter = convertView.FindViewById<ImageView>(Resource.Id.img_adapter_wire);


            img_adapter.Id = position;

            img_transitions[img_adapter.Id] = img_adapter;




            img_adapter.SetImageBitmap(Images[position]);

            if (title[position] == "")
            {

                title_txt.Text = $"None Title";
            }
            else
            {
                title_txt.Text = $"{title[position]}";

            }

            if (byline[position] == "")
            {

                byline_txt.Text = $"None Writer";
            }
            else
            {
                byline_txt.Text = $"Written {byline[position]}";

            }



            return convertView;
        }
    }
}