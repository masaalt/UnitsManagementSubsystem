using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Domain.Entities.Unit
{
    public class GeneralUnit
    {
        public UnitType Unit { get; set; }
        public Interpreter Interpret { get; set; } = new Interpreter();
        public float Value { get; set; }
        public GeneralUnit(UnitType unit, float val = 0)
        {
            this.Unit = unit;
            this.Value = val;
        }

        public GeneralUnit to(Interpreter interpreter)
        {
            GeneralUnit newGenUnit = new GeneralUnit(this.Unit);
            if (this.Interpret == interpreter)
            {
                return this;
            }

            float baseVal = this.toBaseVal(this.Value.ToString());
            float targetVal = this.FromBaseVal(baseVal.ToString(), interpreter);

            newGenUnit.Value = targetVal;
            newGenUnit.Interpret = interpreter;
            return newGenUnit;
        }
         /// <summary>
         /// Convert to Base As Requested.
         /// </summary>
         /// <param name="interpreter"></param>
         /// <returns></returns>
        public float toBaseVal(string val)
        {
            try
            {
                if (this.Interpret == this.Unit.baseUnit)
                {
                    return float.Parse(val);
                }

                string formula = this.Interpret.relationToBaseF;
                if (!formula.Contains("a"))
                {
                    return -1;
                }
                formula = formula.Replace("a", val);
                while (formula.Contains("("))
                {
                    int start = formula.IndexOf("(") + 1;
                    int end = formula.IndexOf(")", start);
                    string btnP = formula.Substring(start, end - start);
                    string res = ExpCalc.CalcBtnP(btnP);
                    formula = formula.Replace("(" + btnP + ")", res);
                }
                string ress = ExpCalc.CalcBtnP(formula);
                return (float.Parse(ress));
            }
           catch(Exception ex)
            {
                return -1;
            }

        }
        
         /// <summary>
         /// Convert the Value From Base to Target interpret
         /// </summary>
         /// <param name="val"></param>
         /// <param name="interpreter"></param>
         /// <returns></returns>
        public float FromBaseVal(string val, Interpreter interpreter)
        {
            try
            {
                string formula = interpreter.relationFromBaseF;
                if (!formula.Contains("a"))
                {
                    return -1;
                }
                formula = formula.Replace("a", val);
                while (formula.Contains("("))
                {
                    int start = formula.IndexOf("(") + 1;
                    int end = formula.IndexOf(")", start);
                    string btnP = formula.Substring(start, end - start);
                    string res = ExpCalc.CalcBtnP(btnP);
                    formula = formula.Replace("(" + btnP + ")", res);
                }
                string ress = ExpCalc.CalcBtnP(formula);
                return (float.Parse(ress));
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

    }

}
