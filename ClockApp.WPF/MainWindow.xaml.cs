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
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            //this.Icon = "./Resources/Icons/clockIcon.png";
        }
    }
}
