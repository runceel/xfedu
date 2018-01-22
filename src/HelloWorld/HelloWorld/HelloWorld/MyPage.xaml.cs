using System;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
        }
        private async void ButtonScrollTo_Clicked(object sender, EventArgs e)
        {
            await scrollView.ScrollToAsync(this.boxViewYellow, ScrollToPosition.Start, true);
            await DisplayAlert("Info", $"Scroll position is {scrollView.ScrollX}, {scrollView.ScrollY}", "OK");
        }

    }
}
