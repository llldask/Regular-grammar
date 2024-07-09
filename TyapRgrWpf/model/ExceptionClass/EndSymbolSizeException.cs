using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyapRgrWpf
{
    internal class EndSymbolSizeException : Exception
    {
        public EndSymbolSizeException() : base() { }
        public EndSymbolSizeException(string message) : base(message) { }
        public EndSymbolSizeException(string message, Exception inner) : base(message, inner) { }
    }
}
