using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCAdmin
{
    public interface IView
    {
        string[,] Data { set; }

        event Action Load;
    }
}
