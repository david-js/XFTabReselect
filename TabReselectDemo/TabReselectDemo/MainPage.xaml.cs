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

            var page1 = new NavigationPage(new ColorPage("Red", Color.Red)) { Title = "Red", Icon="TabIcon.png" };
            var page2 = new NavigationPage(new ColorPage("Green", Color.Green)) { Title = "Green", Icon = "TabIcon.png" };
            var page3 = new NavigationPage(new ColorPage("Blue", Color.Blue)) { Title = "Blue", Icon = "TabIcon.png" };

            Children.Add(page1);
            Children.Add(page2);
            Children.Add(page3);

            OnTabReselected += MainPage_OnTabReselected;
        }

        private async void MainPage_OnTabReselected(Page curPage)
        {
            if (curPage is NavigationPage)
            {
                var navPage = curPage as NavigationPage;
                await navPage.PopToRootAsync();
                curPage = navPage.CurrentPage;
            }

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
