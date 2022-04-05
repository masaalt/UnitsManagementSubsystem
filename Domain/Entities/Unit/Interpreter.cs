using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Unit
{
    public class Interpreter
    {
        public long interpreterId { get; set; }
        public string name { get; set; }
        public string relationToBaseF { get; set; }
        public string relationFromBaseF { get; set; }

    }
}
