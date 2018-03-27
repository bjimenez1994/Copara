using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Copara.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void Login(object ender, EventArgs e)
        {
            App.IsUserLoggedIn = true;
            Navigation.InsertPageBefore(new MainCarouselPage(), this);
            await Navigation.PopAsync();


        }
    }
}
