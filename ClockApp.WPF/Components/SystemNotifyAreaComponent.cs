﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClockApp.WPF.Components
{
    class SystemNotifyAreaComponent
    {
        public void CreateNotifyIcon(ContentPage[] contentPages)
        {
            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            System.IO.Stream iconStream = App.GetResourceStream(new Uri("pack://application:,,,./clockIcon2.ico")).Stream;
            ni.Icon = new System.Drawing.Icon(iconStream);
            ni.Visible = true;

            System.Windows.Forms.MenuItem[] menuItems = new System.Windows.Forms.MenuItem[contentPages.Length];
            for (int i = 0; i < contentPages.Length; i++)
            {
                System.Windows.Forms.MenuItem menuItem = new System.Windows.Forms.MenuItem(contentPages[i].Title);
                menuItems[i] = menuItem;
                menuItem.Click +=
                delegate (object sender, EventArgs args)
                {
                    int index = getSelectedItemIndex(((System.Windows.Forms.MenuItem)sender).Text, contentPages);
                    Xamarin.Forms.MessagingCenter.Send<ClockApp.Core.Forms.App, int>(
                        (ClockApp.Core.Forms.App)Xamarin.Forms.Application.Current,
                        "StatusBarItemChanged",
                        index
                    );
                };
            }
            System.Windows.Forms.ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
            contextMenu.MenuItems.AddRange(menuItems);
            ni.ContextMenu = contextMenu;
        }
        int getSelectedItemIndex(string title, ContentPage[] contentPages)
        {
            for (int i = 0; i < contentPages.Length; i++)
                if (contentPages[i].Title.Equals(title))
                    return i;
            return -1;
        }
    }
}
