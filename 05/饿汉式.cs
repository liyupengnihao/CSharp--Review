using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    internal class 饿汉式
    {
        private 饿汉式() { }//类下实例化
        private static 饿汉式 _instance=new 饿汉式();
        public static 饿汉式 GetInstance()
        {
            return _instance;
        }
    }
}
