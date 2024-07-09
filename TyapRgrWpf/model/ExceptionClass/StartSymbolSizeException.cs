using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyapRgrWpf
{
   
    internal class StartSymbolSizeException : Exception
    {
        public StartSymbolSizeException() : base() { }
        public StartSymbolSizeException(string message) : base(message) { }
        public StartSymbolSizeException(string message, Exception inner) : base(message, inner) { }
    }
}
