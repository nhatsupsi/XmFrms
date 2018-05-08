using ClockApp.Core.Forms.Data;
using ClockApp.Core.Forms.Services;
using System.Diagnostics;
using Xamarin.Forms;
namespace ClockApp.Core.Forms
{
    public partial class App : Application
    {
        TabbedPage tabbedPage;
        HelloXamarin helloXamarinPage;

        ContentPage[] tabbedPageContent;

        PlatformType platformType;

        public App(PlatformType platformType)
        {
            InitializeComponent();

            this.platformType = platformType;

            initTabbedPage();

            if (platformType == PlatformType.WPF)
            {
                tabbedPage.BarBackgroundColor = Color.Black;
            }
            MainPage = tabbedPage;
        }

        public TabbedPage AppTabbedPage
        {
            get { return tabbedPage; }
        }
        public ContentPage[] TabbedPageContent
        {
            get { return tabbedPageContent; }
        }

        private void initTabbedPage()
        {
            tabbedPage = new TabbedPage();

            tabbedPage.Title = "Clock TabbedPage";


            helloXamarinPage = new HelloXamarin(platformType) { Title = "Hello Xamarin" };


            tabbedPageContent = new ContentPage[] { helloXamarinPage, new Views.UsersManager() { Title = "Users Manager" }, new Views.FSTracker(platformType) { Title = "File System" }};

            foreach (ContentPage page in tabbedPageContent)
            {
                tabbedPage.Children.Add(page);
            }

            MainPage = tabbedPage;
        }
        protected override void OnStart()
        {
            // Handle when your app starts
            Debug.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Debug.WriteLine("OnResume");
        }
    }
}
