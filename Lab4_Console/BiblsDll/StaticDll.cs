using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblsDll
{
    public class StaticDll
    {
        public static double RectangleArea(string x1, string y1, string x2, string y2)
        {
            return Math.Abs(Convert.ToDouble(x1) - Convert.ToDouble(x2)) * 
                   Math.Abs(Convert.ToDouble(y1) - Convert.ToDouble(y2));
        }
    }
}
