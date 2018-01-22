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

        private void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            label.Text = $"{e.OldTextValue} -> ${e.NewTextValue}";
        }

    }
}
