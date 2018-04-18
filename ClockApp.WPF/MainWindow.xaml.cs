using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xamarin.Forms.Platform.WPF;

namespace ClockApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();
            Xamarin.Forms.Forms.Init();
            Core.Forms.App app = new Core.Forms.App(ClockApp.Core.Forms.Data.PlatformType.WPF);
            LoadApplication(app);
            //Frame rootFrame = this.Content as Frame;
            //rootFrame.
            //Frame frame = new Frame();
            //this.Content = frame;
            //this.Icon = "./Resources/Icons/clockIcon.png";
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            
            ShowStatusBoardImplementation notifyIcon = new ShowStatusBoardImplementation();
            notifyIcon.CreateNotifyIcon(app.TabbedPageContent);
        }
    }
}
