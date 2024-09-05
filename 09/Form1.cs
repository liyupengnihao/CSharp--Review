using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09
{
    public delegate void StudentMessage(string name, int age);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //async与await实现异步
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                MessageBox.Show("素菜好了");
            });
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                MessageBox.Show("荤菜好了");
            });
            MessageBox.Show("来吃饭了");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //委托和其委托方法返回值和参数列表要相同  
            StudentMessage student = new StudentMessage(Student.Message);
            StudentMessage studentTwo = Student.Message;//C#2.0及更高可用
            student("张三", 18);
            studentTwo("李四", 20);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  简化委托的使用
            //  简化定义委托的作用


            //  系统预订的类型
            //  Action 无参无返回值
            //  Action<T1,>最多16个参数，有参无返回值

            //  Func<Out> 无参有返回值，Out只代表是返回值
            //  Func<T1,T2,Out>最多16个参数，有参有返回值  

            Action action = () => SayClass.SayHi();
            action();//执行
            Action<string> actionThree = t => SayClass.SayHi(t);
            actionThree("李四");
            Action actionOne = SayClass.SayHi;
            actionOne();
            Action<string> actionTwo = SayClass.SayHi;
            actionTwo("张三");

            Func<string> fun = YunShuang.Shuang;
            MessageBox.Show(fun());
            Func<int, int, int> funOne = YunShuang.Shuang;
            MessageBox.Show(funOne(3, 4).ToString());


        }
        /// <summary>
        /// 覆盖创建文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath+"\\CSV.csv";
            using (FileStream fs = File.Create(path))
            {
                MessageBox.Show("文件以创建");
            }
        }
        /// <summary>
        /// 写入选定文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //  CSV文件特点
            /*  
                纯文本格式：CSV文件以纯文本形式存储数据，不依赖于特定的软件或平台，因此具有极高的通用性和可移植性。
                逗号分隔：在CSV文件中，字段之间通过逗号（或其他指定的分隔符，如制表符、分号等）进行分隔，每行表示一个数据记录。
                简单易懂：由于其纯文本和逗号分隔的特性，CSV文件易于被人类阅读和编辑，同时也便于计算机程序处理。
            */


            //  CSV文件结构
            /*
                字段定义：CSV文件的第一行通常用于定义字段名，即数据的列标题。后续行则包含相应的数据值，每个值对应一个字段。
                特殊字符处理：如果字段值中包含分隔符（如逗号）、换行符或双引号等特殊字符，则需要使用双引号将字段值包裹起来，并在双引号内的特殊字符前加上转义字符（如双引号本身）以确保数据的准确性和完整性。
             */


            //  CSV文件应用场景
            /*
                数据存储：CSV文件是一种简单、轻量级的数据存储格式，适用于存储结构化数据，如表格数据、日志数据等。
                数据交换：CSV文件在数据交换中具有广泛的应用。它可以作为不同系统之间的中间格式，用于数据的导入和导出。许多软件和数据库工具都支持CSV文件的导入和导出功能，使得数据的迁移和共享变得简单和灵活。
                数据分析：CSV文件也被广泛用于数据分析和统计。许多数据分析软件和编程语言（如Excel、Python、R等）都提供了CSV文件的读取和处理功能。通过将数据导入到这些工具中，可以进行各种数据分析和可视化操作。
             */

            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog()==DialogResult.OK)
            {
                string path = open.FileName;
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))//路径，追加，编码
                {
                    sw.WriteLine(textBox1.Text+","+textBox2.Text+"\r\n");
                    MessageBox.Show("内容已写入");
                }

            }
        }

        /// <summary>
        /// 写入特定文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath+"\\CSV.csv";
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
            {
                sw.Write(textBox1.Text+","+textBox2.Text+"\r\n");
                MessageBox.Show("内容已写入");
            }

        }
        /// <summary>
        /// 读取选定文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog()==DialogResult.OK)
            {
                string path = open.FileName;
                DataTable dt = CSVHelper.ReadCSV(path);
                for (int i = 0; i<dt.Rows.Count; i++)//行
                {
                    //第一行为标题无法如此读值
                    DataRow dr = dt.Rows[i];
                    comboBox1.Items.Add(dr[0].ToString());
                    comboBox2.Items.Add(dr[1].ToString());
                }
            }
        }
        /// <summary>
        /// 读取特定文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath+"\\CSV.csv";
            DataTable dt = CSVHelper.ReadCSV(path);
            for (int i = 0; i<dt.Rows.Count; i++)//行
            {
                //第一行为标题无法如此读值
                DataRow dr = dt.Rows[i];
                comboBox1.Items.Add(dr[0].ToString());
                comboBox2.Items.Add(dr[1].ToString());
            }
        }

    }
    public class Student
    {
        public static void Message(string name, int age)
        {
            MessageBox.Show($"学生{name}的年龄是{age}");
        }
    }
    public class SayClass
    {
        public static void SayHi()
        {
            MessageBox.Show("你好");
        }
        public static void SayHi(string name)
        {
            MessageBox.Show($"你好{name}");
        }
    }
    public class YunShuang
    {
        public static string Shuang()
        {
            return "返回";
        }
        public static int Shuang(int x, int y)
        {
            return x+y;
        }
    }
}
