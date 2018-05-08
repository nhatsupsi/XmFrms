using ClockApp.Core.Forms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace ClockApp.UWP
{
    class ClipBoardImplementation : IClipboard
    {
        DataPackage dataPackage = new DataPackage();

        public string GetTextFromClipBoard()
        {
            throw new NotImplementedException();
        }

        public void OnCopy(string text)
        {
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText(text);
            Clipboard.SetContent(dataPackage);
            Xamarin.Forms.MessagingCenter.Send<ClockApp.Core.Forms.App, String>(
                (ClockApp.Core.Forms.App)Xamarin.Forms.Application.Current,
                "ClipBoardOnCopy",
                text
                );
        }
    }
}
