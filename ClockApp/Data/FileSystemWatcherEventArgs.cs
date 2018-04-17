using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockApp.Core.Forms.Data
{
    public enum ActionType
    {
        Changed,
        Created,
        Deleted,
        Renamed
    }
    public class FileSystemWatcherEventArgs : EventArgs
    {
        public DateTime date;

        public FileSystemWatcherObject target;
        public FileSystemWatcherObject oldTargetStat=null;
        public ActionType actionType;

        FileSystemWatcherEventArgs(FileSystemWatcherObject target, ActionType actionType)
        {
            this.date = DateTime.Now;
            this.target = target;
            this.actionType = actionType;
        }
        FileSystemWatcherEventArgs(FileSystemWatcherObject target, FileSystemWatcherObject oldTargetStat, ActionType actionType)
        {
            this.date = DateTime.Now;
            this.target = target;
            this.oldTargetStat = oldTargetStat;
            this.actionType = actionType;
        }
        public static FileSystemWatcherEventArgs CreateChangedEvent(FileSystemWatcherObject target)
        {
            return new FileSystemWatcherEventArgs(target, ActionType.Changed);
        }
        public static FileSystemWatcherEventArgs CreateCreatedEvent(FileSystemWatcherObject target)
        {
            return new FileSystemWatcherEventArgs(target, ActionType.Created);
        }
        public static FileSystemWatcherEventArgs CreateDeletedEvent(FileSystemWatcherObject target)
        {
            return new FileSystemWatcherEventArgs(target, ActionType.Deleted);
        }
        public static FileSystemWatcherEventArgs CreateRenamedEvent(FileSystemWatcherObject target)
        {
            return new FileSystemWatcherEventArgs(target, ActionType.Renamed);
        }
        public static FileSystemWatcherEventArgs CreateRenamedEvent(FileSystemWatcherObject target, FileSystemWatcherObject oldTargetStat)
        {
            return new FileSystemWatcherEventArgs(target, oldTargetStat, ActionType.Renamed);
        }
        public override string ToString()
        {
            if (actionType == ActionType.Renamed && oldTargetStat!=null)
                return String.Format("{0} {1} ({3}) is {4} to {2}", date.ToString("h:mm:ss tt"), oldTargetStat.Name, target.Name, target.Type, actionType);
            else
                return String.Format("{0} {1} ({2}) is {3}", date.ToString("h:mm:ss tt"), target.Name, target.Type, actionType);
        }

    }
}
