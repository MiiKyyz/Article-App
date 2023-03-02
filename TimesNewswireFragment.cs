using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;





namespace News_Project
{
    public class TimesNewswireFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        private View view;
        private ListView listView_newswire;
        private Button btn_newswire;
        private ImageView info_newswire;
        private Spinner filter_spinner, section_spinner;
        private ArrayAdapter adapter;
        private static string section, filter;
        string[] filters = new string[] { "nyt", "inyt", "all" };
        private News news = new News();
        private LoadingAdapter loadingAdapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            view = inflater.Inflate(Resource.Layout.time_newswire_layout, container, false);

            listView_newswire = view.FindViewById<ListView>(Resource.Id.listView_newswire);
            btn_newswire = view.FindViewById<Button>(Resource.Id.btn_newswire);

            info_newswire = view.FindViewById<ImageView>(Resource.Id.info_newswire);
            filter_spinner = view.FindViewById<Spinner>(Resource.Id.filter_spinner);
            section_spinner = view.FindViewById<Spinner>(Resource.Id.section_spinner);


            adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, filters);
            filter_spinner.Adapter = adapter;

            adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, Variables.newswire_categories.Keys.ToArray());
            section_spinner.Adapter = adapter;



            info_newswire.Click += Info_newswire_Click;
            filter_spinner.ItemSelected += Filter_spinner_ItemSelected;
            btn_newswire.Click += Btn_newswire_Click;
            listView_newswire.ItemClick += ListView_newswire_ItemClick;


            List<string> Title_non_found = new List<string>() { "Empty" };
            List<int> imgs_non_found = new List<int>() { Resource.Drawable.empty_logo };
            loadingAdapter = new LoadingAdapter(Context, Title_non_found, imgs_non_found, "");
            listView_newswire.Adapter = loadingAdapter;




            return view;
        }

        private void ListView_newswire_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            try
            {
                
                Intent intent = new Intent(Context, typeof(TimeNewsWireDetail));
                intent.PutExtra("index", $"{e.Position}");
                ActivityOptionsCompat activityOptionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(Activity, TimeNewsWireAdapter.img_transitions[e.Position], ViewCompat.GetTransitionName(TimeNewsWireAdapter.img_transitions[e.Position]));
                StartActivity(intent, activityOptionsCompat.ToBundle());
            }
            catch
            {


            }


            
        }

        private async void Btn_newswire_Click(object sender, EventArgs e)
        {
            List<string> Title_non_found = new List<string>() { "No Book was found!" };
            List<int> imgs_non_found = new List<int>() { Resource.Drawable.no_img };
         
            btn_newswire.Enabled = false;
            if (section_spinner.Enabled)
            {
                try
                {

                    filter = filter_spinner.SelectedItem.ToString();
                    section = Variables.newswire_categories[section_spinner.SelectedItem.ToString()];

                    await news.NewsWire(Context, Resources, filter, section, listView_newswire);
                }
                catch
                {
                    btn_newswire.Enabled = true;
                    loadingAdapter = new LoadingAdapter(Context, Title_non_found, imgs_non_found, "");
                    listView_newswire.Adapter = loadingAdapter;
                }


            }
            else
            {

                await news.NewsWire(Context, Resources, filter, section, listView_newswire);
            }
            btn_newswire.Enabled = true;

        }

        private void Info_newswire_Click(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(Context);

            dialog.SetMessage("With the Times Newswire Panel, you can get links and news for Times' articles as soon as they are published on NYTimes.com. The Times Newswire Panel provides an up-to-the-minute stream of published articles. You can filter results by source (all, nyt, inyt) and section (arts, business, ...). \n" +
                "\n \n all = items from both The New York Times and The International New York Times. \n \n nyt = New York Times items only. \n \n inyt = International New York Times items only (FKA The International Herald Tribune).");
            dialog.SetTitle("Times Newswire Info");
            dialog.SetIcon(Resource.Drawable.LogoApp);
            dialog.SetPositiveButton("OK", delegate
            {

                dialog.Dispose();

            });
            dialog.Create();
            dialog.Show();
        }

        private void Filter_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position == 2)
            {

                filter = "all";
                section = "all";
                section_spinner.Enabled = false;
            }
            else
            {
                
                section_spinner.Enabled = true;
            }
        }

    
    }
}