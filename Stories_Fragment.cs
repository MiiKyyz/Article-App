using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.IO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;



namespace News_and_articles
{
    [Obsolete]
    public class Stories_Fragment : AndroidX.Fragment.App.Fragment
    {

        Activity A = new Activity();
        TextView txt;
        LinearLayout panel;
        ImageButton Search;
        View view, layout;
        LayoutInflater inflater_pu;
        ViewGroup container_pu;
        public TextView Title, Des, written;
        ImageView img;
        Spinner spinner;
        string Items;
        NewsWork load_img;
        List<string> names = new List<string>()
        {
            "us",
            "home", 
            "automobiles", 
            "books", 
            "business", 
            "fashion", 
            "food", 
            "health", 
            "insider", 
            "magazine", 
            "movies", "nyregion", 
            "obituaries", "opinion", 
            "politics", "realestate", 
            "science", 
            "sports", "sundayreview", 
            "technology", "theater", 
            "t-magazine", "travel", 
            "upshot", "world", "arts"
        };
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            inflater_pu = inflater;
            container_pu = container;
            view = inflater.Inflate(Resource.Layout.stories_layout, container, false);

            load_img = new NewsWork();
            TextView s_txt = view.FindViewById<TextView>(Resource.Id.story_txt);

            TextFonts("TradeWinds-Regular.ttf", s_txt);


            Search = view.FindViewById<ImageButton>(Resource.Id.search_btn);
            spinner = view.FindViewById<Spinner>(Resource.Id.spinner);
            Search.Click += Search_Click;
            
            ArrayAdapter adapter = new ArrayAdapter(Context, Resource.Layout.dropdown_layout, Resource.Id.drop_txt, names);
            adapter.SetDropDownViewResource(Resource.Layout.dropdown_layout);
            spinner.Adapter = adapter;
            Search.Enabled = false;
            spinner.ItemSelected += Spinner_ItemSelected;
            spinner.Prompt = "Select Topic";
            stories("us");

            return view;

        }

   

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Items = names[e.Position];
        }

        public void Poster(LayoutInflater inflater, ViewGroup container)
        {
            panel = view.FindViewById<LinearLayout>(Resource.Id.stories_layout);
            
            
            layout = inflater.Inflate(Resource.Layout.news_panel,
            (ViewGroup)container.FindViewById(Resource.Layout.news_panel), false);


            Title = layout.FindViewById<TextView>(Resource.Id.title_txt);
            Des = layout.FindViewById<TextView>(Resource.Id.des_txt);
            img = layout.FindViewById<ImageView>(Resource.Id.popular_img);
            written = layout.FindViewById<TextView>(Resource.Id.by_txt);

            TextFonts("Acme-Regular.ttf", Title);
            TextFonts("Acme-Regular.ttf", Des);
            TextFonts("ALGER.TTF", written);

            panel.AddView(layout);

            




        }
        public void TextFonts(string FontType, TextView txt_fonts)
        {

            Typeface txt = Typeface.CreateFromAsset(Activity.Assets, FontType);

            txt_fonts.SetTypeface(txt, TypefaceStyle.Normal);

        }



        private void Search_Click(object sender, EventArgs e)
        {
            panel.RemoveAllViews();

            stories(Items);
           
            Search.Enabled = false;
        }


        


        public void Loading(string Code)
        {
            
            switch (Code)
            {

                case "load":
                    panel = view.FindViewById<LinearLayout>(Resource.Id.stories_layout);

                    View view_anim = inflater_pu.Inflate(Resource.Layout.loadin_panel,
                    (ViewGroup)container_pu.FindViewById(Resource.Layout.loadin_panel), false);

                    ImageView img = view_anim.FindViewById<ImageView>(Resource.Id.load_img);
                    NewsWork load = new NewsWork();
                    load.Loding(img);

                    panel.AddView(view_anim);
                    break;
                case "cancel":


                    View view_anim_cancel = inflater_pu.Inflate(Resource.Layout.loadin_panel,
                    (ViewGroup)container_pu.FindViewById(Resource.Layout.loadin_panel), false);

                    ImageView img_cancel = view_anim_cancel.FindViewById<ImageView>(Resource.Id.load_img);

                    NewsWork load_cancel = new NewsWork();
                    load_cancel.Stop(img_cancel);



                    panel.RemoveAllViews();

                    break;



            }

        }


     

        public async Task stories(string name)
        {

            string URL = $"https://api.nytimes.com/svc/topstories/v2/{name}.json?api-key=appGGmPxS3o5gGwDV5QdR2CjEIhY0UlD";

            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);


            Loading("load");
            try
            {
                string ALL_DATA = await client.GetStringAsync(URL);


                var data = JObject.Parse(ALL_DATA);

                //Log.Info("mikyyyy", ALL_DATA.ToString());


              
                Loading("cancel");
                foreach (var single in data["results"])
                {
                    
                    if (single["title"].ToString() != "")
                    {
                        //Log.Info("mikyyyy", single.ToString());

                        Poster(inflater_pu, container_pu);

                        Title.Text = single["title"].ToString();
                        Des.Text = $"{single["multimedia"][0]["caption"]} \n  \n {single["abstract"]}  ";
                        written.Text = $"Written {single["byline"]}";
                        Bitmap bitmap = load_img.GetBitmapFromUrl(single["multimedia"][0]["url"].ToString());
                        img.SetImageBitmap(bitmap);
                       
                    }

                    //Log.Info("mikyyyy", "--------------------------------------------------------------------");


                }
                Search.Enabled = true;
            }
            catch(Exception ex)
            {
                panel.RemoveAllViews();
                Poster(inflater_pu, container_pu);

                Title.Text = "Error";
                Des.Text = $"Internet Connection Error or Data was not found!  \n Try Again!";
                Log.Info("mikyyyy", $"{ex.Message}");
                Search.Enabled = true;
            }


        }

     
    }
}