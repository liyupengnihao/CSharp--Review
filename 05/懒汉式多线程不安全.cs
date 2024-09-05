using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    internal class 懒汉式多线程不安全//方法内实例化
    {
        private 懒汉式多线程不安全() { }
        private static 懒汉式多线程不安全 _instance;
        public static 懒汉式多线程不安全 GetInstance()
        {
            if(_instance==null)
            {
                return _instance=new 懒汉式多线程不安全();
            }
            else
                return _instance;
        }
    }
}
