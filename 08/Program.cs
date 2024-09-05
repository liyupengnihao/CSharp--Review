using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFly fly = new Brid();
            fly.Fly();
            Console.ReadKey();
        }
    }
    #region 接口虚方法
    class animal : IFly
    {
        public virtual void Fly()//虚方法，重写
        {
            Console.WriteLine("animal uncertain fly");
        }
    }

    class Brid : animal
    {
        public override void Fly()
        {
            Console.WriteLine("鸟能飞");
        }
    }
    class Person:IFly
    {
        public void Fly()
        {
            Console.WriteLine("人不能飞");
        }
    }
    //接口
    public interface IFly
    {
        //  接口内的成员不能有任何的实现，只是定义了一组未实现的成员

        //  接口内不允许有访问修饰符 默认为public

        //  接口内只有方法和自动属性（没有字段），不能有构造函数

        //  为了多态，接口不能被实例化
        //  也就是说，接口不能new（不能创建对象）

        //  只要一个类继承了一个接口，这个类就必须要实现这个接口的所有成员

        //  接口与接口之间可以继承，并且可以多继承

        //  接口不能继承类，只能继承接口，但类可以继承接口和类

        //  实现接口的子类必须实现该接口的全部成员

        //  一个类可以同时继承一个类并继承多个接口，但要把继承的父类放在接口前面
        void Fly();
    }
    #endregion
    #region 抽象类
    public abstract class Student
    {
        public abstract void Run();
        public void Jump()
        {
            Console.WriteLine("Can jump");
        }
    }
    public class OneClass:Student
    {
        public override void Run()
        {
            Console.WriteLine("Can run");
        }
    }
    //    抽象类
    //    定义：抽象类是一种不能被实例化的类，它主要用于作为其他类的基类。抽象类使用abstract关键字进行声明。
    //    目的：抽象类的主要目的是提供一个或多个派生类共通的框架，而不提供具体的实现。它强制派生类实现某些方法（通过抽象方法）或遵循特定的结构（通过非抽象成员）。
    //    特性：
    //    抽象类不能被实例化（即不能使用new关键字创建抽象类的实例）。
    //    抽象类可以包含抽象方法和非抽象方法（即具有具体实现的方法）。
    //    如果一个类包含至少一个抽象方法，则该类必须被声明为抽象类。
    //    抽象类可以包含字段、属性、事件、索引器、构造函数（但构造函数不能被声明为抽象）、析构函数以及类型（如委托、接口和嵌套类型）。
    
    
    //    抽象方法
    //    定义：抽象方法是声明在抽象类中的方法，它没有具体的实现（即没有方法体）。抽象方法使用abstract关键字进行声明，并且必须在非抽象派生类中被重写（Override）。
    //    目的：抽象方法的主要目的是为派生类提供一个框架，要求派生类必须实现该方法。这有助于确保派生类具有特定的功能或行为。
    //    特性：
    //    抽象方法没有方法体（即没有大括号{}）。
    //    抽象方法只能声明在抽象类中。
    //    派生类必须实现所有继承的抽象方法，除非派生类也是抽象的。
    #endregion
}
