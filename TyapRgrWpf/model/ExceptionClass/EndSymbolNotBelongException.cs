using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyapRgrWpf
{
    
    internal class EndSymbolNotBelongException : Exception
    {
        public EndSymbolNotBelongException() : base() { }
        public EndSymbolNotBelongException(string message) : base(message) { }
        public EndSymbolNotBelongException(string message, Exception inner) : base(message, inner) { }
    }
}
