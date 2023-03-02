using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Widget;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace News_Project
{
    public class Books
    {



        private string URL_BOOK_OVERVIEW;
        public static List<string> TitleBook = new List<string>();
        public static List<string> AuthorBook = new List<string>();
        public static List<string> amazon_product_url = new List<string>();
        public static List<string> description = new List<string>();
        public static List<string> contributor = new List<string>();
        public static List<string> publisher = new List<string>();
        public static List<Bitmap> imgs = new List<Bitmap>();
        private List<string> TitleLoading = new List<string>() { "Loading..." };
        private List<int> imgs_loading = new List<int>() { Resource.Drawable.loading };
        private List<string> Title_non_found = new List<string>() { "No Book was found!" };
        private List<int> imgs_non_found = new List<int>() { Resource.Drawable.no_img };
        private BookAdapter bookAdapter;
        private LoadingAdapter loadingAdapter;
        public async Task BookOverview(string category, string date, ListView listview, Context context, Button btn)
        {

            TitleBook.Clear();
            AuthorBook.Clear();
            amazon_product_url.Clear();
            description.Clear();
            imgs.Clear();
            contributor.Clear();
            publisher.Clear();

            bool no_news = false;

            loadingAdapter = new LoadingAdapter(context, TitleLoading, imgs_loading, "loading");
            listview.Adapter = loadingAdapter;

            btn.Enabled = false;
            string URL_BOOK_OVERVIEW = $"https://api.nytimes.com/svc/books/v3/lists/{date}/{category}.json?api-key=sGOTcLaAfde9AGHqNG11ob8wPB6AtfMq";


            Log.Info("URLLLLLLLLLLLLLLLLLLLLLLL", $"{URL_BOOK_OVERVIEW}");

    
          
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string All_Data = await client.GetStringAsync(URL_BOOK_OVERVIEW);
            var data_in_string = JObject.Parse(All_Data);
           

            

            await Task.Run(() =>
            {
                while (true)
                {
                    
                    if(data_in_string["results"]["books"].ToArray().Length == 0)
                    {


                        no_news = true;
                    }
                    else
                    {

                        foreach (var book in data_in_string["results"]["books"])
                        {

                            TitleBook.Add($"{book["title"]}");
                            AuthorBook.Add($"{book["author"]}");
                            amazon_product_url.Add($"{book["amazon_product_url"]}");
                            description.Add($"{book["description"]}");
                            contributor.Add($"{book["contributor"]}");
                            publisher.Add($"{book["publisher"]}");
                            Bitmap b = ImgWebsite($"{book["book_image"]}");
                            imgs.Add(b);
                        }

                    }


                    

                    break;

                }


            });


            if (no_news)
            {
                loadingAdapter = new LoadingAdapter(context, Title_non_found, imgs_non_found, "");
                listview.Adapter = loadingAdapter;

            }
            else
            {
                bookAdapter = new BookAdapter(context, TitleBook, AuthorBook, imgs);
                listview.Adapter = bookAdapter;

            }
            
            
            btn.Enabled = true;
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