using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TyapRgrWpf
{
    class ViewModel
    {
        public Dictionary<string, List<string>> dict;
        public List<string> list;
        public List<string> listC;
        private  string[] strToArray(string s)
        {
            string[] subs = s.Split(',');
            return subs;
        }
        public void resToFile(string fileName, string alf, string multiplicity, string startChains, string endChains)
        {
            var s = alf + "\nКратность: " + multiplicity + "\nНачальная цепочка: " + startChains + "\nКонечная цепочка: " + endChains+"\n\n";
            ToFile.resToFile(fileName, s, list, listC);
        }
       
        public static void jsonToFile(string fileName,string alf, string multiplicity, string startChains, string endChains, string a, string b, bool right)
        {
            var d = new Data() { right = right, Alphabet = alf, StartSymbol = startChains, EndSymbol = endChains, M = multiplicity, StartState = a, EndState = b };//(right, alf, startChains, endChains, multiplicity, a, b);
            ToFile.jsonToFile(fileName, d);
        }
        public static Data jsonOfFile(string fileName)
        {

           return ToFile.jsonOfFile(fileName);
        }
        public  void GetRul(string alf, string multiplicity, string startChains, string endChains, string a, string b,bool right)
        {
            if (String.IsNullOrEmpty(alf)||String.IsNullOrEmpty(multiplicity)|| String.IsNullOrEmpty(a)|| String.IsNullOrEmpty(b))
                throw new Exception("Не все строки заполнены!");
            int m,aInt,bInt;
            try
            {
                m=int.Parse(multiplicity);
                aInt=int.Parse(a);
                bInt=int.Parse(b);
            }
            catch
            {
                throw new Exception("Не все числовые поля заполнены верно!");
            }

            var alfArr=strToArray(alf);
            CheckUserString.Check(alfArr, m, startChains, endChains, aInt, bInt);
            var gr = new GrammarBuilder();
            dict=gr.Start(alfArr,m,startChains,endChains,right);
            list = gr.Print();
            var ch = new Chains(aInt,bInt,"S",dict);
            ch.getChains();
            listC=ch.result;
        }
    }
}
