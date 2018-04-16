using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockApp.Core.Forms.Data
{
    public enum TargetType
    {
        Folder,
        File
    }
    public class FileSystemWatcherObject
    {
        String name;
        String path;
        TargetType type;

        public String Name
        {
            get
            {
                return this.name;
            }
        }
        public String Path
        {
            get
            {
                return this.path;
            }
        }
        public TargetType Type
        {
            get
            {
                return this.type;
            }
        }

        public FileSystemWatcherObject(String name, String path, TargetType type)
        {
            this.name = name;
            this.path = path;
            this.type = type;
        }

    }
}
