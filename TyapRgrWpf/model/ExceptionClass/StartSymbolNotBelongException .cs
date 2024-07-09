using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyapRgrWpf
{
    internal class StartSymbolNotBelongException : Exception
    {
        public StartSymbolNotBelongException() : base() { }
        public StartSymbolNotBelongException(string message) : base(message) { }
        public StartSymbolNotBelongException(string message, Exception inner) : base(message, inner) { }
    }
}
