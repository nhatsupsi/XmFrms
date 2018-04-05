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
            throw new NotImplementedException();
        }

        public void OnCopy(string text)
        {
            System.Diagnostics.Debug.WriteLine("data copy I am here");
            Clipboard.SetDataObject(text);
        }
    }
}
