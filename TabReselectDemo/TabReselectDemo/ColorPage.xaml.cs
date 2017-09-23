using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabReselectDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorPage : ContentPage
    {
        public ColorPage(string colorName, Color color, int depth = 0)
        {
            InitializeComponent();

            ColorName = colorName;
            Depth = depth;
            BindingContext = this;
            MainLayout.BackgroundColor = color;
            NewPageBtn.Clicked += NewPageBtn_Clicked;
        }

        private async void NewPageBtn_Clicked(object sender, EventArgs e)
        {
            var newPage = new ColorPage(ColorName, MainLayout.BackgroundColor, Depth + 1);
            await Navigation.PushAsync(newPage);
        }

        public string ColorName { get; set; }
        public int Depth { get; set; }
    }
}