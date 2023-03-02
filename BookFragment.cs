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
    public class BookFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }


        private View view;
        private Spinner edit_Category;
        private CheckBox checkBox;
        private Button btn_date, btn_Search;
        private ListView listView;
        private LayoutInflater inflater;
        private ImageView info_book;
        private ViewGroup container;
        private int Year, Month, Day;
        private string Date_status, category_selected;
        private Books books = new Books();

        private Dictionary<string, string> Categories = new Dictionary<string, string>();
        private LoadingAdapter loadingAdapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            this.inflater = inflater;
            this.container = container;
            view = inflater.Inflate(Resource.Layout.book_layout, container, false);

            edit_Category = view.FindViewById<Spinner>(Resource.Id.edit_Category);

            
            checkBox = view.FindViewById<CheckBox>(Resource.Id.checkBox);
            btn_date = view.FindViewById<Button>(Resource.Id.btn_date);
            btn_Search = view.FindViewById<Button>(Resource.Id.btn_Search);
            listView = view.FindViewById<ListView>(Resource.Id.listView);

            info_book = view.FindViewById<ImageView>(Resource.Id.info_book);


            Categories = Variables.Categories;


            ArrayAdapter arrayAdapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, Categories.Keys.ToArray());

            edit_Category.Adapter = arrayAdapter;

            edit_Category.ItemSelected += Edit_Category_ItemSelected;


            info_book.Click += Info_book_Click;
            listView.ItemClick += ListView_ItemClick;
            btn_Search.Click += Btn_Search_Click;
            btn_date.Click += Btn_date_Click;
            checkBox.CheckedChange += CheckBox_CheckedChange;

            List<string> Title_non_found = new List<string>() { "Empty" };
            List<int> imgs_non_found = new List<int>() { Resource.Drawable.empty_logo };
            loadingAdapter = new LoadingAdapter(Context, Title_non_found, imgs_non_found, "");
            listView.Adapter = loadingAdapter;


            return view;
        }

        private void Info_book_Click(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(Context);

            dialog.SetMessage("The Best Selling Books panel provides information about book reviews and The New York Times Best Sellers lists.");
            dialog.SetTitle("Book Selling Info");
            dialog.SetIcon(Resource.Drawable.LogoApp);
            dialog.SetPositiveButton("OK", delegate
            {
                
                dialog.Dispose();

            });
            dialog.Create();
            dialog.Show();
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {



            try
            {
                Intent intent = new Intent(Context, typeof(BookDetailActivity));
                intent.PutExtra("index", $"{e.Position}");
                ActivityOptionsCompat optionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(Activity, BookAdapter.images_transition[e.Position], ViewCompat.GetTransitionName(BookAdapter.images_transition[e.Position]));
                StartActivity(intent, optionsCompat.ToBundle());

            }
            catch
            {


            }
            
            
        }

      

        private void Edit_Category_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            category_selected = Categories.Values.ToArray()[e.Position];
        }

        private void CheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {

            if (e.IsChecked)
            {
                btn_date.Text = "Select Date";
                btn_date.Enabled = false;
                Date_status = "current";
            }
            else
            {
                btn_date.Enabled = true;

            }

        }

        private void Btn_date_Click(object sender, EventArgs e)
        {
            OnCreateDialog(0).Show();
        }


        private Android.App.AlertDialog.Builder OnCreateDialog(int id)
        {
            View v = inflater.Inflate(Resource.Layout.date_time, container, false);


            switch (id)
            {

                case 0:


                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(Context);


                    dialog.SetView(v);

                    dialog.SetPositiveButton("Select Date", delegate
                    {
                        DatePicker datePicker = v.FindViewById<DatePicker>(Resource.Id.datePicker);
                        Year = datePicker.Year;
                        Month = datePicker.Month + 1;
                        Day = datePicker.DayOfMonth;
                        btn_date.Text = $"{datePicker.Month + 1}-{datePicker.DayOfMonth}-{datePicker.Year}";

                        if (datePicker.Month == 10 || datePicker.Month == 11 )
                        {

                            Date_status = $"{datePicker.Year}-{datePicker.Month + 1}-{datePicker.DayOfMonth}";
                        }
                        else
                        {
                            Date_status = $"{datePicker.Year}-0{datePicker.Month + 1}-{datePicker.DayOfMonth}";

                        }

                        
                        dialog.Dispose();

                    });
                    dialog.Create();

                    return dialog;
            }



            return null;

        }



        private async void Btn_Search_Click(object sender, EventArgs e)
        {
            List<string> Title_non_found = new List<string>() { "No book was found! or Error internet connection" };
            List<int> imgs_non_found = new List<int>() { Resource.Drawable.no_img };
           

            try
            {
               
                BookAdapter.images_transition.Clear();
                string category = Variables.Categories[edit_Category.SelectedItem.ToString()];
                await books.BookOverview(category, Date_status, listView, Context, btn_Search);
         
            }
            catch
            {
                loadingAdapter = new LoadingAdapter(Context, Title_non_found, imgs_non_found, "");
                listView.Adapter = loadingAdapter;
                btn_Search.Enabled = true;
               
                
            }

            
            

        }

     

       
    }
}