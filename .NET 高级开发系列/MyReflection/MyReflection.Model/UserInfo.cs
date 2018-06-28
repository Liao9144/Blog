using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection.Model
{
    public class UserInfo<T> where T : struct
    {
        private T _id;  // 字段

        [Display(Name = "ID")]  // 特性
        public T Id  // 属性
        {
            get { return _id; }
            set { _id = value; }
        }

        [Display(Name = "姓名")]  // 特性
        public string Name { get; set; }  // 属性

        [Display(Name = "年龄")]
        public int Age { get; set; }  // 属性


        public UserInfo()  // 无参构造函数
        {
            Console.WriteLine("这里是{0}的无参构造函数", this.GetType());
        }

        public UserInfo(T id)  // 带参数构造函数
        {
            _id = id;
            Console.WriteLine("这里是{0}的带参数构造函数，参数id是{1}", this.GetType(), id);
        }


        public void Show1()  // 无参方法
        {
            Console.WriteLine("这里是{0}的无参方法Show1", this.GetType());
        }

        public void Show2(int parameter)  // 有参方法
        {
            Console.WriteLine("这里是{0}的有参方法Show2，参数parameter是{1}", this.GetType(), parameter);
        }

        public void Show3(int parameter)  // 重载方法之一
        {
            Console.WriteLine("这里是{0}的重载方法之一Show3，参数parameter是{1}_{2}", this.GetType(), parameter, parameter.GetType());
        }

        public void Show3(string parameter)  // 重载方法之二
        {
            Console.WriteLine("这里是{0}的重载方法之二Show3，参数parameter是{1}_{2}", this.GetType(), parameter, parameter.GetType());
        }

        private void Show4()  // 私有方法
        {
            Console.WriteLine("这里是{0}的私有方法Show4", this.GetType());
        }

        public static void Show5()  // 静态方法
        {
            Console.WriteLine("这里是{0}的静态方法Show5", typeof(UserInfo<T>));
        }

        public void Show6<P1, P2>(P1 parameter1, P2 parameter2)  // 泛型方法
        {
            Console.WriteLine("这里是{0}的泛型方法Show6，参数parameter是{1}_{2}&{3}_{4}", this.GetType(), parameter1, parameter1.GetType(), parameter2, parameter2.GetType());
        }
    }
}
