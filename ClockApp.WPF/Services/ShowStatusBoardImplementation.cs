using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.WPF.ShowStatusBoardImplementation))]
namespace ClockApp.WPF
{
    class ShowStatusBoardImplementation : ClockApp.Core.Forms.Services.IShowStatusBoard
    {
        public void Create(ContentPage[] contentPages)
        {
            Components.SystemNotifyAreaComponent notificationIcon=new Components.SystemNotifyAreaComponent();
            notificationIcon.CreateNotifyIcon(contentPages);
        }
    }
}
