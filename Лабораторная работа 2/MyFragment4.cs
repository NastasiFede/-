using System.Text;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
//using Xamarin.
namespace CreateAFragment
{
    public class MyFragment4 : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            // A large amount of text to display.

            //var textToDisplay = new StringBuilder().Insert(0, "The quick brown fox jumps over the lazy dog. ", 450).ToString();

            var view = inflater.Inflate(Resource.Layout.MyFragment4, container, false);

            var textView = view.FindViewById<TextView>(Resource.Id.textView1);
            //textView.Text = textToDisplay;

            return view;
        }
    }
}