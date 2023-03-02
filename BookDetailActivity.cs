using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace News_Project
{
    [Activity(Label = "BookDetailActivity")]
    public class BookDetailActivity : AppCompatActivity
    {

      
        private string Number;
        private int Index;
        private ImageView img_detail;
        private TextView Book_Title_detail, Description_detail, contributor_detail, 
            publisher_detail, AuthorBook_detail;
        private Button buy_btn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.book_detail_layout);
            // Create your application here


            Book_Title_detail = FindViewById<TextView>(Resource.Id.Book_Title_detail);
            Description_detail = FindViewById<TextView>(Resource.Id.Description_detail);
            contributor_detail = FindViewById<TextView>(Resource.Id.contributor_detail);
            publisher_detail = FindViewById<TextView>(Resource.Id.publisher_detail);
            AuthorBook_detail = FindViewById<TextView>(Resource.Id.AuthorBook_detail);

            buy_btn = FindViewById<Button>(Resource.Id.buy_btn);

            buy_btn.Text = "Buy Book";

            img_detail = FindViewById<ImageView>(Resource.Id.img_detail);


            Number = Intent.GetStringExtra("index" ?? "not recv");

            Index = int.Parse(Number);


            Book_Title_detail.Text = $"{Books.TitleBook[Index]}";
            Description_detail.Text = $"\n {Books.description[Index]} \n";
            contributor_detail.Text = $" Contributor: {Books.contributor[Index]}";
            publisher_detail.Text = $" Publisher: {Books.publisher[Index]}";
            AuthorBook_detail.Text = $"Author: {Books.AuthorBook[Index]} ";

            img_detail.SetImageBitmap(Books.imgs[Index]);



            buy_btn.Click += Buy_btn_Click;

        }

        private void Buy_btn_Click(object sender, EventArgs e)
        {

            var uri = Android.Net.Uri.Parse($"{Books.amazon_product_url[Index]}");

            var ConIntent = new Intent(Intent.ActionView, uri);
            StartActivity(ConIntent);



        }
    }
}