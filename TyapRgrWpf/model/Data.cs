using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyapRgrWpf
{
    internal class Data
    {
      /*  public Data(bool r, string a, string startSymbol,string endSymbol, string m, string startState, string endState)
        {
            right = r;
            Alphabet = a;
            StartSymbol = startSymbol;
            EndSymbol = endSymbol;
            M = m;
            StartState = startState;
            EndState = endState;
        }*/
        public bool right {  get; set; }
         public string Alphabet {  get; set; }
        public string StartSymbol {  get; set; }
        public string EndSymbol {  get; set; }
        public string M {  get; set; }
        public string StartState {  get; set; }
        public string EndState {  get; set; }
    }
}
