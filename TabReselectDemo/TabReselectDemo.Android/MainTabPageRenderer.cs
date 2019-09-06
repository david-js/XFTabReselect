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
    public class MainTabPageRenderer : TabbedPageRenderer, TabLayout.IOnTabSelectedListener, BottomNavigationView.IOnNavigationItemReselectedListener
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

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null && e.NewElement != null)
            {
                for (int i = 0; i < this.ViewGroup.ChildCount; i++)
                {
                    var childView = this.ViewGroup.GetChildAt(i);
                    if (childView is ViewGroup viewGroup)
                    {
                        for (int j = 0; j < viewGroup.ChildCount; j++)
                        {
                            var childRelativeLayoutView = viewGroup.GetChildAt(j);
                            if (childRelativeLayoutView is BottomNavigationView bottomNavigationView)
                            {
                                bottomNavigationView.SetOnNavigationItemReselectedListener(this);
                            }
                        }
                    }
                }
            }
        }

        void BottomNavigationView.IOnNavigationItemReselectedListener.OnNavigationItemReselected(IMenuItem item)
        {
            if (Element is MainPage)
            {
                var mainTabPage = Element as MainPage;
                mainTabPage.NotifyTabReselected();
            }
        }
    }
}
