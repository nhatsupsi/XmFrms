using System;
using ClockApp.Core.Forms.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.iOS.ClipBoardImplementation))]
namespace ClockApp.iOS
{

    public class ClipBoardImplementation : IClipboard
    {
        public ClipBoardImplementation() { }

        public string GetTextFromClipBoard()
        {
            UIPasteboard clipboard = UIPasteboard.General;
            return clipboard.String;
        }

        public void OnCopy(string text)
        {
            UIPasteboard clipboard = UIPasteboard.General;
            clipboard.String = text;
        }
    }
}