using System;
using ClockApp.Core.Forms.Data;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.Services
{
    public interface IShowStatusBoard
    {
        //event Action<ShowStatusEventArgs> Event;
        void Create(ContentPage[] contentPages);
    }
}
