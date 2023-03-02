using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace News_Project
{
    [Activity(Label = "ArticleSearchDetails")]
    public class ArticleSearchDetails : AppCompatActivity
    {
        private TextView title_article, descp_article, byLine_article;
        private ImageView img_article;
        private Button btn_article;
        private int index;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.article_search_details);
            // Create your application here

            string name;


            title_article = FindViewById< TextView >(Resource.Id.title_article);
            descp_article = FindViewById<TextView>(Resource.Id.descp_article);
            byLine_article = FindViewById<TextView>(Resource.Id.byLine_article);

            img_article = FindViewById<ImageView>(Resource.Id.img_article);
            btn_article = FindViewById<Button>(Resource.Id.btn_article);


            name = Intent.GetStringExtra("index" ?? "not recv");

            index = int.Parse(name);

            title_article.Text = $"{News.Headlines[index]}";
            descp_article.Text = $"{News.Description[index]}";
            byLine_article.Text = $"Article written {News.byline[index]}";


            img_article.SetImageBitmap(News.img[index]);


            btn_article.Click += Btn_article_Click;
        }

        private void Btn_article_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse($"{News.web_url[index]}");

            var ConIntent = new Intent(Intent.ActionView, uri);
            StartActivity(ConIntent);

        }
    }
}