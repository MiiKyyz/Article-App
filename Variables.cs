using Android.Graphics;
using System.Collections.Generic;
using System.Net;





namespace News_Project
{
    public class Variables
    {

        public static string looper;
        public static Dictionary<string, string> Categories = new Dictionary<string, string>()
        {

            {"Fiction", "Combined Print and E-Book Fiction" },
            {"Nonfiction", "Combined Print and E-Book Nonfiction" },
            {"Hardcover Fiction", "Hardcover Fiction" },
            {"Hardcover Nonfiction", "Hardcover Nonfiction" },
            {"Paperback Trade Fiction", "Trade Fiction Paperback" },
            {"Paperback Mass-Market Fiction", "Mass Market Paperback" },
            {"Paperback Nonfiction", "Paperback Nonfiction"},
            {"E-Book Fiction","E-Book Fiction" },
            {"E-Book Nonfiction", "E-Book Nonfiction" },
            {"Hardcover Advice & Misc.", "Hardcover Advice" },
            {"Paperback Advice & Misc.", "Paperback Advice" },
            {"Advice How-To and Miscellaneous", "Advice How-To and Miscellaneous" },
            {"Hardcover Graphic Books", "Hardcover Graphic Books" },
            {"Paperback Graphic Books", "Paperback Graphic Books" },
            {"Manga", "Manga" },
            {"Combined Hardcover & Paperback Fiction", "Combined Print Fiction" },
            {"Combined Hardcover & Paperback Nonfiction", "Combined Print Nonfiction" },
            {"Children’s Chapter Books", "Chapter Books" },
            {"Children’s Middle Grade", "Childrens Middle Grade" },
            {"Children’s Middle Grade E-Book", "Childrens Middle Grade E-Book" },
            {"Children’s Middle Grade Hardcover", "Childrens Middle Grade Hardcover" },
            {"Children’s Middle Grade Paperback", "Childrens Middle Grade Paperback" },
            {"Children’s Paperback Books", "Paperback Books" },
            {"Children’s Picture Books", "Picture Books" },
            {"Children’s Series", "Series Books" },
            {"Young Adult", "Young Adult"},
            {"Young Adult E-Book", "Young Adult E-Book" },
            {"Young Adult Hardcover", "Young Adult Hardcover" },
            {"Young Adult Paperback", "Young Adult Paperback" },
            {"Animals", "Animals" },
            { "Audio Fiction", "Audio Fiction"},
            {"Audio Nonfiction", "Audio Nonfiction" },
            {"Business", "Business Books" },
            {"Celebrities", "Celebrities" },
            {"Crime and Punishment", "Crime and Punishment" },
            {"Culture", "Culture" },
            {"Education", "Education" },
            {"Espionage", "Espionage" },
            {"Expeditions" , "Expeditions Disasters and Adventures"},
            {"Fashion, Manners and Customs" , "Fashion Manners and Customs"},
            {"Food and Diet", "Food and Fitness" },
            {"Games and Activities", "Games and Activities" },
            {"Graphic Books and Manga", "Graphic Books and Manga" },
            {"Hardcover Business Books", "Hardcover Business Books" },
            {"Health", "Health" },
            {"Humor", "Humor" },
            {"Indigenous Americans", "Indigenous Americans" },
            {"Love and Relationships", "Relationships" },
            {"Mass Market", "Mass Market Monthly" },
            {"Middle Grade Paperback", "Middle Grade Paperback Monthly" },
            {"Paperback Business Books", "Paperback Business Books" },
            {"Parenthood and Family", "Family" },
            {"Politics and American History", "Hardcover Political Books" },
            {"Race and Civil Rights" , "Race and Civil Rights"},
            {"Religion, Spirituality and Faith", "Religion Spirituality and Faith" },
            {"Science", "Science" },
            {"Sports and Fitness", "Sports" },
            {"Travel", "Travel" },
            {"Young Adult and Paperback", "Young Adult Paperback Monthly" },
          


        };



        public static List<string> article_news_topics = new List<string>()
        {

            "Adventure Sports",
            "Arts & Leisure",
            "Arts",
            "Automobiles",
            "Blogs",
            "Books",
            "Booming",
            "Business Day",
            "Business",
            "Cars",
            "Circuits",
            "Classifieds",
            "Connecticut",
            "Crosswords & Games",
            "Culture",
            "DealBook",
            "Dining",
            "Editorial",
            "Education",
            "Energy",
            "Entrepreneurs",
            "Environment",
            "Escapes",
            "Fashion & Style",
            "Fashion",
            "Favorites",
            "Financial",
            "Flight",
            "Food",
            "Foreign",
            "Generations",
            "Giving",
            "Global Home",
            "Health & Fitness",
            "Health",
            "Home & Garden",
            "Home",
            "Jobs",
            "Key",
            "Letters",
            "Long Island",
            "Magazine",
            "Market Place",
            "Media",
            "Men's Health",
            "Metro",
            "Metropolitan",
            "Movies",
            "Museums",
            "National",
            "Nesting",
            "Obits",
            "Obituaries",
            "Obituary",
            "OpEd",
            "Opinion",
            "Outlook",
            "Personal Investing",
            "Personal Tech",
            "Play",
            "Politics",
            "Regionals",
            "Retail",
            "Retirement",
            "Science",
            "Small Business",
            "Society",
            "Sports",
            "Style",
            "Sunday Business",
            "Sunday Review",
            "Sunday Styles",
            "T Magazine",
            "T Style",
            "Technology",
            "Teens",
            "Television",
            "The Arts",
            "The Business of Green",
            "The City Desk",
            "The City",
            "The Marathon",
            "The Millennium",
            "The Natural World",
            "The Upshot",
            "The Weekend",
            "The Year in Pictures",
            "Theater",
            "Then & Now",
            "Thursday Styles",
            "Times Topics",
            "Travel",
            "U.S.",
            "Universal",
            "Upshot",
            "UrbanEye",
            "Vacation",
            "Washington",
            "Wealth",
            "Weather",
            "Week in Review",
            "Week",
            "Weekend",
            "Westchester",
            "Wireless Living",
            "Women's Health",
            "Working",
            "Workplace",
            "World",

        };


        public static List<string> stories_categories = new List<string>
        {
            "arts",
            "automobiles",
            "books",
            "business",
            "fashion",
            "food",
            "health",
            "home",
            "insider",
            "magazine",
            "movies",
            "nyregion",
            "obituaries",
            "opinion",
            "politics",
            "realestate",
            "science",
            "sports",
            "sundayreview",
            "technology",
            "theater",
            "t-magazine",
            "travel",
            "upshot",
            "us",
            "world",
            "home",
         
        };



        public static Dictionary<string, string> newswire_categories = new Dictionary<string, string>
        {
            {"Admin", "admin" },
            {"Arts", "arts" },
            {"Automobiles", "automobiles" },
            {"Books", "books" },
            {"Briefing", "briefing" },
            {"Business", "business" },
            {"Climate", "climate" },
            {"Corrections", "corrections" },
            {"Crosswords & Games", "crosswords & games" },
            {"Education", "education" },
            {"En Español", "en español" },
            {"Fashion", "fashion" },
            {"Food", "food" },
            {"Guides", "guides" },
            {"Health", "health" },
            {"Home & Garden", "home & garden" },
            {"Home Page", "home page" },
            {"Job Market", "job market" },
            {"Lens", "lens" },
            {"Magazine", "magazine" },
            {"Movies", "movies" },
            {"Multimedia/Photos", "multimedia/photos" },
            {"New York", "new york" },
            {"Obituaries", "obituaries" },
            {"Opinion", "opinion" },
            {"Parenting", "parenting" },
            {"Podcasts", "podcasts" },
            {"Reader Center", "reader center" },
            {"Real Estate", "real estate" },
            {"Science", "science" },
            {"Smarter Living", "smarter living" },
            {"Sports", "sports" },
            {"Style", "style" },
            {"Sunday Review", "sunday review" },
            {"T Brand", "t brand" },
            {"T Magazine", "t magazine" },
            {"Technology", "technology" },
            {"The Learning Network", "the learning network" },
            {"The Upshot", "the upshot" },
            {"The Weekly", "the weekly" },
            {"Theater", "theater" },
            {"Times Insider", "times insider" },
            {"Today’s Paper", "today’s paper" },
            {"Travel", "travel" },
            {"U.S.", "u.s." },
            {"Universal", "universal" },
            {"Video", "video" },
            {"Well", "well" },
            {"World", "world" },
            {"Your Money", "your money" },


        };


        public static Bitmap ImgWebsite(string url)
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