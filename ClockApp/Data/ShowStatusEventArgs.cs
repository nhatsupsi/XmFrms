using System;
namespace ClockApp.Core.Forms.Data
{
    public class ShowStatusEventArgs : EventArgs
    {
        public int pageIndex;
        public ShowStatusEventArgs(int pageIndex)
        {
            this.pageIndex = pageIndex;
        }
    }
}
