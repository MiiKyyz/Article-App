using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using static Android.Provider.Settings;

namespace News_and_articles
{
    [Obsolete]
    public class Popular_Fragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        View view, poster, view_anim_load;
        Spinner spin_code, spin_days;
        LayoutInflater inflater_popular;
        ViewGroup container_popular;
        LinearLayout panel, loading_panel;
        public TextView Title, Des, written;
        ImageView img, img_load;
        NewsWork img_converter = new NewsWork();
        string code;
        int days;
        ImageButton btn;
        TextView title_Popular;
        List<string> list_code = new List<string>()
        {
            "emailed",
            "viewed",
            "shared"

        };
        List<int> list_days = new List<int>()
        {
            1,
            7,
            30

        };

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            
            view = inflater.Inflate(Resource.Layout.popular_layout, container, false);

            spin_code = view.FindViewById<Spinner>(Resource.Id.spinner_code);
            spin_days = view.FindViewById<Spinner>(Resource.Id.spinner_days);
            btn = view.FindViewById<ImageButton>(Resource.Id.search_btn);

            title_Popular = view.FindViewById<TextView>(Resource.Id.title_Popular);
            TextFonts("TradeWinds-Regular.ttf", title_Popular);


            btn.Click += Btn_Click;

            ArrayAdapter adapter_code = new ArrayAdapter(Context, Resource.Layout.dropdown_layout, Resource.Id.drop_txt, list_code); 
            adapter_code.SetDropDownViewResource(Resource.Layout.dropdown_layout);
            spin_code.Adapter = adapter_code;

            ArrayAdapter adapter_days = new ArrayAdapter(Context, Resource.Layout.dropdown_layout, Resource.Id.drop_txt, list_days);
            adapter_days.SetDropDownViewResource(Resource.Layout.dropdown_layout);
            spin_days.Adapter = adapter_days;


            spin_code.ItemSelected += Spin_code_ItemSelected;
            spin_days.ItemSelected += Spin_days_ItemSelected;

            btn.Enabled = false;

            inflater_popular = inflater;
            container_popular = container;

            loading_panel = view.FindViewById<LinearLayout>(Resource.Id.popular_layout);
            view_anim_load = inflater_popular.Inflate(Resource.Layout.loadin_panel,
                    (ViewGroup)container_popular.FindViewById(Resource.Layout.loadin_panel), false);
            img_load = view_anim_load.FindViewById<ImageView>(Resource.Id.load_img);

            Popular("viewed", 1);

            return view;
            
        }
        public void TextFonts(string FontType, TextView txt_fonts)
        {

            Typeface txt = Typeface.CreateFromAsset(Activity.Assets, FontType);

            txt_fonts.SetTypeface(txt, TypefaceStyle.Normal);

        }

        private void Btn_Click(object sender, EventArgs e)
        {

            panel.RemoveAllViews();
            btn.Enabled = false;
            Popular(code, days);
        }

        private void Spin_days_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            code = list_code[e.Position];
        }

        private void Spin_code_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            days = list_days[e.Position];
        }

        public void Poster(LayoutInflater inflater, ViewGroup container)
        {

            panel = view.FindViewById<LinearLayout>(Resource.Id.popular_layout);

            poster = inflater.Inflate(Resource.Layout.news_panel, 
                (ViewGroup)container.FindViewById(Resource.Layout.news_panel), false);


            Title = poster.FindViewById<TextView>(Resource.Id.title_txt);
            Des = poster.FindViewById<TextView>(Resource.Id.des_txt);
            written = poster.FindViewById<TextView>(Resource.Id.by_txt);
            img = poster.FindViewById<ImageView>(Resource.Id.popular_img);

            TextFonts("Acme-Regular.ttf", Title);
            TextFonts("Acme-Regular.ttf", Des);
            TextFonts("ALGER.TTF", written);


            panel.AddView(poster);

        }
        public void Loading(string Code)
        {

            switch (Code)
            {

                case "load":
                    
                    img_converter.Loding(img_load);

                    loading_panel.AddView(view_anim_load);
                    break;
                case "cancel":


                 
                    img_converter.Stop(img_load);



                    loading_panel.RemoveAllViews();

                    break;



            }

        }

        public async void Popular(string code, int days)
        {


            switch (code)
            {
                case "emailed":

                    string URL = $"https://api.nytimes.com/svc/mostpopular/v2/emailed/{days}.json?api-key=appGGmPxS3o5gGwDV5QdR2CjEIhY0UlD";

                    var handle = new HttpClientHandler();

                    HttpClient client = new HttpClient(handle);
                    Loading("load");
                    try
                    {

                        string ALL_DATA = await client.GetStringAsync(URL);

                        var data = JObject.Parse(ALL_DATA);



                        Loading("cancel");
                        foreach (var item in data["results"])
                        {

                            if (item["title"].ToString() != "" && item["media"].ToArray().Length != 0)
                            {
                                //Log.Info("news", $"{item}");

                                Poster(inflater_popular, container_popular);

                                Title.Text = item["title"].ToString();
                                Des.Text = $"{item["abstract"]}";
                                written.Text = item["byline"].ToString();
                                Bitmap bitmap = img_converter.GetBitmapFromUrl(item["media"][0]["media-metadata"][2]["url"].ToString());
                                img.SetImageBitmap(bitmap);


                            }
                            
                        }
                        btn.Enabled = true;

                    }
                    catch(Exception ex)
                    {

                        //Log.Info("ERRORR", $"{ex.Message}");
                        Poster(inflater_popular, container_popular);

                        Title.Text = "Error";
                        Des.Text = $"Internet Connection Error or Data was not found!  \n Try Again!";
                        btn.Enabled = true;

                    }

                    break;
                case "shared":

                    string URL_shared = $"https://api.nytimes.com/svc/mostpopular/v2/shared/{days}/facebook.json?api-key=appGGmPxS3o5gGwDV5QdR2CjEIhY0UlD";

                    var handle_shared = new HttpClientHandler();

                    HttpClient client_shared = new HttpClient(handle_shared);
                    Loading("load");
                    try
                    {

                        string ALL_DATA = await client_shared.GetStringAsync(URL_shared);

                        var data = JObject.Parse(ALL_DATA);



                        Loading("cancel");
                        foreach (var item in data["results"])
                        {

                            if (item["title"].ToString() != "" && item["media"].ToArray().Length != 0)
                            {
                                //Log.Info("news", $"{item}");

                                Poster(inflater_popular, container_popular);

                                Title.Text = item["title"].ToString();
                                Des.Text = $"{item["abstract"]}";
                                written.Text = item["byline"].ToString();
                                Bitmap bitmap = img_converter.GetBitmapFromUrl(item["media"][0]["media-metadata"][2]["url"].ToString());
                                img.SetImageBitmap(bitmap);


                            }

                        }
                        btn.Enabled = true;
                    }
                    catch (Exception ex)
                    {

                        //Log.Info("ERRORR", $"{ex.Message}");
                        Poster(inflater_popular, container_popular);

                        Title.Text = "Error";
                        Des.Text = $"Internet Connection Error or Data was not found!  \n Try Again!";

                        btn.Enabled = true;
                    }



                    break;
                case "viewed":

                    string URL_viewed = $"https://api.nytimes.com/svc/mostpopular/v2/viewed/{days}.json?api-key=appGGmPxS3o5gGwDV5QdR2CjEIhY0UlD";

                    var handle_viewed = new HttpClientHandler();

                    HttpClient client_viewed = new HttpClient(handle_viewed);
                    Loading("load");
                    try
                    {

                        string ALL_DATA = await client_viewed.GetStringAsync(URL_viewed);

                        var data = JObject.Parse(ALL_DATA);



                        Loading("cancel");
                        foreach (var item in data["results"])
                        {

                            if (item["title"].ToString() != "" && item["media"].ToArray().Length != 0)
                            {
                                //Log.Info("news", $"{item}");

                                Poster(inflater_popular, container_popular);

                                Title.Text = item["title"].ToString();
                                Des.Text = $"{item["abstract"]}";
                                written.Text = item["byline"].ToString();
                                Bitmap bitmap = img_converter.GetBitmapFromUrl(item["media"][0]["media-metadata"][2]["url"].ToString());
                                img.SetImageBitmap(bitmap);


                            }

                        }
                        btn.Enabled = true;
                    }
                    catch (Exception ex)
                    {

                        //Log.Info("ERRORR", $"{ex.Message}");
                        Poster(inflater_popular, container_popular);

                        Title.Text = "Error";
                        Des.Text = $"Internet Connection Error or Data was not found!  \n Try Again!";
                        btn.Enabled = true;

                    }


                    break;

            }



        }


    }
}