using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System.Collections.Generic;

    public class Bundlex
    {
        public List<Entry> Entries { get; set; }

        public Bundlex()
        {
            Entries = new List<Entry>();
        }
    }

    public class Entry
    {
        public Patientx Patient { get; set; }
    }

    public class Patientx
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

}
