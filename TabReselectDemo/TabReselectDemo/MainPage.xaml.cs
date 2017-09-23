using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TabReselectDemo
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            var page1 = new NavigationPage(new ColorPage("Red", Color.Red)) { Title = "Red" };
            var page2 = new NavigationPage(new ColorPage("Green", Color.Green)) { Title = "Green" };
            var page3 = new NavigationPage(new ColorPage("Blue", Color.Blue)) { Title = "Blue" };

            Children.Add(page1);
            Children.Add(page2);
            Children.Add(page3);

            OnTabReselected += MainPage_OnTabReselected;
        }

        private async void MainPage_OnTabReselected(Page curPage)
        {
            if (curPage is NavigationPage)
                curPage = (curPage as NavigationPage).CurrentPage;

            if (curPage is ColorPage)
            {
                var currentColorPage = curPage as ColorPage;

                await DisplayAlert("Tab Reselected", "Reselecting ColorPage for: " + currentColorPage.ColorName, "ok");
            }
        }

        public event Action<Page> OnTabReselected;

        // Will be called by custom renderers
        public void NotifyTabReselected()
        {
            OnTabReselected?.Invoke(CurrentPage);
        }
    }
}
