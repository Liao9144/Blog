using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class Generic
    {
        /// <summary>
        /// 一个类来满足不同的具体类型，做相同的事
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class GenericClass<T>
        {
            private T _t;
        }

        /// <summary>
        /// 一个接口来满足不同的具体类型的接口，做相同的事
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IGenericInterface<T>
        {
            T GetT(T t);  // 泛型类型的返回值
        }

        public class CommonClass
            //: GenericClass<int>  // 必须指定
            : IGenericInterface<int>  // 必须指定
        {
            public int GetT(int t)
            {
                throw new NotImplementedException();
            }
        }

        public class GenericClassChild<T>
            //: GenericClass<T>
            : GenericClass<int>, IGenericInterface<T>
        {
            public T GetT(T t)
            {
                throw new NotImplementedException();
            }
        }

        public delegate void SayHi<T>(T t);  // 泛型委托
    }
}
