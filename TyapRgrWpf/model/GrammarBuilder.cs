using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyapRgrWpf
{
   


    internal class GrammarBuilder
    {
        public GrammarBuilder() {
            SetStack();
        }
        List<string> employees = new List<string>() ;
        Stack<string> symbol;
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        string nextSymbol = "S";
        private  void firstString(string startChains, bool right)
        {
            var list=new List<string>();
            var nt = symbol.Pop();
            if (right) 
                list.Add(startChains+nt);
            else
                list.Add(nt+startChains);
            dict[nextSymbol] = list;
            nextSymbol = nt;
        }
        private  void addString(bool right, int add, string[] alf)
        {
            for(int i=0;i<add;i++)
            {
                var list = new List<string>();
                var nt = symbol.Pop();
                for(int j=0;j<alf.Length;j++)
                {
                    if (right)
                        list.Add(alf[j] + nt);
                    else
                        list.Add(nt + alf[j]);
                }
                
                dict[nextSymbol] = list;
                nextSymbol = nt;
            }
            
        }
        private void basicString(bool right, int basic, string[] alf, string endChains)
        {
            string startNT=nextSymbol;

            for (int i = 0; i < basic; i++)
            {
                var list = new List<string>();
                string nt;
                if (i != basic - 1)
                    nt = symbol.Pop();
                else
                    nt = startNT;
              /*  if (i!=basic-1)
                    nt = symbol.Pop();
                if (i == 0)
                    startNT = nt;
                else if (i == basic - 1)
                    nt = startNT;*/
                for (int j = 0; j < alf.Length; j++)
                {
                    if (right)
                        list.Add(alf[j] + nt);
                    else
                        list.Add(nt + alf[j]);
                }
                if(i==0)
                {
                    list.Add(endChains);
                }

                dict[nextSymbol] = list;
                nextSymbol = nt;
            }

        }
        private  void SetStack()
        {
            
            for (var i = 'Z'; i >='A'; i--) { 
                if(i!='S')
                employees.Add(i.ToString());
            }
            //employees.Add("S");
            symbol = new Stack<string>(employees);
        }
        int CountPart(int size, int multiplicity)
        {
            while(size>multiplicity)
            {
                multiplicity += multiplicity;
            }
            return multiplicity-size;
        }
        public  Dictionary<string, List<string>> Start(string[] alf,  int multiplicity, string startChains, string endChains, bool right)
        {
            if(right)
                firstString(startChains,right);
            else
                firstString(endChains, right);
            int size = startChains.Length + endChains.Length;
           
            if (size != 0 && size <multiplicity)
            {
                addString(right, multiplicity-size, alf);
            }
            else if (size>multiplicity)
            {
                addString(right, CountPart(size,multiplicity), alf);
            }
            if(right)
                basicString(right, multiplicity, alf, endChains);
            else
                basicString(right, multiplicity, alf, startChains);
            return dict;
        }

        public List<string> Print()
        {
            var list=new List<string>();
            foreach (var e in dict) {
                string s = "";
                s+=(e.Key+"->");
                for (int i=0;i<e.Value.Count;i++)
                {
                    if(e.Value[i]=="")
                        s+="*";
                    else
                       s+=e.Value[i];
                    if(i!=e.Value.Count-1)
                        s+="|";
                }
                list.Add(s);
            }
            return list;
        }
    }
}
