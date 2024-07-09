using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyapRgrWpf
{
    class RangeException:Exception
    {
        public RangeException() : base() { }
        public RangeException(string message) : base(message) { }
        public RangeException(string message, Exception inner) : base(message, inner) { }
    }
}
