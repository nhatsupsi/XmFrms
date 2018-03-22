using ClockApp.Core.Forms.Data;
using Xamarin.Forms;

namespace ClockApp.Core.Forms
{

    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var tabbedPage = new TabbedPage();
            tabbedPage.Title = "Clock TabbedPage";
            tabbedPage.Children.Add(new ClockAppPage() { Title = "Hello Xamarin" });
            tabbedPage.Children.Add(new Views.ClockView() { Title = "Clock" });
            tabbedPage.Children.Add(new Views.ClockSave() { Title = "Clock save" });
            tabbedPage.Children.Add(new Views.ClockSaveBinding() { Title = "Button clicked" });
            MainPage = tabbedPage;

        }
        public App(PlatformType type)
        {
            InitializeComponent();

            var tabbedPage = new TabbedPage();
            tabbedPage.Title = "Clock TabbedPage";

            tabbedPage.Children.Add(new ClockAppPage(type) { Title = "Hello Xamarin" });
            tabbedPage.Children.Add(new Views.ClockView() { Title = "Clock" });
            tabbedPage.Children.Add(new Views.ClockSave() { Title = "Clock save" });
            tabbedPage.Children.Add(new Views.ClockSaveBinding() { Title = "Button clicked"});
            if (type == PlatformType.WPF)
            {
                for (int i = 0; i < tabbedPage.Children.Count; i++)
                {
                }
                tabbedPage.HeightRequest = tabbedPage.Height/2.0;
                tabbedPage.BackgroundColor =Color.White;
                tabbedPage.BarBackgroundColor = Color.Black;

            }
            MainPage = tabbedPage;

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
