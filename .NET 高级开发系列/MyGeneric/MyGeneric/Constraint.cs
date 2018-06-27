using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class Constraint
    {
        public static void Show<T>(T tParameter)
            where T : People, ITeacher, new()
        {
            //Console.WriteLine($"{tParameter.Id}_{tParameter.Name}");
            //Console.WriteLine($"{(People)(tParameter).Id}_{(People)(tParameter).Name}");

            Console.WriteLine($"{tParameter.Id}_{tParameter.Name}");
            tParameter.SayHi();
            tParameter.Lecture();
        }

        public static void ShowBase(People people)
        {
            Console.WriteLine($"{people.Id}_{people.Name}");
        }
    }
}
