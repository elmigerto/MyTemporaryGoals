using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTemporaryGoals
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }
        public App()
        {
            InitializeComponent();
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            //Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));

            MainPage = new NavigationPage( new MainPage());
           


        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
    public partial class AppShell: Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute(nameof(AddTaskWindow), typeof(AddTaskWindow));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
        
    }

    
}
