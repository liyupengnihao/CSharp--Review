using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 开始
{

    //栈：
    //定义与特性：栈是一种先进后出（LIFO, Last In First Out）的数据结构，用于存储局部变量、函数参数、返回地址等信息。栈是由系统自动分配和管理的，具有自动分配和释放内存的能力。
    //内存位置：栈通常位于内存的高地址区域，由操作系统或运行时环境在程序启动时分配。
    //主要用途：
    //存储函数的调用栈，即函数调用的顺序和相关信息。
    //存储局部变量和函数参数，这些变量在函数执行完毕后会被自动释放。
    //存储返回地址，以便函数执行完毕后能够返回到正确的位置。

    //堆：
    //堆是一个动态分配内存的区域，用于存储程序运行时动态分配的数据结构，如对象、数组等。堆的分配和释放需要程序员手动管理（或通过垃圾回收机制自动管理using，在某些语言中）。
    //内存位置：堆位于内存的较低地址区域（相对于栈而言），其大小通常受限于系统的内存管理策略和硬件资源。
    //主要用途：
    //存储大型数据结构或需要长时间存在的数据。
    //允许程序员动态地申请和释放内存空间，以满足程序的灵活性和可扩展性。
    public struct Student
    {
        public string _name;
        public int _age;
        public Gender _gender;
        public int _ID;
        public string _grade;
    }
    public enum Gender
    {
        男,女
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student zs = new Student();//栈有内存new后堆也有内存
            zs._name="张三";
            zs._age=18;
            zs._gender=Gender.男;
            zs._grade="高三";

            Student ls;//栈有内存，堆无内存，初始化后堆内才有内存
            ls._name="李四";
            ls._age=18;
            ls._gender=Gender.女;
            ls._grade="高三";
            Console.WriteLine(zs._name+zs._age+zs._gender+zs._grade);
            Console.ReadKey();
        }
    }
}
