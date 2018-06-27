using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class Monitor
    {
        public static void Show(int iValue)
        {
            long commonTime = 0;
            long objectTime = 0;
            long genericTime = 0;

            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 100000000; i++)
                {
                    ShowInt(iValue);
                }
                watch.Stop();
                commonTime = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 100000000; i++)
                {
                    ShowObject(iValue);
                }
                watch.Stop();
                objectTime = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 100000000; i++)
                {
                    Show<int>(iValue);
                }
                watch.Stop();
                genericTime = watch.ElapsedMilliseconds;
            }

            Console.WriteLine("commonTime={0}ms,objectTime={1}ms,genericSecond={2}ms"
                , commonTime, objectTime, genericTime);
        }

        private static void ShowInt(int iParameter) { }
        private static void ShowObject(object oParameter) { }
        private static void Show<T>(T tParameter) { }


        public static void Show()
        {
            long dictionaryCacheTime = 0;
            long genericCacheTime = 0;

            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 100000000; i++)
                {
                    DictionaryCache.GetCache<Monitor>();
                }
                watch.Stop();
                dictionaryCacheTime = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 100000000; i++)
                {
                    GenericCache<Monitor>.GetCache();
                }
                watch.Stop();
                genericCacheTime = watch.ElapsedMilliseconds;
            }

            Console.WriteLine("dictionaryCacheTime={0}ms,genericCacheTime={1}ms"
                , dictionaryCacheTime, genericCacheTime);
        }
    }
}
