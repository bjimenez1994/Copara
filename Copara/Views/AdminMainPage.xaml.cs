using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Copara.Views
{
    public partial class AdminMainPage : ContentPage
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        async void Progress(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminProgressPage());
        }

        async void Meals(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminMealPage());
        }
    }
}
