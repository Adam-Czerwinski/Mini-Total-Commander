using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.BusinessObjects
{
    public class Change
    {
        public uint Id { get;}
        public string User { get;}
        public string Source { get;}
        public string Destination { get;}
        public DateTime Time_ { get;}

        public Change(uint id, string user, string source, string destination, DateTime time_)
        {
            Id = id;
            User = user;
            Source = source;
            Destination = destination;
            Time_ = time_;
        }
    }
}
