using System;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Media.Abstractions;

using Xamarin.Forms;

namespace Copara.Views
{
    public partial class MainCarouselPage : CarouselPage
    {
        public MainCarouselPage()
        {
            InitializeComponent();
            Init();
            /* Start on middle page */
            var pages = Children.GetEnumerator();
            pages.MoveNext(); // First page
            pages.MoveNext(); // Second page
            CurrentPage = pages.Current;
            /* Start on middle page */
        }

        void Init()
        {

        }

        async void Workout(object sender, EventArgs e)
        {
            meals_label.Text = "Workout meals";
            mealLine.BackgroundColor = Color.FromRgb(80, 173, 230);
            topLine.BackgroundColor = Color.FromRgb(80, 173, 230);
            settingsLine.BackgroundColor = Color.FromRgb(80, 173, 230);
            uploadLine.BackgroundColor = Color.FromRgb(80, 173, 230);
            settingsTitle.TextColor = Color.FromRgb(80, 173, 230);
            mealsTitle.TextColor = Color.FromRgb(80, 173, 230);
            uploadTitle.TextColor = Color.FromRgb(80, 173, 230);
            submit.BackgroundColor = Color.FromRgb(80, 173, 230);


        }

        async void Non_Workout(object sender, EventArgs e)
        {
            meals_label.Text = "Non-Workout meals";
            mealLine.BackgroundColor = Color.FromRgb(187, 153, 199);
            topLine.BackgroundColor = Color.FromRgb(187, 153, 199);
            settingsLine.BackgroundColor = Color.FromRgb(187, 153, 199);
            uploadLine.BackgroundColor = Color.FromRgb(187, 153, 199);
            uploadTitle.TextColor = Color.FromRgb(187, 153, 199);
            settingsTitle.TextColor = Color.FromRgb(187, 153, 199);
            mealsTitle.TextColor = Color.FromRgb(187, 153, 199);
            submit.BackgroundColor = Color.FromRgb(187, 153, 199);




        }

        async void Logout(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        async void FrontUpload(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not supported on your device", "Ok");
                return;
            }
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };

            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if(selectedImageFile == null)
            {
                //await DisplayAlert("Error", "There was an error when trying to get your image", "Ok");
                return;
            }



            FrontImage.Source = ImageSource.FromStream(() =>
            {
                var stream = selectedImageFile.GetStream();
                //selectedImageFile.Dispose();
                return stream;
            });
                             
        }

        async void BackUpload(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not supported on your device", "Ok");
                return;
            }
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (selectedImageFile == null)
            {
                await DisplayAlert("Error", "There was an error when trying to get your image", "Ok");
                return;
            }
            BackImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
        }

        async void Submit(object sender, EventArgs e)
        {
            await DisplayAlert("hello", "hello", "ok");
        }

        async void Admin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminMainPage()); 
        }

    }
}
