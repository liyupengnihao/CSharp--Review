using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region out ref介绍
            //out 调用方法中输入值（可不初始化，但要有变量)
            //ref 调用方法中输入值（要初始化)
            //ref：通常用于那些需要在方法内被修改，但在调用方法之前已经有一个明确值的变量。它也可以用于返回多个值，但更常见的用途是修改传入的值。
            //out：最适合用于方法需要返回多个值，并且其中一些值在方法执行之前可能未知或未初始化的场景。out 参数还常用于需要从方法中获取状态或结果的场景，尤其是当这些方法需要遵循某种特定的设计模式（如 Try 模式）时。
            #endregion

            #region params介绍
            //params 关键字用于在方法定义中指定一个参数
            //该参数可以接受零个或多个参数值
            //当使用 params 关键字时，必须将该参数指定为方法中的最后一个参数
            //并且该参数的类型必须是一维数组
            //这使得在调用方法时，可以传递指定类型的零个或多个参数，
            #endregion

            #region 方法重载介绍
            //  方法的重载：方法名称相同，参数列表不同
            //  方法重载（Method Overloading）是面向对象编程中的一个特，
            //  它允许在同一个类中定义多个同名的方法
            //  只要这些方法的参数列表不同（参数个数不同、参数类型不同）即可
            //                           看参数个数、类型
            //  方法重载与方法的返回类型无关，即只要参数列表不同
            //  方法名可以相同，并且可以有不同的返回类型。
            #endregion
        }
        public void TestOne(out int a)//可不用初始化，当方法内要初始化
        {
            a=1;
        }
        public void TestTwo(ref int b)//方法外部要初始化，内部无所谓
        {

        }
        public void TestThree(params int[] number)//  params关键字要为形参列表中最后一个参数
        {

        }
    }
}
