using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TabReselectDemo;
using TabReselectDemo.UWP;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(TabReselectDemo.MainPage), typeof(MainTabPageRenderer))]
namespace TabReselectDemo.UWP
{
    public class MainTabPageRenderer : TabbedPageRenderer
    {
        private Xamarin.Forms.Page _prevPage;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            Control.Tapped += Control_Tapped;
            _prevPage = Control.SelectedItem as Xamarin.Forms.Page;
        }

        private void Control_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (!(Element is TabReselectDemo.MainPage))
                return;

            switch (e.OriginalSource)
            {
                case Image image:
                    if (image.Name == "TabbedPageHeaderImage")
                        HandleReselect(image);
                    break;
                case TextBlock textBlock:
                    if (textBlock.Name == "TabbedPageHeaderTextBlock")
                        HandleReselect(textBlock);
                    break;
            }
        }

        private void HandleReselect(FrameworkElement frameworkElement)
        {
            var newPage = frameworkElement.DataContext as Xamarin.Forms.Page;
            if (newPage == _prevPage)
            {
                var mainPage = Element as TabReselectDemo.MainPage;
                mainPage.NotifyTabReselected();
            }

            _prevPage = newPage;
        }
    }
}
