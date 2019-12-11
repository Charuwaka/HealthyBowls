using System;
using plant;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plant
{
    public partial class App : Application
    {
        
        public App()
        {
            
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
    
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
