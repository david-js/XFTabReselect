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

        // This is only needed if you want to suppress automatic pop-to-root behavior on tab reselection
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            System.Diagnostics.Debug.Assert(ShouldSelectViewController == null, "Fix double-tap implementation");
            ShouldSelectViewController = HandleUITabBarSelection;
        }

        bool HandleUITabBarSelection(UITabBarController tabBarController, UIViewController viewController)
        {
            return viewController != tabBarController.SelectedViewController;
        }

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
