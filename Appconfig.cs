using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Line
{
    internal static class Appconfig
    {
        public static FormatOptions format { get; set; } = FormatOptions.F;
        public static int precision { get; set; } = 2;
    }
}
