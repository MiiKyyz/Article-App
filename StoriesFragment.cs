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
    public class StoriesFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        private View view;
        private Spinner edit_Category_stories;
        private ListView listViewStories;
        private Button btn_Search_stories;
        private News news = new News();
        private ImageView info_stories;
        private LoadingAdapter loadingAdapter;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            view = inflater.Inflate(Resource.Layout.stories_layout, container, false);

            edit_Category_stories = view.FindViewById<Spinner>(Resource.Id.edit_Category_stories);
            listViewStories = view.FindViewById<ListView>(Resource.Id.listViewStories);
            btn_Search_stories = view.FindViewById<Button>(Resource.Id.btn_Search_stories);
            info_stories = view.FindViewById<ImageView>(Resource.Id.info_stories);

            ArrayAdapter adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, Variables.stories_categories.ToArray());
            edit_Category_stories.Adapter = adapter;

          


            btn_Search_stories.Click += Btn_Search_stories_Click;
            info_stories.Click += Info_stories_Click;

            listViewStories.ItemClick += ListViewStories_ItemClick;



            List<string> Title_non_found = new List<string>() { "Empty" };
            List<int> imgs_non_found = new List<int>() { Resource.Drawable.empty_logo };
            loadingAdapter = new LoadingAdapter(Context, Title_non_found, imgs_non_found, "");
            listViewStories.Adapter = loadingAdapter;



            return view;
        }

        private void Info_stories_Click(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(Context);

            dialog.SetMessage("The Top Stories Panel returns a list of articles currently on the specified section (arts, business, ...).");
            dialog.SetTitle("Top Stories Info");
            dialog.SetIcon(Resource.Drawable.LogoApp);
            dialog.SetPositiveButton("OK", delegate
            {

                dialog.Dispose();

            });
            dialog.Create();
            dialog.Show();
        }

        private void ListViewStories_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            try
            {

                Intent intent = new Intent(Context, typeof(StoriesDetails));
                intent.PutExtra("index", $"{e.Position}");
                ActivityOptionsCompat optionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(Activity, StoriesAdapter.img_transition[e.Position], ViewCompat.GetTransitionName(StoriesAdapter.img_transition[e.Position]));
                StartActivity(intent, optionsCompat.ToBundle());
            }
            catch
            {


            }

    
           
        }

    

        private async void Btn_Search_stories_Click(object sender, EventArgs e)
        {
            //Log.Info("miky", edit_Category_stories.SelectedItem.ToString());
            List<string> Title_non_found = new List<string>() { "No Book was found!" };
            List<int> imgs_non_found = new List<int>() { Resource.Drawable.no_img };
           
            try
            {
                StoriesAdapter.img_transition.Clear();
                await news.StoriesArticle(Context, Resources, edit_Category_stories.SelectedItem.ToString(), listViewStories, btn_Search_stories);

            }
            catch
            {
                loadingAdapter = new LoadingAdapter(Context, Title_non_found, imgs_non_found, "");
                listViewStories.Adapter = loadingAdapter;
                btn_Search_stories.Enabled = true;
            }

          
        }
    }
}