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

            tabbedPage.Children.Add(new Views.ClockSaveBinding() { Title = "clock save" });
            tabbedPage.Children.Add(new ClockAppPage() { Title = "clock app" });

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

    /*
    public partial class App : Application
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }


        public static Page GetMainPage()
        {
            return new MvvmLightPage();
        }
    }
    */
}
