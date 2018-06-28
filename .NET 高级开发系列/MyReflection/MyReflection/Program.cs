using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************API使用****************");
            {
                // 1.加载程序集(加载不会错，但是如果没有依赖项，使用的时候会错)
                //Assembly assembly = Assembly.Load("MyReflection.Model");  // 从当前目录加载(dll名称无后缀)
                Assembly assembly = Assembly.LoadFile(@"E:\MyGitHub\Blog\.NET 高级开发系列\MyReflection\MyReflection.Model\bin\Debug\MyReflection.Model.dll");  // 完整路径加载
                //Assembly assembly = Assembly.LoadFrom("MyReflection.Model.dll");  // 从当前目录加载(dll名称带后缀)或者完整路径加


                // 2.获取类型信息(根据类的全名称（命门空间.类名）获取类的信息)
                Type type = assembly.GetType("MyReflection.Model.UserInfo`1");
                type = type.MakeGenericType(new Type[] { typeof(int) });  // 注意要重新接收
                

                // 3.创建对象
                // object instance = Activator.CreateInstance(type);  // 调用无参构造函数
                object instance = Activator.CreateInstance(type, new object[] { 1000 });   // 调用有参数构造


                // 4.读取私有字段 
                object _id = type.GetField("_id", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(instance);
                Console.WriteLine("私有字段（_id）：{0}", _id);

                // 5.设置属性值
                type.GetProperty("Name").SetValue(instance, "张三");
                type.GetProperty("Age").SetValue(instance, 18);

                // 6.读取属性值
                //object id = type.GetProperty("Id").GetValue(instance);
                //object name = type.GetProperty("Name").GetValue(instance);
                //object age = type.GetProperty("Age").GetValue(instance);

                // 7.读取属性特性
                //DisplayAttribute idDisplay = (DisplayAttribute)type.GetProperty("Id").GetCustomAttribute(typeof(DisplayAttribute));
                //DisplayAttribute nameDisplay = (DisplayAttribute)type.GetProperty("Name").GetCustomAttribute(typeof(DisplayAttribute));
                //DisplayAttribute ageDisplay = (DisplayAttribute)type.GetProperty("Age").GetCustomAttribute(typeof(DisplayAttribute));

                foreach (var property in type.GetProperties())
                {
                    DisplayAttribute displayAttribute = (DisplayAttribute)property.GetCustomAttribute(typeof(DisplayAttribute));
                    Console.WriteLine("{0}：{1}", displayAttribute.Name, property.GetValue(instance));
                }


                // 8.调用方法
                var show1 = type.GetMethod("Show1");
                show1.Invoke(instance, null);  // 没有参数null或者new object[] {  }

                var show2 = type.GetMethod("Show2");
                show2.Invoke(instance, new object[] { 111 });

                var show3_1 = type.GetMethod("Show3", new Type[] { typeof(int) });
                show3_1.Invoke(instance, new object[] { 123 });

                var show3_2 = type.GetMethod("Show3", new Type[] { typeof(string) });
                show3_2.Invoke(instance, new object[] { "abc" });

                var show4 = type.GetMethod("Show4", BindingFlags.NonPublic | BindingFlags.Instance);
                show4.Invoke(instance, null);

                var show5 = type.GetMethod("Show5");
                //show5.Invoke(instance, null); 
                show5.Invoke(null, null);  // 静态方法不用实例

                var show6 = type.GetMethod("Show6");
                show6 = show6.MakeGenericMethod(new Type[] { typeof(int), typeof(string) });  // 注意要重新接收
                show6.Invoke(instance, new object[] { 123, "abc" });
            }

            Console.WriteLine("****************Monitor****************");
            {
                Monitor.Show();
            }
        }
    }
}
