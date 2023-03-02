using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.View;
using System;
using System.Collections.Generic;





namespace News_Project
{
    public class ArticleSearchFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        private View view;
        private AutoCompleteTextView auto_txt_article;
        private Button btn_txt_article;
        private ListView listView_article;
        private ImageView info_search;
        private News news = new News();
        private List<string> article_news_topics = new List<string>();
        private LoadingAdapter loadingAdapter;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            view = inflater.Inflate(Resource.Layout.article_search_layout, container, false);

            article_news_topics = Variables.article_news_topics;
            btn_txt_article = view.FindViewById< Button >(Resource.Id.btn_txt_article);
            listView_article = view.FindViewById<ListView>(Resource.Id.listView_article);
            auto_txt_article = view.FindViewById<AutoCompleteTextView>(Resource.Id.auto_txt_article);
            info_search = view.FindViewById<ImageView>(Resource.Id.info_search);

            ArrayAdapter arrayAdapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, article_news_topics.ToArray());
            auto_txt_article.Adapter = arrayAdapter;
            btn_txt_article.Click += Btn_txt_article_Click;


            List<string> Title_non_found = new List<string>() { "Empty" };
            List<int> imgs_non_found = new List<int>() { Resource.Drawable.empty_logo };

            loadingAdapter = new LoadingAdapter(Context, Title_non_found, imgs_non_found, "");
            listView_article.Adapter = loadingAdapter;


            listView_article.ItemClick += ListView_article_ItemClick;

            info_search.Click += Info_search_Click;

            return view;
        }

        private void Info_search_Click(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(Context);

            dialog.SetMessage("The Article Search Panel is to look up articles by keyword. You can seek for any work and it will search for the articles that matches your keyword.");
            dialog.SetTitle("Article Search Info");
            dialog.SetIcon(Resource.Drawable.LogoApp);
            dialog.SetPositiveButton("OK", delegate
            {

                dialog.Dispose();

            });
            dialog.Create();
            dialog.Show();
        }

        private void ListView_article_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            try
            {
                Intent intent = new Intent(Context, typeof(ArticleSearchDetails));
                intent.PutExtra("index", $"{e.Position}");
                ActivityOptionsCompat optionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(Activity, ArticleSearchAdapter.Images_transition[e.Position], ViewCompat.GetTransitionName(ArticleSearchAdapter.Images_transition[e.Position]));

                StartActivity(intent, optionsCompat.ToBundle());
            }
            catch
            {



            }


            

           
        }

        private async void Btn_txt_article_Click(object sender, EventArgs e)
        {

            List<string> Title_non_found = new List<string>() { "No article was found!" };
            List<int> imgs_non_found = new List<int>() { Resource.Drawable.no_img };

            if (auto_txt_article.Text != "")
            {

                try
                {

                    auto_txt_article.Enabled = false;
                    await news.ArticleSearch(Context, listView_article, auto_txt_article.Text, Resources, btn_txt_article);
                    auto_txt_article.Text = "";
                    auto_txt_article.Enabled = true;
                }
                catch
                {
             
                    loadingAdapter = new LoadingAdapter(Context, Title_non_found, imgs_non_found, "");
                    listView_article.Adapter = loadingAdapter;
                    auto_txt_article.Enabled = true;
                    btn_txt_article.Enabled = true;
                }
                
            }
            else
            {

                Toast.MakeText(Context, "A topic is needed!", ToastLength.Short).Show();
            }


            
        }
    }
}