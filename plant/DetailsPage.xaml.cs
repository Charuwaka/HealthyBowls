using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace plant
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await RotateImageContinously();
        }

        async Task RotateImageContinously()
        {
            while (true) // a CancellationToken in real life ;-)
            {
                for (int i = 1; i < 7; i++)
                {
                    if (MyImage.Rotation >= 360f) MyImage.Rotation = 0;
                    await MyImage.RotateTo(i * (360 / 6), 1000, Easing.Linear);
                }
            }
        }
    }
}
