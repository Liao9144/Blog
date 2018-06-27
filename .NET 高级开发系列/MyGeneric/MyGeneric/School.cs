using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void SayHi()
        {
            Console.WriteLine("Hi");
        }
    }

    public interface ITeacher
    {
        void Lecture();
    }

    public interface IStudent
    {
        void Work();
    }

    public class Teacher : People, ITeacher
    {
        public void Lecture()
        {
            Console.WriteLine("讲课");
        }
    }

    public class Student : People, IStudent
    {
        public void Work()
        {
            Console.WriteLine("做作业");
        }
    }
}
