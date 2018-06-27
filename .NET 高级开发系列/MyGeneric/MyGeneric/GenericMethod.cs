using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class GenericMethod
    {
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericMethod).Name, tParameter, tParameter.GetType().Name);
        }
    }
}
