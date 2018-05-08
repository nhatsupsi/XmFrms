using System;
using System.Diagnostics;
using ClockApp.Core.Forms.Services;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.Data
{
    public class User
    {
        public User(){
            //OnDownloadClicked = new Command(DownloadRun);
        }
        public string Email 
        {
            get
            {
                char[] array = DisplayName.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                    if (array[i].Equals(' '))
                        array[i] = '_';
                string s = new string(array);
                return String.Format("{0}@gmail.com", s);
            }
        }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public void CopyToClipBoard(object parameter)
        {
            DependencyService.Get<IClipboard>().OnCopy(((User)parameter).Password);
        }

        public Command OnCopyClicked
        {
            get
            {
                return new Command(CopyToClipBoard);
            }
        }
    }
}
