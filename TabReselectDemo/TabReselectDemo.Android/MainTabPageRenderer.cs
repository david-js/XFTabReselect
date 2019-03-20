using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Support.Design.Widget;
using Xamarin.Forms.Platform.Android;
using System.Reflection;
using TabReselectDemo;
using TabReselectDemo.Droid;

[assembly: Xamarin.Forms.ExportRenderer(typeof(MainPage), typeof(MainTabPageRenderer))]
namespace TabReselectDemo.Droid
{
    public class MainTabPageRenderer : TabbedPageRenderer, TabLayout.IOnTabSelectedListener
    {
        public MainTabPageRenderer(Context context) : base(context)
        {
        }

        void TabLayout.IOnTabSelectedListener.OnTabReselected(TabLayout.Tab tab)
        {
            if (Element is MainPage)
            {
                var mainTabPage = Element as MainPage;
                mainTabPage.NotifyTabReselected();
            }
        }
    }
}
