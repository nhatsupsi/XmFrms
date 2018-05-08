using System;

namespace ClockApp.Core.Forms.Data
{
    public enum ActionType
    {
        Changed,
        Created,
        Deleted,
        Renamed,
        ContentChanged
    }
    public class FileSystemWatcherEventArgs : EventArgs
    {
        public DateTime date;

        public FileSystemWatcherObject Target { get; set; }
        public FileSystemWatcherObject OldTargetStat { get; set; }
        public ActionType ActionType { get; set; }

        FileSystemWatcherEventArgs(FileSystemWatcherObject target, ActionType actionType)
        {
            date = DateTime.Now;
            Target = target;
            ActionType = actionType;
        }
        FileSystemWatcherEventArgs(FileSystemWatcherObject target, FileSystemWatcherObject oldTargetStat, ActionType actionType)
        {
            date = DateTime.Now;
            Target = target;
            OldTargetStat = oldTargetStat;
            ActionType = actionType;
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
        public static FileSystemWatcherEventArgs CreateContentChangedEvent(FileSystemWatcherObject target)
        {
            return new FileSystemWatcherEventArgs(target, ActionType.ContentChanged);
        }
        public override string ToString()
        {
            if (ActionType == ActionType.Renamed && OldTargetStat != null)
                return String.Format("{0} {1} ({3}) is {4} to {2}", date.ToString("h:mm:ss tt"), OldTargetStat.Name, Target.Name, Target.Type, ActionType);
            else if (ActionType == ActionType.ContentChanged)
                return String.Format("{0} Content of {1} ({2}) is Changed", date.ToString("h:mm:ss tt"), Target.Name, Target.Type);
            else
                return String.Format("{0} {1} ({2}) is {3}", date.ToString("h:mm:ss tt"), Target.Name, Target.Type, ActionType);
        }

        /***************** Data to stamp *****************/
        public String Date
        {
            get
            {
                return date.ToString("h:mm:ss tt");
            }
        }
        public String TargetName
        {
            get
            {
                return Target.Name;//target.Name.Replace(",", "");
            }
        }
        public string SimpleMessage
        {
            get
            {
                if (ActionType == ActionType.Renamed && OldTargetStat != null)
                    return String.Format("{0} ({2}) is {3} to {1}", OldTargetStat.Name, Target.Name, Target.Type, ActionType);
                else if (ActionType == ActionType.ContentChanged)
                    return String.Format("Content of {0} ({1}) is Changed", Target.Name, Target.Type);
                else
                    return String.Format("{0} ({1}) is {2}", Target.Name, Target.Type, ActionType);
            }
        }

    }
}
