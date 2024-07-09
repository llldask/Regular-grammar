using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace TyapRgrWpf
{
    internal class ToFile
    {
        public static void jsonToFile(string filePath,Data d)
        {
            
            string jsonString = JsonSerializer.Serialize<Data>(d);
            File.WriteAllText(filePath, jsonString);
        }
        public static Data jsonOfFile(string filePath)
        {
            
            var s = File.ReadAllText(filePath);
           
            return JsonSerializer.Deserialize<Data>(s)!;
        }
        public static void resToFile(string filePath,string s, List<string> s1,List<string> s2)
        {

            File.WriteAllText(filePath, s);
            var s3 = s1.Concat(s2).ToList();

            File.AppendAllLines(filePath, s3);
     

            //File.AppendAllLines(filePath, s2);
        }
    }
}
