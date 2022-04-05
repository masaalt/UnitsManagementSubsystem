using Domain.Entities.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Unit.Commands
{
    public class Test
    {
        public Test()
        {

        }
          /// <summary>
          /// Service for testing the Unit Management subsystem internally.
          /// </summary>
          /// <returns></returns>
        public void DoingSomething()
        {
            #region Filling the dic without DB
            Dictionary<string, UnitType> units = new Dictionary<string, UnitType>();

            //Add Sample Dim
            UnitType unit = new UnitType("Length")
            {
                baseUnit = new Interpreter() { name = "meter" }
            };
            unit.interpreters.Add(new Interpreter() { name = "centimeter", relationToBaseF = "1/100*a", relationFromBaseF = "100*a" });
            unit.interpreters.Add(new Interpreter() { name = "kilometer", relationToBaseF = "1000*a", relationFromBaseF = "a/1000" });
            unit.interpreters.Add(new Interpreter() { name = "milimeter", relationToBaseF = "1/1000*a", relationFromBaseF = "1000*a" });

            units.Add(unit.name, unit);
            #endregion

            #region Using the Subsystem

            GeneralUnit len1 = new GeneralUnit(units["Length"]);
            len1.Value = 10;
            len1.Interpret = units["Length"].interpreters.Where(x => x.name == "meter").FirstOrDefault();
            var len11 = len1.to(units["Length"].interpreters.Where(x => x.name == "kilometer").FirstOrDefault());

            #endregion End of Using
        }
    }
}
