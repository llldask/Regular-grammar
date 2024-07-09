using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyapRgrWpf
{
    internal class AlfException : Exception
    {
        public AlfException() : base() { }
        public AlfException(string message) : base(message) { }
        public AlfException(string message, Exception inner) : base(message, inner) { }
    }
}
