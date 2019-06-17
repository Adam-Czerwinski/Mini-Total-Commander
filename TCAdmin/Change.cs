using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCAdmin
{
    public class Change
    {
        public int Id { get; }
        public string User { get; }
        public string Source { get; }
        public string Destination { get; }
        public string DateTime { get; }

        public Change(int id, string user, string source, string destination, string dateTime)
        {
            Id = id;
            User = user;
            Source = source;
            Destination = destination;
            DateTime = dateTime;
        }
    }
}
