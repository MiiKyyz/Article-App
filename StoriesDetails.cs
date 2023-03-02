using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;







namespace News_Project
{
    [Activity(Label = "StoriesDetails")]
    public class StoriesDetails : AppCompatActivity
    {

        private TextView title_stories_detail, descp_stories_detail, ByLine_stories_detail, section_stories_detail;
        private Button btn_stories_detail;
        private ImageView img_stories_detail;
        private int index;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.stories_details);
            // Create your application here


            title_stories_detail = FindViewById<TextView>(Resource.Id.title_stories_detail);
            descp_stories_detail = FindViewById<TextView>(Resource.Id.descp_stories_detail);
            ByLine_stories_detail = FindViewById<TextView>(Resource.Id.ByLine_stories_detail);
            section_stories_detail = FindViewById<TextView>(Resource.Id.section_stories_detail);

            img_stories_detail = FindViewById<ImageView>(Resource.Id.img_stories_detail);
            btn_stories_detail = FindViewById<Button>(Resource.Id.btn_stories_detail);

            string name = Intent.GetStringExtra("index" ?? "not recv");

            index = int.Parse(name);


            title_stories_detail.Text = $"{News.title_stories[index]}";
            descp_stories_detail.Text = $"{News.descrp_stories[index]}";
            ByLine_stories_detail.Text = $"Article written {News.byline_stories[index]}";
            section_stories_detail.Text = $"Section: {News.section_stories[index]}";


            Bitmap bitmap = News.Images_stories[index];
            img_stories_detail.SetImageBitmap(bitmap);


            btn_stories_detail.Click += Btn_stories_detail_Click;

        }

        private void Btn_stories_detail_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse($"{News.url_stories[index]}");

            var ConIntent = new Intent(Intent.ActionView, uri);
            StartActivity(ConIntent);

        }
    }
}