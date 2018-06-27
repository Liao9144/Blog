using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    /// <summary>
    /// .net 4.0
    /// 只能放在接口或者委托的泛型参数前面
    /// out 协变covariant    修饰返回值 
    /// in  逆变contravariant  修饰传入参数
    public interface IMyList<in inT, out outT>
    {
        void Show(inT t);
        outT Get();
        outT Do(inT t);
    }

    public class MyList<inT, outT> : IMyList<inT, outT>
    {
        public outT Do(inT t)
        {
            throw new NotImplementedException();
        }

        public outT Get()
        {
            throw new NotImplementedException();
        }

        public void Show(inT t)
        {
            throw new NotImplementedException();
        }
    }
}
