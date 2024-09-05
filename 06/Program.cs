using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAndPathOfClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  API是程序与处理器接口的一组命令集，它允许程序请求系统服务或与其他程序进行交互
            //  .NET Framework为C#提供了大量的类库和API，这些API封装了底层的系统调用和常用功能。
            //  开发者可以通过这些API来编写高效的C#程序，而无需深入了解底层的系统细节。

            //  在C#中，开发者还可以创建自己的API，以供其他程序或模块调用。
            //  这通常通过定义接口（Interface）或类（Class）中的方法来实现，并通过适当的访问修饰符（如public）来暴露这些方法。




            //  Path类全为静态方法
            //  Path.ChangeExtension();//   路径末尾追加或替换后缀名（扩展名与后缀名没什么区别）
            //  Path.Combine();//   路径拼接
            //  Path.GetExtension();//  获取路径中的后缀名
            //  Path.GetDirectoryName();//  获取路径中的文件夹路径，如果末尾存在文件名，则去掉文件名
            //  Path.GetFileNameWithoutExtension();//   获取路径中的文件名去除后缀名
            //  Path.GetFileName();//   获取路径中的文件名（包括后缀名）




            //  根目录、扩展名、后缀名
            //  window系统中跟目录为C:\
            //  Linux系统中为/



            //  列表（List<T>）


            #region C#入门学习内容和目标
            //  C#作为一门入门语言，通常包括以下几个方面的学习内容和目标：

            //  安装和环境设置：首先你需要安装Visual Studio或其他支持C#的集成开发环境（IDE），学会创建和配置新的项目。

            //  基本语法：从变量声明、数据类型（如int、string）、运算符、控制流（if-else、for循环）入手，理解函数和类的基本概念。

            //  面向对象编程：掌握类、对象、构造函数、属性和方法等OOP核心概念，以及继承、封装和多态。

            //  数组和集合：理解数组和列表（List<T>）的使用，这是数据存储和操作的基础。

            //  文件I/O：学习如何读写文件和处理文本数据。

            //  异常处理：学习如何捕获和处理运行时可能出现的错误。

            //  基本的数据结构和算法：简单理解栈、队列、哈希表等数据结构。

            //  Windows Forms或WPF界面设计：如果打算做桌面应用程序，需要学习使用C#进行图形用户界面（GUI）设计。

            //  C#基础库认识：了解.NET Framework提供的基础库，如System.IO、DateTime等。

            //  完成以上内容后，你应该能够独立编写简单的C#程序，并具备继续深入学习高级特性和框架的基础。记住，不断练习和项目实战是提升的关键。
            #endregion

            #region Hashtable 哈希表
            Hashtable ht = new Hashtable();
            ht.Add("nihao",12);//键值对
            ht["nihao"]=13;//改变键”nihao“的值
            #endregion

            #region 文件操作
            string path = "D:\\C#语言VS学前练习\\大复习02\\APIAndPathOfClass\\bin\\Debug\\text.txt";
            string text = "今天天气不好";
            //File.Create(path);
            byte[] bt = Encoding.UTF8.GetBytes(text);
            File.WriteAllBytes(path,bt);
            File.AppendAllText(path, "\r\n"+text);
            StreamReader sr = new StreamReader(path,Encoding.UTF8);
            string[] textRead =File.ReadAllLines(path,Encoding.UTF8);
            foreach(var item in textRead)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            #endregion

            #region 拆箱装箱
            #region 此处没有任何的装箱和拆箱
            string str = "123";
            int n = Convert.ToInt32(str);
            //  装箱和拆箱判断：两种类型是否存在继承关系
            //  有继承关系则（有可能）存在装箱和拆箱
            //  无继承关系一定没有装箱和拆箱
            #endregion
            //  装箱：把值类型转换为引用类型
            //  拆箱：把引用类型转换为值类型

            //  引用类型是指存储对其值的引用的数据类型。
            //  引用类型在赋值或传参时，不会复制对象本身，而是复制一个指向对象实例的引用（或指针）。
            //  这意味着，通过不同的引用变量可以访问和操作同一个对象实例。
            //  常见引用类型：字符串（String）、类（Class）、接口（Interface）、数组（Array）、委托（Delegate）、对象（Object）

            //  一组基本的数据类型，它们直接包含数据，并且数据存储在栈（Stack）上（对于局部变量和参数）或直接在包含它们的值类型变量中（对于字段）
            //  值类型在赋值或作为参数传递给方法时，会复制其值，而不是复制引用（或指针）。
            //  这意味着每个值类型变量都保存有自己的数据副本，对这些副本的修改不会影响到其他变量。
            #endregion
        }
    }
}
