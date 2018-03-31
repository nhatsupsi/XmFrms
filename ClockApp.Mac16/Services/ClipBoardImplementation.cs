using System;
using AppKit;
using ClockApp.Core.Forms.Services;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.Mac16.ClipBoardImplementation))]
namespace ClockApp.Mac16
{
    public class ClipBoardImplementation : IClipboard
    {
        public ClipBoardImplementation()
        {
        }

        public string GetTextFromClipBoard()
        {
            throw new NotImplementedException();
        }

        public void OnCopy(string text)
        {
            var pasteboard = NSPasteboard.GeneralPasteboard;
            pasteboard.ClearContents();
            pasteboard.WriteObjects(new NSString[] { new NSString(text) });
        }
    }
}
