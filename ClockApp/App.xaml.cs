using ClockApp.ViewModel;
using ClockApp.Views;
using Xamarin.Forms;

namespace ClockApp
{

    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var tabbedPage = new TabbedPage();

            tabbedPage.Children.Add(new Views.ClockSaveBinding() { Title = "Time save" });
            tabbedPage.Children.Add(new ClockAppPage() { Title = "Hello Xamarin" });

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
