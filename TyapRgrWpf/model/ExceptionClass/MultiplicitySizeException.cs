using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyapRgrWpf
{
  
    internal class MultiplicitySizeException : Exception
    {
        public MultiplicitySizeException() : base() { }
        public MultiplicitySizeException(string message) : base(message) { }
        public MultiplicitySizeException(string message, Exception inner) : base(message, inner) { }
    }
}
