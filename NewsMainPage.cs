using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.View;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;





namespace News_Project
{
    public class NewsMainPage
    {


        public static bool cloase_threads = true;

        //months news variables
        private LayoutInflater layoutInflater_1, layoutInflater_2;
        private View Panel_1, Panel_2;
        private ImageView img_1, img_2;
        private TextView title_1, title_2, parag_1, parag_2;
        public static List<string> title = new List<string>();
        public static List<string> URL_link = new List<string>();
        public static List<string> body_parah = new List<string>();
        public static List<Bitmap> img = new List<Bitmap>();



        // shared news variables
        private LayoutInflater shared_layoutInflater_1, shared_layoutInflater_2;
        private View shared_Panel_1, shared_Panel_2;
        private ImageView shared_img_1, shared_img_2;
        private TextView shared_title_1, shared_title_2, shared_parag_1, shared_parag_2;
        public static List<string> shared_title = new List<string>();
        public static List<string> shared_URL_link = new List<string>();
        public static List<string> shared_body_parah = new List<string>();
        public static List<Bitmap> shared_img = new List<Bitmap>();

        // emailed news variables

        private LayoutInflater emailed_layoutInflater_1, emailed_layoutInflater_2;
        private View emailed_Panel_1, emailed_Panel_2;
        private ImageView emailed_img_1, emailed_img_2;
        private TextView emailed_title_1, emailed_title_2, emailed_parag_1, emailed_parag_2;
        public static List<string> emailed_title = new List<string>();
        public static List<string> emailed_body_parah = new List<string>();
        public static List<string> emailed_URL_link = new List<string>();
        public static List<Bitmap> emailed_img = new List<Bitmap>();
        //news viewed

        private LayoutInflater viewed_layoutInflater_1, viewed_layoutInflater_2;
        private View viewed_Panel_1, viewed_Panel_2;
        private ImageView viewed_img_1, viewed_img_2;
        private TextView viewed_title_1, viewed_title_2, viewed_parag_1, viewed_parag_2;
        public static List<string> viewed_title = new List<string>();
        public static List<string> viewed_body_parah = new List<string>();
        public static List<string> viewed_URL_link = new List<string>();
        public static List<Bitmap> viewed_img = new List<Bitmap>();




        private const int Seconds = 10000;
        protected private string URL_MonthNews, URL_Most_Popular, URL_Emailed_ews, URL_View_News;


        int Switcher_Panel = 0;
        public static bool State;
        public static int Loop_State = 0;
        private ViewSwitcher viewSwitcher, viewSwitcher_shared, view_switcher_emailed, view_switcher_viewed;

        Context context;

        Activity activity;
        public void NewsPanel(Activity activity, Context context, ViewGroup viewGroup, ViewSwitcher viewSwitcher, ViewSwitcher viewSwitcher_shared, ViewSwitcher view_switcher_emailed, ViewSwitcher view_switcher_viewed)
        {
            viewSwitcher.RemoveAllViews();
            viewSwitcher_shared.RemoveAllViews();
            view_switcher_emailed.RemoveAllViews();
            view_switcher_viewed.RemoveAllViews();

            this.activity = activity;
            this.context = context;

            this.view_switcher_viewed = view_switcher_viewed;
            this.view_switcher_emailed = view_switcher_emailed;
            this.viewSwitcher = viewSwitcher;
            this.viewSwitcher_shared = viewSwitcher_shared;

            

            Loop_State = 0;

            //panel of the month


            layoutInflater_1 = LayoutInflater.FromContext(context);
            layoutInflater_2 = LayoutInflater.FromContext(context);


            Panel_1 = layoutInflater_1.Inflate(Resource.Layout.panel_1, viewGroup, false);
            Panel_2 = layoutInflater_2.Inflate(Resource.Layout.panel_2, viewGroup, false);

            title_1 = Panel_1.FindViewById<TextView>(Resource.Id.title_panel_1);
            title_2 = Panel_2.FindViewById<TextView>(Resource.Id.title_panel_2);


            img_1 = Panel_1.FindViewById<ImageView>(Resource.Id.img_1);
            img_2 = Panel_2.FindViewById<ImageView>(Resource.Id.img_2);
            

            parag_1 = Panel_1.FindViewById<TextView>(Resource.Id.parag_panel_1);
            parag_2 = Panel_2.FindViewById<TextView>(Resource.Id.parag_panel_2);

            Panel_1.Click += Panel_1_Click;
            Panel_2.Click += Panel_2_Click;

            title_1.Text = $"Loading...";
            parag_1.Text = $"Loading...";


            title_2.Text = $"Loading...";
            parag_2.Text = $"Loading...";

            viewSwitcher.AddView(Panel_1);
            viewSwitcher.AddView(Panel_2);


            //panel most popular shared



            shared_layoutInflater_1 = LayoutInflater.FromContext(context);
            shared_layoutInflater_2 = LayoutInflater.FromContext(context);

            shared_Panel_1 = layoutInflater_1.Inflate(Resource.Layout.share_panel_1, viewGroup, false);
            shared_Panel_2 = layoutInflater_2.Inflate(Resource.Layout.share_panel_2, viewGroup, false);

            shared_Panel_1.Click += Shared_Panel_1_Click;
            shared_Panel_2.Click += Shared_Panel_2_Click;

            shared_title_1 = shared_Panel_1.FindViewById<TextView>(Resource.Id.shared_title_panel_1);
            shared_title_2 = shared_Panel_2.FindViewById<TextView>(Resource.Id.shared_title_panel_2);

            shared_img_1 = shared_Panel_1.FindViewById<ImageView>(Resource.Id.shared_img_1);
            shared_img_2 = shared_Panel_2.FindViewById<ImageView>(Resource.Id.shared_img_2);

            



            shared_parag_1 = shared_Panel_1.FindViewById<TextView>(Resource.Id.shared_parag_panel_1);
            shared_parag_2 = shared_Panel_2.FindViewById<TextView>(Resource.Id.shared_parag_panel_2);

            shared_title_1.Text = $"Loading...";
            shared_parag_1.Text = $"Loading...";


            shared_title_2.Text = $"Loading...";
            shared_parag_2.Text = $"Loading...";

            viewSwitcher_shared.AddView(shared_Panel_1);
            viewSwitcher_shared.AddView(shared_Panel_2);

            //emailed

            

            emailed_layoutInflater_1 = LayoutInflater.FromContext(context);
            emailed_layoutInflater_2 = LayoutInflater.FromContext(context);

            emailed_Panel_1 = layoutInflater_1.Inflate(Resource.Layout.emailed_panel_1, viewGroup, false);
            emailed_Panel_2 = layoutInflater_2.Inflate(Resource.Layout.emailed_panel_2, viewGroup, false);

            emailed_Panel_1.Click += Emailed_Panel_1_Click;
            emailed_Panel_2.Click += Emailed_Panel_2_Click;

            emailed_title_1 = emailed_Panel_1.FindViewById<TextView>(Resource.Id.emailed_title_panel_1);
            emailed_title_2 = emailed_Panel_2.FindViewById<TextView>(Resource.Id.emailed_title_panel_2);

            emailed_img_1 = emailed_Panel_1.FindViewById<ImageView>(Resource.Id.emailed_img_1);
            emailed_img_2 = emailed_Panel_2.FindViewById<ImageView>(Resource.Id.emailed_img_2);

           


            emailed_parag_1 = emailed_Panel_1.FindViewById<TextView>(Resource.Id.emailed_parag_panel_1);
            emailed_parag_2 = emailed_Panel_2.FindViewById<TextView>(Resource.Id.emailed_parag_panel_2);

            emailed_title_1.Text = $"Loading...";
            emailed_parag_1.Text = $"Loading...";


            emailed_title_2.Text = $"Loading...";
            emailed_parag_2.Text = $"Loading...";

            view_switcher_emailed.AddView(emailed_Panel_1);
            view_switcher_emailed.AddView(emailed_Panel_2);



            //viewed 

            viewed_layoutInflater_1 = LayoutInflater.FromContext(context);
            viewed_layoutInflater_2 = LayoutInflater.FromContext(context);

            viewed_Panel_1 = layoutInflater_1.Inflate(Resource.Layout.panel_1, viewGroup, false);
            viewed_Panel_2 = layoutInflater_2.Inflate(Resource.Layout.panel_2, viewGroup, false);

            viewed_Panel_1.Click += Viewed_Panel_1_Click;
            viewed_Panel_2.Click += Viewed_Panel_2_Click;

            viewed_title_1 = viewed_Panel_1.FindViewById<TextView>(Resource.Id.title_panel_1);
            viewed_title_2 = viewed_Panel_2.FindViewById<TextView>(Resource.Id.title_panel_2);

            viewed_img_1 = viewed_Panel_1.FindViewById<ImageView>(Resource.Id.img_1);
            viewed_img_2 = viewed_Panel_2.FindViewById<ImageView>(Resource.Id.img_2);


           


            viewed_parag_1 = viewed_Panel_1.FindViewById<TextView>(Resource.Id.parag_panel_1);
            viewed_parag_2 = viewed_Panel_2.FindViewById<TextView>(Resource.Id.parag_panel_2);

            viewed_title_1.Text = $"Loading...";
            viewed_parag_1.Text = $"Loading...";


            viewed_title_2.Text = $"Loading...";
            viewed_parag_2.Text = $"Loading...";

            view_switcher_viewed.AddView(viewed_Panel_1);
            view_switcher_viewed.AddView(viewed_Panel_2);

            
        }
        private Intent next;
        private ActivityOptionsCompat activityOptionsCompat;
        private void Viewed_Panel_2_Click(object sender, EventArgs e)
        {
            if (Loop_State == 4)
            {
                next = new Intent(context, typeof(MainPageDetails));
                next.PutExtra("code", $"viewed_panel_2");
                next.PutExtra("index", $"{viewed_panel_counter}");
                activityOptionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(activity, viewed_img_2, ViewCompat.GetTransitionName(viewed_img_2));
                context.StartActivity(next, activityOptionsCompat.ToBundle());
            }
        }

        private void Viewed_Panel_1_Click(object sender, EventArgs e)
        {
            if (Loop_State == 4)
            {
                next = new Intent(context, typeof(MainPageDetails));
                next.PutExtra("code", $"viewed_panel_1"); 
                next.PutExtra("index", $"{viewed_panel_counter}");
                activityOptionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(activity, viewed_img_1, ViewCompat.GetTransitionName(viewed_img_1));
                context.StartActivity(next, activityOptionsCompat.ToBundle());

            }
        }

        private void Emailed_Panel_2_Click(object sender, EventArgs e)
        {
            if (Loop_State == 4)
            {
                next = new Intent(context, typeof(MainPageDetails));
                next.PutExtra("code", $"Emailed_panel_2");
                next.PutExtra("index", $"{emailed_panel_counter}");
                activityOptionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(activity, emailed_img_2, ViewCompat.GetTransitionName(emailed_img_2));
                context.StartActivity(next, activityOptionsCompat.ToBundle());

            }
        }

        private void Emailed_Panel_1_Click(object sender, EventArgs e)
        {
            if (Loop_State == 4)
            {
                next = new Intent(context, typeof(MainPageDetails));
                next.PutExtra("code", $"Emailed_panel_1");
                next.PutExtra("index", $"{emailed_panel_counter}");
                activityOptionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(activity, emailed_img_1, ViewCompat.GetTransitionName(emailed_img_1));
                context.StartActivity(next, activityOptionsCompat.ToBundle());

            }
        }

        private void Shared_Panel_2_Click(object sender, EventArgs e)
        {
            if (Loop_State == 4)
            {

                next = new Intent(context, typeof(MainPageDetails));
                next.PutExtra("code", $"Shared_panel_2");
                next.PutExtra("index", $"{shared_paner_counter}");
                activityOptionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(activity, shared_img_2, ViewCompat.GetTransitionName(shared_img_2));
                context.StartActivity(next, activityOptionsCompat.ToBundle());
            }
        }

        private void Shared_Panel_1_Click(object sender, EventArgs e)
        {
            if (Loop_State == 4)
            {
                next = new Intent(context, typeof(MainPageDetails));
                next.PutExtra("code", $"Shared_panel_1");
                next.PutExtra("index", $"{shared_paner_counter}");
                activityOptionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(activity, shared_img_1, ViewCompat.GetTransitionName(shared_img_1));
                context.StartActivity(next, activityOptionsCompat.ToBundle());

            }
        }

        private void Panel_2_Click(object sender, EventArgs e)
        {
            if (Loop_State == 4)
            {

                next = new Intent(context, typeof(MainPageDetails));
                next.PutExtra("code", $"panel_1");
                next.PutExtra("index", $"{panel_counter}");
                activityOptionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(activity,img_2, ViewCompat.GetTransitionName(img_2));
                context.StartActivity(next, activityOptionsCompat.ToBundle());
            }
        }

        private void Panel_1_Click(object sender, EventArgs e)
        {
            if (Loop_State == 4)
            {
                next = new Intent(context, typeof(MainPageDetails));
                next.PutExtra("code", $"panel_1");
                next.PutExtra("index", $"{panel_counter}");
                activityOptionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(activity, img_1, ViewCompat.GetTransitionName(img_1));
                context.StartActivity(next, activityOptionsCompat.ToBundle());

            }
        }


        public async Task MainNews()
        {


            //cloase_threads = true;
            _ = ViewedNews();
            _ = EmailedNew();
            _ = MostPopular();
            _ = MonthNews();


            try
            {
                

               

                


                
         
            }
            catch(Exception e)
            {

                Log.Info("errorrrrrrrrr", e.Message);
                // panel 1



                title_1.Text = $"No Tilte";
                parag_1.Text = $"Error Internet Connection";

                img_1.SetImageResource(Resource.Drawable.error);




                //shared panel 1

                shared_title_1.Text = $"No Tilte";
                shared_parag_1.Text = $"Error Internet Connection";

                shared_img_1.SetImageResource(Resource.Drawable.error);


                // email panel 1


                emailed_title_1.Text = $"No Tilte";
                emailed_parag_1.Text = $"Error Internet Connection";

                emailed_img_1.SetImageResource(Resource.Drawable.error);



                //viewed panel 1

                viewed_title_1.Text = $"No Tilte";
                viewed_parag_1.Text = $"Error Internet Connection";

                viewed_img_1.SetImageResource(Resource.Drawable.error);
            }

            
        }
        
        private async Task MonthNews()
        {

            AnimationManager anim = new AnimationManager();
            anim.LoadingAnimation(new ImageView[] { img_1 , shared_img_1 , viewed_img_1 , emailed_img_1 }).Start();
        

            URL_MonthNews = $"https://api.nytimes.com/svc/archive/v1/{DateTime.Now.Year}/{DateTime.Now.Month}.json?api-key=sGOTcLaAfde9AGHqNG11ob8wPB6AtfMq";

           

            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string All_Data = await client.GetStringAsync(URL_MonthNews);
            var data_in_string = JObject.Parse(All_Data);
            
            int limit = 0;

            await Task.Run(() =>
            {

                while (cloase_threads)
                {

                    

                    foreach (var item in data_in_string["response"]["docs"])
                    {


                        

                        try
                        {
                            if (item["multimedia"].ToArray().Length != 0)
                            {


                                title.Add(item["headline"]["main"].ToString());
                                Bitmap bitmap = ImgWebsite($"https://www.nytimes.com/{item["multimedia"][0]["legacy"]["xlarge"]}");
                                img.Add(bitmap);
                                string paragraph = $"{item["lead_paragraph"]}";
                                body_parah.Add(paragraph);
                                URL_link.Add(item["web_url"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {

                            Bitmap bitmap = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.no_img);
                            img.Add(bitmap);
                        
                        }
                        if (limit == 20)
                        {


                            break;

                        }

                        limit++;

                    }

                    break;
                }


                if (!cloase_threads)
                {

                    Log.Info("break", $"Broke");
                    Loop_State = 0;

                }


               

            });
            
            if (cloase_threads)
            {

                Loop_State += 1;
                anim.Canceler();
                //Log.Info("Doneeeeeeeeeeeeeeeeeeeeeeee", $"Done Data 4:{Loop_State}");
                if (Loop_State == 4)
                {
                    Switcher_Panel = 1;
                    State = true;

                    await TimerAnimation();


                    
                }
            }

            


        }

        public async Task MostPopular()
        {

            URL_Most_Popular = "https://api.nytimes.com/svc/mostpopular/v2/shared/1/facebook.json?api-key=sGOTcLaAfde9AGHqNG11ob8wPB6AtfMq";
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string All_Data = await client.GetStringAsync(URL_Most_Popular);
            var data_in_string = JObject.Parse(All_Data);

            
            
            int limit = 0;

            await Task.Run(() =>
            {

                while (cloase_threads)
                {
                    
                    foreach (var item in data_in_string["results"])
                    {

                        
                        try
                        {
                            if (item["media"].ToArray().Length != 0)
                            {
                                shared_title.Add($"{item["title"]}");
                                shared_body_parah.Add($"{item["media"][0]["caption"]}");
                                Bitmap shared_bitmap = ImgWebsite($"{item["media"][0]["media-metadata"][2]["url"]}");
                                shared_img.Add(shared_bitmap);
                                shared_URL_link.Add($"{item["url"]}");


                            }
                        }
                        catch (Exception ex)
                        {

                            Bitmap bitmap = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.no_img);
                            shared_img.Add(bitmap);
                            Log.Info("Doneeeeeeeeeeeeeeeeeeeeeeee", $"Done Data 2{ex.Message}");
                        }
                        if (limit == 20)
                        {


                            break;

                        }

                        limit++;
                    }

                    break;
                }
                if (!cloase_threads)
                {

                    Log.Info("break", $"Broke");
                    Loop_State = 0;

                }
            });

            if (cloase_threads)
            {

                Loop_State += 1;
                //Log.Info("Doneeeeeeeeeeeeeeeeeeeeeeee", $"Done Data 3:{Loop_State}");
                if (Loop_State == 4)
                {
                    Switcher_Panel = 1;
                    State = true;
                    await TimerAnimation();

                }
            }

            
        } 

        private async Task EmailedNew()
        {

            URL_Emailed_ews = "https://api.nytimes.com/svc/mostpopular/v2/emailed/1.json?api-key=sGOTcLaAfde9AGHqNG11ob8wPB6AtfMq";
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string All_Data = await client.GetStringAsync(URL_Emailed_ews);
            var data_in_string = JObject.Parse(All_Data);


            

            int limit = 0;
            await Task.Run(() =>
            {
                
                while (cloase_threads)
                {
                    
                    foreach (var item in data_in_string["results"])
                    {


                       



                        try
                        {
                            if (item["media"].ToArray().Length != 0)
                            {


                                emailed_title.Add($"{item["title"]}");
                                emailed_body_parah.Add($"{item["abstract"]}");
                                emailed_URL_link.Add($"{item["url"]}");
                                Bitmap emailed_bitmap = ImgWebsite($"{item["media"][0]["media-metadata"][2]["url"]}");
                                emailed_img.Add(emailed_bitmap);




                            }
                        }
                        catch(Exception ex)
                        {

                            Bitmap bitmap = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.no_img);
                            emailed_img.Add(bitmap);
                            Log.Info("Doneeeeeeeeeeeeeeeeeeeeeeee", $"Done Data 2{ex.Message}");
                        }

                       



                        if (limit == 20)
                        {


                            break;

                        }

                        limit++;



                    }
                    Log.Info("Doneeeeeeeeeeeeeeeeeeeeeeee", $"Done Data 2");
                    break;
                }
                if (!cloase_threads)
                {

                    Log.Info("break", $"Broke");
                    Loop_State = 0;

                }
            });
    
            if (cloase_threads)
            {
                Loop_State += 1;
                Log.Info("Doneeeeeeeeeeeeeeeeeeeeeeee", $"Done Data 2:{Loop_State}");
                if (Loop_State == 4)
                {
                    State = true;
                    Switcher_Panel = 1;
                    await TimerAnimation();
                }

            }

           
        }


        private async Task ViewedNews()
        {

            URL_View_News = "https://api.nytimes.com/svc/mostpopular/v2/viewed/1.json?api-key=sGOTcLaAfde9AGHqNG11ob8wPB6AtfMq";
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string All_Data = await client.GetStringAsync(URL_View_News);
            var data_in_string = JObject.Parse(All_Data);

            

            int limit = 0;

            await Task.Run(() =>
            {

                while (cloase_threads)
                {

                  
                    foreach (var item in data_in_string["results"])
                    {

                        

                        try
                        {
                            if (item["media"].ToArray().Length != 0)
                            {
                                viewed_title.Add($"{item["title"]}");
                                viewed_body_parah.Add($"{item["abstract"]}");
                                viewed_URL_link.Add($"{item["url"]}");

                                Bitmap viewed_bitmap = ImgWebsite($"{item["media"][0]["media-metadata"][2]["url"]}");
                                viewed_img.Add(viewed_bitmap);
                            }
                        }
                        catch (Exception ex)
                        {

                            Bitmap bitmap = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.no_img);
                            viewed_img.Add(bitmap);
                            
                        }

                        if (limit == 20)
                        {


                            break;

                        }


                        limit++;


                    }
                    break;
                }
                if (!cloase_threads)
                {

                    Log.Info("break", $"Broke");
                    Loop_State = 0;

                }
            });


            if (cloase_threads)
            {
                Loop_State += 1;
                //Log.Info("Doneeeeeeeeeeeeeeeeeeeeeeee", $"Done Data 1:{Loop_State}");
                if (Loop_State == 4)
                {
                    State = true;
                    Switcher_Panel = 1;
                    await TimerAnimation();
                }

            }
            
            
        }


        private static int panel_counter = 0;
        private static int shared_paner_counter = 0;
        private static int emailed_panel_counter = 0;
        private static int viewed_panel_counter = 0;
        
        private async Task TimerAnimation()
        {
     
            

  

            await Task.Run(() =>
            {
                
                while (State)
                {
                    

                    if (Loop_State == 4)
                    {

                        img_1.Rotation = 0;
                        img_2.Rotation = 0;
                        shared_img_1.Rotation = 0;
                        shared_img_2.Rotation = 0;
                        emailed_img_1.Rotation = 0;
                        emailed_img_2.Rotation = 0;
                        viewed_img_1.Rotation = 0;
                        viewed_img_2.Rotation = 0;


                        if (Variables.looper != "Pause")
                        {

                            if (Switcher_Panel == 1)
                            {
                                MainThread.BeginInvokeOnMainThread(() =>
                                {
                                    if (shared_paner_counter > shared_title.Count - 1)
                                    {
                                        shared_paner_counter = 0;
                                    }

                                    if (panel_counter > title.Count - 1)
                                    {
                                        panel_counter = 0;
                                    }

                                    if (emailed_panel_counter > emailed_title.Count - 1)
                                    {
                                        emailed_panel_counter = 0;
                                    }
                                    if (viewed_panel_counter > viewed_title.Count - 1)
                                    {
                                        viewed_panel_counter = 0;
                                    }
                                    // panel 1


                                    title_1.Text = $"{title[panel_counter]}";
                                    parag_1.Text = $"{body_parah[panel_counter]}";

                                    img_1.SetImageBitmap(img[panel_counter]);




                                    //shared panel 1

                                    shared_title_1.Text = $"{shared_title[shared_paner_counter]}";
                                    shared_parag_1.Text = $"{shared_body_parah[shared_paner_counter]}";

                                    shared_img_1.SetImageBitmap(shared_img[shared_paner_counter]);


                                    // email panel 1


                                    emailed_title_1.Text = $"{emailed_title[emailed_panel_counter]}";
                                    emailed_parag_1.Text = $"{emailed_body_parah[emailed_panel_counter]}";

                                    emailed_img_1.SetImageBitmap(emailed_img[emailed_panel_counter]);



                                    //viewed panel 1

                                    viewed_title_1.Text = $"{viewed_title[viewed_panel_counter]}";
                                    viewed_parag_1.Text = $"{viewed_body_parah[viewed_panel_counter]}";

                                    viewed_img_1.SetImageBitmap(viewed_img[viewed_panel_counter]);


                                    shared_paner_counter++;
                                    panel_counter++;
                                    emailed_panel_counter++;
                                    viewed_panel_counter++;



                                });


                                Switcher_Panel = 2;
                                Thread.Sleep(Seconds);

                                if (State)
                                {

                                    MainThread.BeginInvokeOnMainThread(() =>
                                    {
                                        viewSwitcher_shared.ShowNext();
                                        viewSwitcher.ShowNext();
                                        view_switcher_emailed.ShowNext();
                                        view_switcher_viewed.ShowNext();
                                        //Log.Info("chane", $"changeddddddddddddddddddddddddddddddddddd");
                                    });
                                }


                            }
                            else
                            {
                                MainThread.BeginInvokeOnMainThread(() =>
                                {

                                    if (shared_paner_counter > shared_title.Count - 1)
                                    {
                                        shared_paner_counter = 0;
                                    }

                                    if (panel_counter > title.Count - 1)
                                    {
                                        panel_counter = 0;
                                    }

                                    if (emailed_panel_counter > emailed_title.Count - 1)
                                    {
                                        emailed_panel_counter = 0;
                                    }
                                    if (viewed_panel_counter > viewed_title.Count - 1)
                                    {
                                        viewed_panel_counter = 0;
                                    }

                                    //panel 2

                                    title_2.Text = $"{title[panel_counter]}";
                                    parag_2.Text = $"{body_parah[panel_counter]}";

                                    img_2.SetImageBitmap(img[panel_counter]);





                                    //shared panel 2

                                    shared_title_2.Text = $"{shared_title[shared_paner_counter]}";
                                    shared_parag_2.Text = $"{shared_body_parah[shared_paner_counter]}";

                                    shared_img_2.SetImageBitmap(shared_img[shared_paner_counter]);


                                    // email panel 2


                                    emailed_title_2.Text = $"{emailed_title[emailed_panel_counter]}";
                                    emailed_parag_2.Text = $"{emailed_body_parah[emailed_panel_counter]}";

                                    emailed_img_2.SetImageBitmap(emailed_img[emailed_panel_counter]);


                                    //viewed panel 2

                                    viewed_title_2.Text = $"{viewed_title[viewed_panel_counter]}";
                                    viewed_parag_2.Text = $"{viewed_body_parah[viewed_panel_counter]}";

                                    viewed_img_2.SetImageBitmap(viewed_img[viewed_panel_counter]);

                                    panel_counter++;
                                    shared_paner_counter++;
                                    emailed_panel_counter++;
                                    viewed_panel_counter++;

                                });
                                Switcher_Panel = 1;
                                Thread.Sleep(Seconds);
                                if (State)
                                {

                                    MainThread.BeginInvokeOnMainThread(() =>
                                    {
                                        viewSwitcher_shared.ShowNext();
                                        viewSwitcher.ShowNext();
                                        view_switcher_emailed.ShowNext();
                                        view_switcher_viewed.ShowNext();
                                        //Log.Info("chane", $"changeddddddddddddddddddddddddddddddddddd");
                                    });
                                }
                            }

                        }

                        
                    }

                }
               
                //Log.Info("break", $"Broken");


            });
 
        }




        private Bitmap ImgWebsite(string url)
        {


            using (WebClient webClient = new WebClient())
            {
                byte[] bytes = webClient.DownloadData(url);
                if (bytes != null && bytes.Length > 0)
                {
                    return BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                }
            }
            return null;

        }

    }
}