using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public static class ExpCalc
    {
        public static string CalcBtnP(string exp)
        {
            try
            {
                string[] expArr = Regex.Split(exp, string.Empty);
                ArrayList expMath = new ArrayList();
                foreach (var expElem in expArr)
                {
                    if(expElem == "+" || expElem == "-" || expElem == "*" || expElem == "/")
                    {
                        expMath.Add(expElem);
                    }
                }

                char[] delimiterChars = { '+', '-', '*', '/' };
                string[] elems = exp.Split(delimiterChars);

                ArrayList expElems = new ArrayList();
                int i = 0;
                foreach (string numElm in elems)
                {
                    expElems.Add(numElm.Trim());

                    if(expMath.Count > i)
                    {
                        expElems.Add(expMath[i].ToString().Trim());
                        i++;
                    }  
                }


                //foreach (var arr in expArr.Select((value, i) => (value, i)))
                //{
                //    expArr[arr.i] = arr.value.Trim();
                //}
               // expArr = expArr.Where(x => x != "").ToArray();
                foreach (var wrd in expElems.ToArray().Select((value, i) => (value, i)))
                {
                    if (wrd.value.ToString() == "/")
                    {
                        expElems[wrd.i] = (float.Parse(expElems[wrd.i - 1].ToString()) / float.Parse(expElems[wrd.i + 1].ToString())).ToString();
                        expElems.RemoveAt(wrd.i - 1);
                        expElems.RemoveAt(wrd.i);
                    }
                }
                foreach (var wrd in expElems.ToArray().Select((value, i) => (value, i)))
                {
                    if (wrd.value.ToString() == "*")
                    {
                        expElems[wrd.i] = (float.Parse(expElems[wrd.i - 1].ToString()) * float.Parse(expElems[wrd.i + 1].ToString())).ToString();
                        expElems.RemoveAt(wrd.i - 1);
                        expElems.RemoveAt(wrd.i);
                    }
                }
                foreach (var wrd in expElems.ToArray().Select((value, i) => (value, i)))
                {
                    if (wrd.value.ToString() == "+")
                    {
                        expElems[wrd.i] = (float.Parse(expElems[wrd.i - 1].ToString()) + float.Parse(expElems[wrd.i + 1].ToString())).ToString();
                        expElems.RemoveAt(wrd.i - 1);
                        expElems.RemoveAt(wrd.i);
                    }
                }
                foreach (var wrd in expElems.ToArray().Select((value, i) => (value, i)))
                {
                    if (wrd.value.ToString() == "-")
                    {
                        expElems[wrd.i] = (float.Parse(expElems[wrd.i - 1].ToString()) - float.Parse(expElems[wrd.i + 1].ToString())).ToString();
                        expElems.RemoveAt(wrd.i - 1);
                        expElems.RemoveAt(wrd.i);
                    }
                }

                return expElems[0].ToString();
            }
           catch(Exception ex)
            {
                return "";
            }
            
        }
    }
}
