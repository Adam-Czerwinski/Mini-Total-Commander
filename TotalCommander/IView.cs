using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander
{
    interface IView
    {
        Action<string,string> copy { get; set; }

        IPane SelectedPane { get; set; }
        IPane UnselectedPane { get; set; }

        //to się przyda tylko w podaniu do presenterów (w pliku Program.cs)
        IPane LeftPane { get; }
        IPane RightPane { get; }
    }
}
