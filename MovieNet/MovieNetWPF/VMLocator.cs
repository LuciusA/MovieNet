using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetWPF
{
    class VMLocator
    {
        public static MainViewModel MainVM { get; } = new MainViewModel();
    }
}
