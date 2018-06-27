using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    /// <summary>
    /// 字典缓存：静态属性常驻内存
    /// </summary>
    public class DictionaryCache
    {
        private static Dictionary<Type, string> _TypeTimeDictionary = null;
        static DictionaryCache()
        {
            Console.WriteLine("This is DictionaryCache 静态构造函数");
            _TypeTimeDictionary = new Dictionary<Type, string>();
        }
        public static string GetCache<T>()
        {
            Type type = typeof(Type);
            if (!_TypeTimeDictionary.ContainsKey(type))
            {
                _TypeTimeDictionary[type] = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
            }
            return _TypeTimeDictionary[type];
        }
    }


    /// <summary>
    /// 每个不同的T，都会生成一份不同的副本
    /// 适合不同类型，需要缓存一份数据的场景，效率高
    /// 不能主动释放
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericCache<T>
    {
        private static string _TypeTime = "";

        static GenericCache()
        {
            Console.WriteLine("This is GenericCache 静态构造函数");
            _TypeTime = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
        }

        public static string GetCache()
        {
            return _TypeTime;
        }
    }
}
