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
        Views.PasswordSave passwordSave;
        Views.FileSystemTracker fileSystemTracker;

        public static ContentPage[] tabbedPageContent;

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
        private void initTabbedPage()
        {
            tabbedPage = new TabbedPage();

            tabbedPage.Title = "Clock TabbedPage";


            helloXamarinPage = new HelloXamarin(platformType) { Title = "Hello Xamarin" };
            passwordSave = new Views.PasswordSave(platformType) { Title = "Password save" };
            fileSystemTracker = new Views.FileSystemTracker(platformType) { Title = "File System" };


            tabbedPageContent = new ContentPage[] { helloXamarinPage, passwordSave, fileSystemTracker };

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

            // Create Statusbar for MAC and take action when its item is clicked
            if (platformType == Data.PlatformType.MacOS || platformType == Data.PlatformType.WPF)
            {
                DependencyService.Get<IShowStatusBoard>().Create(tabbedPageContent);
                MessagingCenter.Subscribe<App, int>((App)Application.Current, "StatusBarItemChanged", (sender, pageIndex) => {
                    tabbedPage.CurrentPage = tabbedPage.Children[pageIndex];
                });
            }
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
