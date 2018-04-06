using System;
using AppKit;
using ClockApp.Core.Forms.Services;
using CoreServices;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.Mac16.ShowStatusBoardImplementation))]
namespace ClockApp.Mac16
{
    public class ShowStatusBoardImplementation : ClockApp.Core.Forms.Services.IShowStatusBoard
    {
        static int num = 0;
        public ShowStatusBoardImplementation()
        {
        }
        public void Create(ContentPage[] contentPages)
        {
            if (num < 2)
            {
                //----------------- Status Bar ------------------//
                (new Components.SystemStatusBarComponent()).SetSystemStaticBar(contentPages);
                num++;
            }
        }
    }
}
