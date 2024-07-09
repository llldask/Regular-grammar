using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyapRgrWpf
{
 
    public class SymbolPlace
    {
        public SymbolPlace(int pl, string sym="")
        {
            symbol= sym;        
            place = pl; 
        }
        public string symbol { get;}
        public int place { get; }
    }

    internal class Chains
    {
        int minL;
        int maxL;
        string targetRules;
        Dictionary<string, List<string>> rules;
        public List<string> result= new List<string>();

        public Chains(int min_l,int max_l, string tR,
            Dictionary<string, List<string>> rul) {
            minL = min_l;
            maxL = max_l;
            targetRules= tR;
            rules = rul;
        }

        private string historyWriter(string history = "", string ch = "")
        {
            if (history == "") 
            {
                return ch;
            }
            else
            {
                return history + "->" + ch;
            }
        }
        private SymbolPlace findLastNonTerm(string str)
        {
            for(int i=str.Length-1; i>=0; i--)
            {
                if (char.IsUpper(str[i]))
                {
                    return new SymbolPlace(i, str[i].ToString());
                }
            }
            return new SymbolPlace(-1);
        }

        public void getChains(string history = "", string ch = "", int lenght = 0)
        {
            //проверка не стоит ли закончить

            if (lenght > 50)
                return;

            var value = new List<string>();
            SymbolPlace symbolPlace = findLastNonTerm(ch);
            
            if (symbolPlace.place == -1 && history != "")
            {
                if (ch.Length >= minL && ch.Length <= maxL)
                {
                    Console.WriteLine(history);
                    result.Add(history);
                }
                return;
            }
            if (ch.Length > maxL+1)
                return;


            rules.TryGetValue(symbolPlace.symbol, out value);
           

            //проверка на начало
            if (history == "")
            {
                rules.TryGetValue(targetRules, out value);
            }



             foreach (string r in value) 
            {

                string ch1;
               if( symbolPlace.place == -1)
                {
                    ch1= r;
                }
               else
                {
                    //ch=ch.Insert(symbolPlace.place,r);
                    string ch_0 = ch.Substring(0, symbolPlace.place);
                    string ch_1 = ch.Substring(symbolPlace.place + 1);
                    ch1 = ch_0 + r + ch_1;
                }

               string history1=historyWriter(history, ch1);  
                getChains(history1, ch1,++lenght);
            }
            
        }   
    }
}
