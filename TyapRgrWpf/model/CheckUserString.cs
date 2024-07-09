using System;



namespace TyapRgrWpf
{
   
    internal class CheckUserString
    {
        static void checkFormatAlf(string[] alf)
        {
            if(alf.Length <1||alf.Length>21)
                throw new AlfSizeException();
            
                foreach (string s in alf)
            {
                if (s == null|| s.Length != 1)
                    throw new AlfException();
                foreach (char a in s)
                    if (char.IsUpper(a) || char.IsLetterOrDigit(a)==false)
                        throw new AlfException();

            }
        }
        static void checkMultiplicitySize(int multiplicity)
        {
            if (multiplicity < 1 || multiplicity > 10)
                throw new MultiplicitySizeException();
        }
        static bool checkSizeChains(string chains)
        {
            if (chains.Length > 10)
                return false;
            return true;
        }
        static void checkRange(int a, int b)
        {
            if (a > b || a < 1||b>10)
                throw new RangeException();
        }
        static bool chainsInAlf(string[] alf, string chains)
        {
            
            foreach (var s in chains)
            {
                if (Array.IndexOf(alf, s.ToString()) == -1)
                    return false;

            }
            return true;
        }
        public static void Check(string[] alf, int multiplicity, string startChains, string endChains,int a, int b)
        {
            checkFormatAlf(alf);
            checkMultiplicitySize(multiplicity);
            if(chainsInAlf(alf, startChains) ==false)
                throw new StartSymbolNotBelongException();
            if (chainsInAlf(alf, endChains) == false)
                throw new EndSymbolNotBelongException();
            if (checkSizeChains(startChains) == false)
                throw new StartSymbolSizeException();
            if (checkSizeChains(endChains) == false)
                throw new EndSymbolSizeException();
            checkRange(a,b);
        }
    }
}
