using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace News_Project
{
    [Activity(Label = "MainPageDetails")]
    public class MainPageDetails : AppCompatActivity
    {

        private TextView title_article_main_page, descp_article_main_page, byLine_article_main_page;
        private Button btn_article_main_page;
        private ImageView img_article_main_page;
        private string url;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_page_details);
            // Create your application here


            title_article_main_page = FindViewById<TextView>(Resource.Id.title_article_main_page);
            descp_article_main_page = FindViewById<TextView>(Resource.Id.descp_article_main_page);
            byLine_article_main_page = FindViewById<TextView>(Resource.Id.byLine_article_main_page);

            Variables.looper = "Pause";

            btn_article_main_page = FindViewById<Button>(Resource.Id.btn_article_main_page);
            img_article_main_page = FindViewById<ImageView>(Resource.Id.img_article_main_page);



            string code = Intent.GetStringExtra("code" ?? "not recv");
            string str_index = Intent.GetStringExtra("index" ?? "not recv");


            int index = int.Parse(str_index);


            switch (code)
            {

                case "viewed_panel_1":

                    title_article_main_page.Text = NewsMainPage.viewed_title[index-1];
                    descp_article_main_page.Text = NewsMainPage.viewed_body_parah[index-1];
                    //byLine_article_main_page.Text = NewsMainPage.viewed_title[index];
                    img_article_main_page.SetImageBitmap(NewsMainPage.viewed_img[index-1]);
                    url = $"{NewsMainPage.viewed_URL_link[index-1]}";

                    break;

                case "viewed_panel_2":
                    title_article_main_page.Text = NewsMainPage.viewed_title[index - 1];
                    descp_article_main_page.Text = NewsMainPage.viewed_body_parah[index - 1];
                    //byLine_article_main_page.Text = NewsMainPage.viewed_title[index];
                    img_article_main_page.SetImageBitmap(NewsMainPage.viewed_img[index - 1]);
                    url = $"{NewsMainPage.viewed_URL_link[index - 1]}";

                    break;
                case "Emailed_panel_1":
                    title_article_main_page.Text = NewsMainPage.emailed_title[index - 1];
                    descp_article_main_page.Text = NewsMainPage.emailed_body_parah[index - 1];
                    //byLine_article_main_page.Text = NewsMainPage.viewed_title[index];
                    img_article_main_page.SetImageBitmap(NewsMainPage.emailed_img[index - 1]);
                    url = $"{NewsMainPage.emailed_URL_link[index - 1]}";
                    break;
                case "Emailed_panel_2":
                    title_article_main_page.Text = NewsMainPage.emailed_title[index - 1];
                    descp_article_main_page.Text = NewsMainPage.emailed_body_parah[index - 1];
                    //byLine_article_main_page.Text = NewsMainPage.viewed_title[index];
                    img_article_main_page.SetImageBitmap(NewsMainPage.emailed_img[index - 1]);
                    url = $"{NewsMainPage.emailed_URL_link[index - 1]}";
                    break;


                case "Shared_panel_1":
                    title_article_main_page.Text = NewsMainPage.shared_title[index - 1];
                    descp_article_main_page.Text = NewsMainPage.shared_body_parah[index - 1];
                    //byLine_article_main_page.Text = NewsMainPage.viewed_title[index];
                    img_article_main_page.SetImageBitmap(NewsMainPage.shared_img[index - 1]);
                    url = $"{NewsMainPage.shared_URL_link[index - 1]}";
                    break;
                case "Shared_panel_2":
                    title_article_main_page.Text = NewsMainPage.shared_title[index - 1];
                    descp_article_main_page.Text = NewsMainPage.shared_body_parah[index - 1];
                    //byLine_article_main_page.Text = NewsMainPage.viewed_title[index];
                    img_article_main_page.SetImageBitmap(NewsMainPage.shared_img[index - 1]);
                    url = $"{NewsMainPage.shared_URL_link[index - 1]}";
                    break;


                case "panel_1":
                    title_article_main_page.Text = NewsMainPage.title[index - 1];
                    descp_article_main_page.Text = NewsMainPage.body_parah[index - 1];
                    //byLine_article_main_page.Text = NewsMainPage.viewed_title[index];
                    img_article_main_page.SetImageBitmap(NewsMainPage.img[index - 1]);
                    url = $"{NewsMainPage.URL_link[index - 1]}";
                    break;
                case "panel_2":
                    title_article_main_page.Text = NewsMainPage.title[index - 1];
                    descp_article_main_page.Text = NewsMainPage.body_parah[index - 1];
                    //byLine_article_main_page.Text = NewsMainPage.viewed_title[index];
                    img_article_main_page.SetImageBitmap(NewsMainPage.img[index - 1]);
                    url = $"{NewsMainPage.URL_link[index - 1]}";
                    break;
            };

            btn_article_main_page.Click += Btn_article_main_page_Click;

        }

        private void Btn_article_main_page_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse($"{url}");

            var ConIntent = new Intent(Intent.ActionView, uri);
            StartActivity(ConIntent);


        }

        public override void OnBackPressed()
        {
            Variables.looper = "";
            base.OnBackPressed();
        }

    }
}