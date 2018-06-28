using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    public class Monitor
    {
        public static void Show()
        {
            long commonTime = 0;
            long reflectionTime = 0;

            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1000000; i++)
                {
                    List<int> list = new List<int>();
                    list.Clear();
                }
                watch.Stop();
                commonTime = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                Assembly assembly = Assembly.Load("mscorlib");  // 1.动态加载
                Type type = assembly.GetType("System.Collections.Generic.List`1");  // 2.获取类型
                type = type.MakeGenericType(new Type[] { typeof(int) });
                for (int i = 0; i < 1000000; i++)
                {
                    //Assembly assembly = Assembly.Load("mscorlib");  // 1.动态加载
                    //Type type = assembly.GetType("System.Collections.Generic.List`1");  // 2.获取类型
                    //type = type.MakeGenericType(new Type[] { typeof(int) });
                    object instance = Activator.CreateInstance(type);  // 3.创建对象
                    List<int> list = (List<int>)instance;  // 4.接口强制转换
                    list.Clear();  // 5.方法调用
                }
                watch.Stop();
                reflectionTime = watch.ElapsedMilliseconds;
            }

            Console.WriteLine("commonTime={0}ms,reflectionTime={1}ms", commonTime, reflectionTime);
        }
    }
}
