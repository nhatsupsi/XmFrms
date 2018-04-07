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
            LoadApplication(new Core.Forms.App(ClockApp.Core.Forms.Data.PlatformType.WPF));
            //Frame rootFrame = this.Content as Frame;
            //rootFrame.
            //Frame frame = new Frame();
            //this.Content = frame;
            //this.Icon = "./Resources/Icons/clockIcon.png";
            this.WindowStyle = WindowStyle.SingleBorderWindow;

            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            System.IO.Stream iconStream = App.GetResourceStream(new Uri("pack://application:,,,./clockIcon2.ico")).Stream;
            ni.Icon = new System.Drawing.Icon(iconStream);
            ni.Visible = true;
            /*
            ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
            */
            System.Windows.Forms.MenuItem menuItem1 = new System.Windows.Forms.MenuItem("a");
            System.Windows.Forms.ContextMenu contextMenu1 = new System.Windows.Forms.ContextMenu();
            contextMenu1.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[] { menuItem1 });
            ni.ContextMenu = contextMenu1;
        }
    }
}
