using Autofac;
using SMR.Tracking.Platforms.Container;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SMR.Tracking.Platforms
{
    public partial class App : Application
    {
        public static IContainer Container { get; set; }

        public App()
        {
            InitializeComponent();

            Container = new AppContainerBuilder().Build();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
