using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static Android.Views.ViewGroup;
using static Java.Util.Jar.Attributes;

namespace News_and_articles
{
    [Obsolete]
    public class Newspaper_Fragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        LinearLayout inyt, nyt;
        View view, Poster_inyt, Poster_nyt, view_nyt;
        public TextView Title_nyt, Des_nyt, written_nyt, Title_inyt, Des_inyt, written_inyt;
        ImageView img_inyt, img_nyt;
        LayoutInflater inflater_news;
        ViewGroup container_news;
        NewsWork load_img;
        ImageView img_view_nyt;
        NewsWork load_nyt;
        Spinner spinner;
        string item;
        ImageButton btn;
        TextView title_Newswire;
        List<string> items_names = new List<string>();
        public override  View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            inflater_news = inflater;
            container_news = container;
            view = inflater.Inflate(Resource.Layout.newspaper_layout, container, false);

            title_Newswire = view.FindViewById<TextView>(Resource.Id.title);

            TextFonts("TradeWinds-Regular.ttf", title_Newswire);


            btn = view.FindViewById<ImageButton>(Resource.Id.search_btn_new);
            btn.Click += Btn_Click;
           

            spinner = view.FindViewById<Spinner>(Resource.Id.spinner_new);
            Log.Debug("names", "mmmmmmmmmmmmm");

            ContentName();

           

            
             spinner.ItemSelected += Spinner_ItemSelected;

            load_img = new NewsWork();
            view_nyt = inflater_news.Inflate(Resource.Layout.loadin_panel,
                    (ViewGroup)container_news.FindViewById(Resource.Layout.loadin_panel), false);
            nyt = view.FindViewById<LinearLayout>(Resource.Id.nyt_layout);
            inyt = view.FindViewById<LinearLayout>(Resource.Id.inyt_layout);
            img_view_nyt = view_nyt.FindViewById<ImageView>(Resource.Id.load_img);
            load_nyt = new NewsWork();

            btn.Enabled = false;
            NewsWire_nyt("world");
            NewsWire_inyt("world");

            return view;

           
        }
     

        private void Btn_Click(object sender, EventArgs e)
        {
            nyt.RemoveAllViews();
            inyt.RemoveAllViews();

            NewsWire_nyt(item);
            NewsWire_inyt(item);
            btn.Enabled = false;


        }

        private async void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            item = items_names[e.Position];
            //Toast.MakeText(Context, item, ToastLength.Short).Show();
        }

        public void Panel_nyt(LayoutInflater inflater, ViewGroup container)
        {

            //nyt = view.FindViewById<LinearLayout>(Resource.Id.nyt_layout);



            Poster_nyt = inflater.Inflate(Resource.Layout.news_panel,
            (ViewGroup)container.FindViewById(Resource.Layout.news_panel), false);




            Title_nyt = Poster_nyt.FindViewById<TextView>(Resource.Id.title_txt);
            Des_nyt = Poster_nyt.FindViewById<TextView>(Resource.Id.des_txt);
            img_nyt = Poster_nyt.FindViewById<ImageView>(Resource.Id.popular_img);
            written_nyt = Poster_nyt.FindViewById<TextView>(Resource.Id.by_txt);


            TextFonts("Acme-Regular.ttf", Title_nyt);
            TextFonts("Acme-Regular.ttf", Des_nyt);
            TextFonts("ALGER.TTF", written_nyt);


            nyt.AddView(Poster_nyt);
        }


        public void Panel_inyt(LayoutInflater inflater, ViewGroup container)
        {


           

            //inyt = view.FindViewById<LinearLayout>(Resource.Id.inyt_layout);
            Poster_inyt = inflater.Inflate(Resource.Layout.news_panel,
            (ViewGroup)container.FindViewById(Resource.Layout.news_panel), false);

            Title_inyt = Poster_inyt.FindViewById<TextView>(Resource.Id.title_txt);
            Des_inyt = Poster_inyt.FindViewById<TextView>(Resource.Id.des_txt);
            img_inyt = Poster_inyt.FindViewById<ImageView>(Resource.Id.popular_img);
            written_inyt = Poster_inyt.FindViewById<TextView>(Resource.Id.by_txt);


            TextFonts("Acme-Regular.ttf", Title_inyt);
            TextFonts("Acme-Regular.ttf", Des_inyt);
            TextFonts("ALGER.TTF", written_inyt);

            inyt.AddView(Poster_inyt);

             

        }




        public void Loading(string Code)
        {

            switch (Code)
            {

                case "load_inyt":
                    inyt = view.FindViewById<LinearLayout>(Resource.Id.inyt_layout);
                    

                    View view_inyt = inflater_news.Inflate(Resource.Layout.loadin_panel,
                    (ViewGroup)container_news.FindViewById(Resource.Layout.loadin_panel), false);

                    ImageView img_view_inyt = view_inyt.FindViewById<ImageView>(Resource.Id.load_img);



                    NewsWork load_inyt = new NewsWork();

                    load_inyt.Loding(img_view_inyt);

                    inyt.AddView(view_inyt);
                    
                    break;

                case "load_nyt":

                    

                    load_nyt.Loding(img_view_nyt);
                    nyt.AddView(view_nyt);

                    break;

                case "cancel_nyt":

                    load_nyt.Stop(img_view_nyt);
                    nyt.RemoveAllViews();

                    break;
                case "cancel_inyt":


                    View view_anim_cancel_inyt = inflater_news.Inflate(Resource.Layout.loadin_panel,
                    (ViewGroup)container_news.FindViewById(Resource.Layout.loadin_panel), false);

                    

                    ImageView img_cancel_inyt = view_anim_cancel_inyt.FindViewById<ImageView>(Resource.Id.load_img);
                    NewsWork load_cancel = new NewsWork();
                
                    load_cancel.Stop(img_cancel_inyt);



                    inyt.RemoveAllViews();
                    

                    break;



            }

        }



        public async Task NewsWire_nyt(string code)
        {

            string URL_nyt = $"https://api.nytimes.com/svc/news/v3/content/nyt/{code}.json?api-key=appGGmPxS3o5gGwDV5QdR2CjEIhY0UlD";
            
            
            var handler_nyt = new HttpClientHandler();

            
            HttpClient client_nyt = new HttpClient(handler_nyt);
            Loading("load_nyt");
            try
            {
                //nyt
                string ALL_DATA_URL_nyt = await client_nyt.GetStringAsync(URL_nyt);
               
                var data_nyt = JObject.Parse(ALL_DATA_URL_nyt);

                Loading("cancel_nyt");
                foreach (var single_nyt in data_nyt["results"])
                {

                    if(single_nyt["title"].ToString() != "" && single_nyt["multimedia"].ToString() != "")
                    {

                        //Log.Info("news nyt:", single_nyt.ToString());


                        Panel_nyt(inflater_news, container_news);

                        Title_nyt.Text = single_nyt["title"].ToString();
                        Des_nyt.Text = $"{single_nyt["multimedia"][2]["caption"]} \n  \n {single_nyt["abstract"]}  ";
                        written_nyt.Text = single_nyt["byline"].ToString();
                        Bitmap bitmap = load_img.GetBitmapFromUrl(single_nyt["multimedia"][2]["url"].ToString());
                        img_nyt.SetImageBitmap(bitmap);
                        
                    }

                    //Log.Info("news:", "----------------------------------------");
                }
                btn.Enabled = true;


            }
            catch(Exception ex)
            {

                Loading("cancel_nyt");
                Log.Info("news:", $"error: {ex.Message}");
                Panel_nyt(inflater_news, container_news);
                Title_nyt.Text = "Error on Finding The News";
                Des_nyt.Text = $"Internet Connection Error or Data was not found!  \n Try Again!";

                btn.Enabled = true;
                img_nyt.SetBackgroundResource(Resource.Drawable.Icon);

            }


        }



        public async Task NewsWire_inyt(string code)
        {
            string URL_inyt = $"https://api.nytimes.com/svc/news/v3/content/inyt/{code}.json?api-key=appGGmPxS3o5gGwDV5QdR2CjEIhY0UlD";

            var handler_inyt = new HttpClientHandler();

            HttpClient client_inyt = new HttpClient(handler_inyt);

            Loading("load_inyt");
            try
            {
                string ALL_DATA_URL_inyt = await client_inyt.GetStringAsync(URL_inyt);
                var data_inyt = JObject.Parse(ALL_DATA_URL_inyt);

                Loading("cancel_inyt");
                foreach (var single in data_inyt["results"])
                {

                    if (single["title"].ToString() != "" && single["multimedia"].ToString() != "")
                    {

                        //Log.Info("news inyt:", single["title"].ToString());


                        Panel_inyt(inflater_news, container_news);
                        Title_inyt.Text = single["title"].ToString();
                        Des_inyt.Text = $"{single["multimedia"][0]["caption"]} \n  \n {single["abstract"]}  ";
                        written_inyt.Text = single["byline"].ToString();
                        Bitmap bitmap = load_img.GetBitmapFromUrl(single["multimedia"][2]["url"].ToString());
                        img_inyt.SetImageBitmap(bitmap);
                        
                    }
                    
                    //Log.Info("news:", "----------------------------------------");
                }
                btn.Enabled = true;
            }
            catch(Exception ex)
            {
                Loading("cancel_inyt");
                Panel_inyt(inflater_news, container_news);
                Title_inyt.Text = "Error on Finding The News";
                Des_inyt.Text = $"Internet Connection Error or Data was not found!  \n Try Again!";


                img_inyt.SetBackgroundResource(Resource.Drawable.Icon);
                btn.Enabled = true;

            }


        }

        public async Task<List<string>> ContentName()
        {

            string URL = "https://api.nytimes.com/svc/news/v3/content/section-list.json?api-key=appGGmPxS3o5gGwDV5QdR2CjEIhY0UlD";

            var handler = new HttpClientHandler();

            HttpClient client = new HttpClient(handler);
            
            try
            {

                string ALL_DATA= await client.GetStringAsync(URL);

                var data = JObject.Parse(ALL_DATA);


                foreach(var name in data["results"])
                {

                    //Log.Info("news:", name["section"].ToString());



                    items_names.Add(name["section"].ToString());
                }
                ArrayAdapter adapter = new ArrayAdapter(Context, Resource.Layout.dropdown_layout, Resource.Id.drop_txt, items_names);
                adapter.SetDropDownViewResource(Resource.Layout.dropdown_layout);
                spinner.Adapter = adapter;

                


            }
            catch
            {


                Log.Info("news adapter:", "error");

            }

            return items_names;

        }

        public void TextFonts(string FontType, TextView txt_fonts)
        {

            Typeface txt = Typeface.CreateFromAsset(Activity.Assets, FontType);

            txt_fonts.SetTypeface(txt, TypefaceStyle.Normal);

        }

    }
}