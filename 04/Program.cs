using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  属性
            //  属性（Properties）是类的一种成员，用于提供对私有字段的访问。

            //  属性的基本组成
            //  名称：属性的名称通常用于描述它所存储的数据的类型或意义。
            //  类型：属性有一个数据类型，这决定了它可以存储什么类型的值。
            //  get访问器：这是一个特殊的方法，用于返回属性的值。它不带参数，并且其返回类型必须与属性的类型相匹配。
            //  set访问器（可选）：这也是一个特殊的方法，用于设置属性的值。它带有一个参数，这个参数的类型必须与属性的类型相匹配。

            //  属性的优点
            //  封装：属性提供了一种封装字段的方式，使得类的内部实现细节得以隐藏。
            //  数据验证：在set访问器中，可以加入逻辑来验证尝试设置的值是否符合某些条件。如果不符合，可以拒绝设置该值。
            //  只读和只写属性：通过省略get或set访问器，可以创建只读或只写属性。
            //  灵活性：属性的实现可以随着需求的变化而变化，而不需要修改使用该属性的代码。
        }
        // 私有字段  
        private string _name="无名氏";

        // 公共属性  
        public string Name
        {
            // get访问器  
            get { return _name; }

            // set访问器，包括简单的数据验证  
            set
            {
                if (string.IsNullOrEmpty(value))//  IsNullOrEmpty为空("")或者null则true，否则为false
                {
                    throw new ArgumentException("Name cannot be null or empty.");// Name不能为null或者空
                }
                else
                {
                    _name = value;
                }
            }
        }
    }
}
