using ClockApp.Core.Forms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace ClockApp.UWP
{
    class FileSystemImplementation : IFileSystem
    {
        public void WatchFolder()
        {
            //throw new NotImplementedException();
            System.Diagnostics.Debug.WriteLine("I am here");
        }

        public void WatchFolder(string path)
        {
            //throw new NotImplementedException();
            System.Diagnostics.Debug.WriteLine("I am here");
        }
    }
}
