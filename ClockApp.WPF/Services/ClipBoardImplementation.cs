using ClockApp.Core.Forms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.WPF.ClipBoardImplementation))]
namespace ClockApp.WPF
{
    class ClipBoardImplementation : IClipboard
    {
        public string GetTextFromClipBoard()
        {
            return (String)Clipboard.GetDataObject().GetData(DataFormats.Text);
        }

        public void OnCopy(string text)
        {
            Clipboard.SetDataObject(text);
            Xamarin.Forms.MessagingCenter.Send<ClockApp.Core.Forms.App, String>(
                (ClockApp.Core.Forms.App)Xamarin.Forms.Application.Current,
                "ClipBoardOnCopy",
                GetTextFromClipBoard()
                );
        }
    }
}
