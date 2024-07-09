using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyapRgrWpf
{
    internal class AlfSizeException : Exception
    {
        public AlfSizeException() : base() { }
        public AlfSizeException(string message) : base(message) { }
        public AlfSizeException(string message, Exception inner) : base(message, inner) { }
    }
}
