using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07
{
    internal class 访问修饰符
    {
        //  C#中的访问修饰符   五个
        //  public      公开的
        //  private     私有的     只能在当前类的内部访问
        //  protected   受保护的   当前类和子类中被访问
        //  internal    内部的     当前程序集中（当前项目中）   修饰类时在同一个项目中和public的权限是一样的
        //  protected internal     两者相加

        //  修饰类的只有  public  internal    五个都可以修饰类的成员
        //  类默认是internal



        //  虽然它们不是访问修饰符，但在C#中还有一些其他与访问性相关的关键字和修饰符，如：
        //  sealed：指示一个类不能被继承。
        //  abstract：指示一个类只能作为其他类的基类，或者一个方法没有实现体，需要在派生类中实现。
        //  static：修饰类时表示该类是静态类，不能实例化，其成员为静态。




        //  子类的访问权限不能高于父类   public高与internal    
        //  否则会暴露父类的成员
    }
}
