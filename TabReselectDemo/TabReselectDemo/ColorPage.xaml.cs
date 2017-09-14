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
        public ColorPage(string colorName, Color color)
        {
            InitializeComponent();

            ColorName = colorName;
            BindingContext = this;
            MainLayout.BackgroundColor = color;
        }

        private async void NewPageBtn_Clicked(object sender, EventArgs e)
        {
            var newPage = new ColorPage(ColorName, MainLayout.BackgroundColor);
            await Navigation.PushAsync(newPage);
        }

        public string ColorName { get; set; }
    }
}