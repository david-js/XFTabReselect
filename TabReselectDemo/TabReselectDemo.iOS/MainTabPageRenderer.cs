using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using TabReselectDemo.iOS;
using TabReselectDemo;

[assembly: Xamarin.Forms.ExportRenderer(typeof(MainPage), typeof(MainTabPageRenderer))]
namespace TabReselectDemo.iOS
{
    public class MainTabPageRenderer : TabbedRenderer
    {
        private UIKit.UITabBarItem _prevItem;

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (SelectedIndex < TabBar.Items.Length)
                _prevItem = TabBar.Items[SelectedIndex];
        }

        public override void ItemSelected(UIKit.UITabBar tabbar, UIKit.UITabBarItem item)
        {
            if (_prevItem == item && Element is MainPage)
            {
                var mainTabPage = Element as MainPage;
                mainTabPage.NotifyTabReselected();
            }
            _prevItem = item;
        }
    }
}
