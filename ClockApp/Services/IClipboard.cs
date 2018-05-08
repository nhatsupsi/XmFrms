using System;
namespace ClockApp.Core.Forms.Services
{
    public interface IClipboard
    {
        String GetTextFromClipBoard();
        void OnCopy(string text);
    }
}
