using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region 序列化和反序列化方法
            //模拟序列化和反序列化.SerialPersonMessage(new Person(),"李四",18,Person.Gender.Female,Application.StartupPath+"\\序列化.txt");
            //Person person = 模拟序列化和反序列化.DeserialPersonMessage(Application.StartupPath+"\\序列化.txt");
            #endregion
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
