using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGeneric
{
    class Program
    {
        static void Main(string[] args)
        {

            int iValue = 123;
            string sValue = "abc";
            DateTime dtValue = DateTime.Now;

            Console.WriteLine("****************常规调用****************");
            {
                CommonMethod.ShowInt(iValue);
                CommonMethod.ShowString(sValue);
                CommonMethod.ShowDateTime(dtValue);
            }

            Console.WriteLine("****************object调用****************");
            {
                CommonMethod.ShowObject(iValue);
                CommonMethod.ShowObject(sValue);
                CommonMethod.ShowObject(dtValue);
            }

            Console.WriteLine("****************泛型调用****************");
            {
                GenericMethod.Show<int>(iValue);
                GenericMethod.Show(sValue); // 可以省略，自动推算
                GenericMethod.Show<DateTime>(dtValue);
            }

            Console.WriteLine("****************Monitor****************");
            {
                Monitor.Show(iValue);
            }

            Console.WriteLine("****************约束****************");
            {
                People people = new People
                {
                    Id = 11,
                    Name = "张三"
                };
                Teacher teacher = new Teacher
                {
                    Id = 12,
                    Name = "李老师"
                };
                Student student = new Student
                {
                    Id = 13,
                    Name = "赵同学"
                };
                //Constraint.Show<People>(people);
                Constraint.Show<Teacher>(teacher);
                //Constraint.Show<Student>(student);
            }

            Console.WriteLine("****************协变&异变****************");
            {
                People people = new Teacher();
                //IList<People> peoples = new List<Teacher>();
                IEnumerable<People> peoples = new List<Teacher>();
            }

            Console.WriteLine("****************泛型缓存****************");
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(GenericCache<int>.GetCache());
                    Thread.Sleep(10);
                    Console.WriteLine(GenericCache<long>.GetCache());
                    Thread.Sleep(10);
                    Console.WriteLine(GenericCache<DateTime>.GetCache());
                    Thread.Sleep(10);
                    Console.WriteLine(GenericCache<string>.GetCache());
                    Thread.Sleep(10);
                }
            }

            Console.WriteLine("****************Monitor****************");
            {
                Monitor.Show();
            }
        }
    }
}
