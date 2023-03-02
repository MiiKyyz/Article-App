using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace News_Project
{
    [Activity(Label = "Time NewsWire Detail")]
    public class TimeNewsWireDetail : AppCompatActivity
    {

        private TextView Tilte_wire_detail, Section_wire_detail, descrip_wire_detail, bylinewire_detail, copyright_wire_detail;
        private Button url_wire_detail;
        private ImageView img_wire_detail;
        private int index;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Time_news_wire_detail);


            Tilte_wire_detail = FindViewById<TextView>(Resource.Id.Tilte_wire_detail);
            Section_wire_detail = FindViewById<TextView>(Resource.Id.Section_wire_detail);
            descrip_wire_detail = FindViewById<TextView>(Resource.Id.descrip_wire_detail);
            bylinewire_detail = FindViewById<TextView>(Resource.Id.bylinewire_detail);
            copyright_wire_detail = FindViewById<TextView>(Resource.Id.copyright_wire_detail);

            url_wire_detail = FindViewById<Button>(Resource.Id.url_wire_detail);
            img_wire_detail = FindViewById<ImageView>(Resource.Id.img_wire_detail);


            string index_txt = Intent.GetStringExtra("index" ?? "not recv");

            index = int.Parse(index_txt);

            Tilte_wire_detail.Text = $"{News.title_wire[index]}";
            Section_wire_detail.Text = $"{News.subsection_wire[index]}";
            descrip_wire_detail.Text = $"{News.descrip_wire[index]}";
            bylinewire_detail.Text = $"Written {News.byline_wire[index]}";
            copyright_wire_detail.Text = $"Copy Rights Reserved to {News.copyright_wire[index]}";




            img_wire_detail.SetImageBitmap(News.img_wire[index]);
            url_wire_detail.Click += Url_wire_detail_Click;
        }

        private void Url_wire_detail_Click(object sender, EventArgs e)
        {

            var uri = Android.Net.Uri.Parse($"{News.url_wire[index]}");
            var ConIntent = new Intent(Intent.ActionView, uri);
            StartActivity(ConIntent);
        }
    }
}