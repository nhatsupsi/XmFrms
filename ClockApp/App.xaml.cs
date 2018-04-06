using ClockApp.Core.Forms.Data;
using ClockApp.Core.Forms.Services;
using System.Diagnostics;
using Xamarin.Forms;

namespace ClockApp.Core.Forms
{
    public partial class App : Application
    {
        TabbedPage tabbedPage;
        ClockAppPage helloXamarinPage;
        Views.ClockView clockPage;
        Views.ClockSave clockSavePage;
        //Views.ClockSaveBinding clockSaveBindingPage;
        Views.PhoneCall phoneCallPage;
        Views.PasswordSave passwordSave;
        Views.FileSystemTracker fileSystemTracker;

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

            helloXamarinPage = new ClockAppPage(platformType) { Title = "Hello Xamarin" };
            clockPage = new Views.ClockView() { Title = "Clock" };
            clockSavePage = new Views.ClockSave() { Title = "Clock save" };
            //clockSaveBindingPage = new Views.ClockSaveBinding() { Title = "Button clicked" };
            phoneCallPage = new Views.PhoneCall(platformType) { Title = "Phone call" };
            passwordSave = new Views.PasswordSave(platformType) { Title = "Password save" };
            fileSystemTracker = new Views.FileSystemTracker(platformType) { Title = "File System" };
            
            tabbedPage.Title = "Clock TabbedPage";

            tabbedPage.Children.Add(helloXamarinPage);
            tabbedPage.Children.Add(clockPage);
            tabbedPage.Children.Add(clockSavePage);
            //tabbedPage.Children.Add(clockSaveBindingPage);
            tabbedPage.Children.Add(phoneCallPage);
            tabbedPage.Children.Add(passwordSave);
            tabbedPage.Children.Add(fileSystemTracker);
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
