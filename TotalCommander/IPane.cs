using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander
{
    public interface IPane
    {
        string CurrentPath { get;  set; }
        string[] Drives { set; }
        string[] DirectoriesAndFiles {set; }
        string SelectedFileOrDirectoryPath { get; }

        Action loadDrives { get; set; }
        Action<string> loadDirectoriesAndFiles { get; set; }

        void Aktywuj();
        void Dezaktywuj();
    }
}
