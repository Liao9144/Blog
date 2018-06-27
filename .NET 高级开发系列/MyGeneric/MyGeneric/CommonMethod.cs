using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class CommonMethod
    {
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
             nameof(CommonMethod), iParameter, iParameter.GetType().Name);
        }

        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
             nameof(CommonMethod), sParameter, sParameter.GetType().Name);
        }

        public static void ShowDateTime(DateTime dtParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
            nameof(CommonMethod), dtParameter, dtParameter.GetType().Name);

        }

        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
            nameof(CommonMethod), oParameter, oParameter.GetType().Name);
        }
    }
}
