using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Unit
{
    public class UnitType
    {
        public UnitType(string name)
        {
            this.name = name;
        }
        public long unitId { get; set; }
        public string name { get; set; }
        public Interpreter baseUnit { get; set; }
        public List<Interpreter> interpreters { get; set; } = new List<Interpreter>();
    }

    }
