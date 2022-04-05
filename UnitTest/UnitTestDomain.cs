using FluentAssertions;
using NUnit.Framework;
using Common;
using Domain.Entities.Unit;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    public class UnitTestDomain
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GeneralUnitTest()
        {
            UnitType unit = new UnitType("Length")
            {
                baseUnit = new Interpreter() { name = "meter" }
            };
            unit.interpreters.Add(new Interpreter() { name = "centimeter", relationToBaseF = "1/100*a", relationFromBaseF = "100*a" });
            unit.interpreters.Add(new Interpreter() { name = "kilometer", relationToBaseF = "1000*a", relationFromBaseF = "a/1000" });
            unit.interpreters.Add(new Interpreter() { name = "milimeter", relationToBaseF = "1/1000*a", relationFromBaseF = "1000*a" });

            unit.name.Should().BeEquivalentTo("Length");

            Dictionary<string, UnitType> units = new Dictionary<string, UnitType>();
            units.Add(unit.name, unit);

            GeneralUnit len1 = new GeneralUnit(units["Length"]);
            len1.Value = 10;
            len1.Interpret = units["Length"].baseUnit;
            GeneralUnit len11 = len1.to(units["Length"].interpreters.Where(x => x.name == "kilometer").FirstOrDefault());
          
            len11.Value.ToString().Should().BeEquivalentTo("0.01");



            UnitType unit2 = new UnitType("Temperature")
            {
                baseUnit = new Interpreter() { name = "Celsius" }
            };
            unit2.interpreters.Add(new Interpreter() { name = "Kelvin", relationToBaseF = "a-273.15", relationFromBaseF = "a+273.15" });
            unit2.interpreters.Add(new Interpreter() { name = "Fahrenheit", relationToBaseF = "(a-32)*(5/9)", relationFromBaseF = "(a*9/5)+(32)" });

            unit2.name.Should().BeEquivalentTo("Temperature");

            units.Add(unit2.name, unit2);

            GeneralUnit temp = new GeneralUnit(units["Temperature"]);
            temp.Value = 10;
            temp.Interpret = units["Temperature"].baseUnit;
            GeneralUnit temp11 = temp.to(units["Temperature"].interpreters.Where(x => x.name == "Kelvin").FirstOrDefault());

            temp11.Value.ToString().Should().BeEquivalentTo("283.15");
        }
    }
}