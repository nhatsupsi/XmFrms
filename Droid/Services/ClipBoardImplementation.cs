using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ClockApp.Core.Forms.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.Droid.Services.ClipBoardImplementation))]
namespace ClockApp.Droid.Services
{
    class ClipBoardImplementation : IClipboard
    {
        public string GetTextFromClipBoard()
        {
            throw new NotImplementedException();
        }

        public void OnCopy(string text)
        {
            var clipboardManager = (ClipboardManager)Android.App.Application.Context.GetSystemService(Context.ClipboardService);
            // Create a new Clip
            ClipData clip = ClipData.NewPlainText("copyContent", text);
            // Copy the text
            clipboardManager.PrimaryClip = clip;
        }
    }
}