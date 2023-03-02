using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Widget;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;




namespace News_Project
{
    public class News
    {

        private List<string> TitleLoading = new List<string>() { "Loading..." };
        private List<int> imgs_loading = new List<int>() { Resource.Drawable.loading };

        private List<string> Title_non_found = new List<string>() { "No Article was found!" };
        private List<int> imgs_non_found = new List<int>() { Resource.Drawable.no_img };



        public static List<string> Headlines = new List<string>();
        public static List<string> Description = new List<string>();
        public static List<string> web_url = new List<string>();
        public static List<string> byline = new List<string>();
        public static List<Bitmap> img = new List<Bitmap>();

        
        private Bitmap bitmap;
        private ArticleSearchAdapter articleSearchAdapter;
        private LoadingAdapter loadingAdapter;
        public async Task ArticleSearch(Context context, ListView list ,string topic, Android.Content.Res.Resources res, Button btn)
        {
            Headlines.Clear();
            Description.Clear();
            web_url.Clear();
            byline.Clear();
            img.Clear();
            ArticleSearchAdapter.Images_transition.Clear();
            btn.Enabled = false;

            loadingAdapter = new LoadingAdapter(context, TitleLoading, imgs_loading, "loading");
            list.Adapter = loadingAdapter;

            bool no_news = false;

            string URL_SEARCH_ARTICLE = $"https://api.nytimes.com/svc/search/v2/articlesearch.json?q={topic}&api-key=sGOTcLaAfde9AGHqNG11ob8wPB6AtfMq";
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string All_Data = await client.GetStringAsync(URL_SEARCH_ARTICLE);
            var data_in_string = JObject.Parse(All_Data);

            await Task.Run(() =>
            {
                while (true)
                {
                    if(data_in_string["response"]["docs"].ToArray().Length == 0)
                    {

                        no_news = true;

                    }
                    else
                    {

                        foreach (var news in data_in_string["response"]["docs"])
                        {

                     

                            Headlines.Add($"{news["headline"]["main"]}");
                            Description.Add($"{news["lead_paragraph"]} {news["snippet"]}");
                            web_url.Add($"{news["web_url"]}");
                            byline.Add($"{news["byline"]["original"]}");

                            if (news["multimedia"].ToArray().Length != 0)
                            {

                                bitmap = Variables.ImgWebsite($"https://www.nytimes.com/{news["multimedia"][0]["url"]}");
                                img.Add(bitmap);
                            }
                            else
                            {
                                bitmap = BitmapFactory.DecodeResource(res, Resource.Drawable.no_img);
                                img.Add(bitmap);
                            }


                        }
                
                    }

                    break;
                }


            });

            if (no_news)
            {

                loadingAdapter = new LoadingAdapter(context, Title_non_found, imgs_non_found, "");
                list.Adapter = loadingAdapter;
            }
            else
            {
                articleSearchAdapter = new ArticleSearchAdapter(context, Headlines, byline, img);
                list.Adapter = articleSearchAdapter;

            }


            btn.Enabled = true;
    
        }


        public static List<string> title_stories = new List<string>();
        public static List<string> descrp_stories = new List<string>();
        public static List<string> url_stories = new List<string>();
        public static List<string> byline_stories = new List<string>();
        public static List<string> section_stories = new List<string>();
        public static List<Bitmap> Images_stories = new List<Bitmap>();



        public async Task StoriesArticle(Context context, Android.Content.Res.Resources res, string topic, ListView list, Button btn)
        {

            LoadingAdapter loadingAdapter = new LoadingAdapter(context, TitleLoading, imgs_loading, "loading");

            list.Adapter = loadingAdapter;

            title_stories.Clear();
            descrp_stories.Clear();
            url_stories.Clear();
            byline_stories.Clear();
            section_stories.Clear();
            Images_stories.Clear();

            btn.Enabled = false;

            string URL_stories_ARTICLE = $"https://api.nytimes.com/svc/topstories/v2/{topic}.json?api-key=sGOTcLaAfde9AGHqNG11ob8wPB6AtfMq";
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string All_Data = await client.GetStringAsync(URL_stories_ARTICLE);
            var data_in_string = JObject.Parse(All_Data);



            await Task.Run(() =>
            {
                while (true)
                {

                    foreach (var story in data_in_string["results"])
                    {

                        title_stories.Add($"{story["title"]}");

                        url_stories.Add($"{story["url"]}");
                        byline_stories.Add($"{story["byline"]}");
                        section_stories.Add($"{story["section"]}");


                        if (story["multimedia"].ToArray().Length != 0)
                        {
                            descrp_stories.Add($"{story["multimedia"][0]["caption"]} {story["abstract"]}");
                            Bitmap bitmap = Variables.ImgWebsite($"{story["multimedia"][0]["url"]}");
                            Images_stories.Add(bitmap);

                        }
                        else
                        {
                            descrp_stories.Add($"{story["abstract"]}");
                            Bitmap bitmap = BitmapFactory.DecodeResource(res, Resource.Drawable.no_img);
                            Images_stories.Add(bitmap);
                        }

                    }

                    
                    break;
                }


            });

            StoriesAdapter storiesAdapter = new StoriesAdapter(context, title_stories, byline_stories, Images_stories);
            list.Adapter = storiesAdapter;
            btn.Enabled = true;

        }


        public static List<string> title_wire = new List<string>();
        public static List<string> descrip_wire = new List<string>();
        public static List<string> url_wire = new List<string>();
        public static List<string> byline_wire = new List<string>();
        public static List<string> subsection_wire = new List<string>();
        public static List<string> copyright_wire = new List<string>();
        public static List<Bitmap> img_wire = new List<Bitmap>();
        public async Task NewsWire(Context context, Android.Content.Res.Resources res, string filter, string section,  ListView list)
        {
            title_wire.Clear();
            descrip_wire.Clear();
            url_wire.Clear();
            byline_wire.Clear();
            subsection_wire.Clear();
            copyright_wire.Clear();
            img_wire.Clear();



            LoadingAdapter loadingAdapter = new LoadingAdapter(context, TitleLoading, imgs_loading, "loading");
            list.Adapter = loadingAdapter;




            string URL_NEWS_WIRE_ARTICLE = $"https://api.nytimes.com/svc/news/v3/content/{filter}/{section}.json?api-key=sGOTcLaAfde9AGHqNG11ob8wPB6AtfMq";
            Log.Info("miky", $"{URL_NEWS_WIRE_ARTICLE}");
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string All_Data = await client.GetStringAsync(URL_NEWS_WIRE_ARTICLE);
            var data_in_string = JObject.Parse(All_Data);


            await Task.Run(() =>
            {
                while (true)
                {

                    foreach (var item in data_in_string["results"])
                    {


                        if (item["multimedia"].ToArray().Length != 0)
                        {


                            title_wire.Add($"{item["title"]}");

                            descrip_wire.Add($"{item["abstract"]} {item["multimedia"][2]["caption"]}");

                            url_wire.Add($"{item["url"]}");

                            byline_wire.Add($"{item["byline"]}");

                            subsection_wire.Add($"{item["subsection"]}");

                            copyright_wire.Add($"{item["multimedia"][0]["copyright"]}");

                            Bitmap bitmap = Variables.ImgWebsite($"{item["multimedia"][2]["url"]}");

                            img_wire.Add(bitmap);
                        }
                        else
                        {
                            copyright_wire.Add($"Unknown");
                            descrip_wire.Add($"{item["abstract"]}");
                            Bitmap bitmap = BitmapFactory.DecodeResource(res, Resource.Drawable.no_img);
                            img_wire.Add(bitmap);
                        }

                    }
                    break;

                }

            });

            // adapters
            
            if(data_in_string["results"].ToArray().Length != 0)
            {


                TimeNewsWireAdapter timeNewsWireAdapter = new TimeNewsWireAdapter(context, title_wire, byline_wire, img_wire);
                list.Adapter = timeNewsWireAdapter;
            }
            else
            {

                LoadingAdapter none = new LoadingAdapter(context, Title_non_found, imgs_non_found, "");
                list.Adapter = none;

            }

        }

        
    }
}