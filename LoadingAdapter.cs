using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace News_Project
{
    public class LoadingAdapter : BaseAdapter
    {
        private LayoutInflater layoutInflater;
        private List<string> TitleLoading = new List<string>() ;
        private List<int> imgs = new List<int>();
        private string state;
        AnimationManager animationManager = new AnimationManager();

        
        public LoadingAdapter(Context context, List<string> TitleLoading, List<int> imgs, string state)
        {


            this.TitleLoading = TitleLoading;
            this.imgs = imgs;
            this.state = state;
            layoutInflater = LayoutInflater.FromContext(context);

        }


        public override int Count => TitleLoading.Count;

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
            convertView = layoutInflater.Inflate(Resource.Layout.loading_layout, parent, false);

            ImageView img = convertView.FindViewById<ImageView>(Resource.Id.imageLoading);
            TextView txt = convertView.FindViewById<TextView>(Resource.Id.TitleLoading);

            img.SetImageResource(imgs[position]);

            txt.Text = $"{TitleLoading[position]}";


            if(state == "loading")
            {
                animationManager.LoadingAdapter(img).Start();

            }

            

            return convertView;
        }
    }
}