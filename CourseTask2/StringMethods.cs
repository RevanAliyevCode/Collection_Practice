using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTask
{
    public static class StringMethods
    {
        public static bool ValidString(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
