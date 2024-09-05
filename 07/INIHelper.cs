using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07
{
    internal class INIHelper
    {
        //     private static string iniPath = Application.StartupPath+"D:\\C#语言VS学前练习\\C#学前练习第九天\\INI读写案例\\INIConfig.ini";
        //     StartupPath返回结果:
        //     启动了应用程序的可执行文件的路径。 此路径将会不同，具体取决于是否使用部署 Windows 窗体应用程序 ClickOnce。 ClickOnce 应用程序存储在每个用户应用程序缓存中的
        //     C:\Documents and Settings\用户名 目录。 有关详细信息，请参阅 访问本地数据和 ClickOnce 应用程序中的远程数据。
        private static string _iniPath=Application.StartupPath+"\\INIConfig.ini";
        private static string INIPath
        {
            get { return _iniPath; }
            set { _iniPath = value; }
        }
        /// <summary>
        /// 读取INI文件的值
        /// </summary>
        /// <param name="setion"></param>
        /// <param name="key"></param>
        /// <param name="defval"></param>
        /// <param name="retval"></param>
        /// <param name="size"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]//API用于连接windows的动态连接库kernel32.dll
        //   API函数
        //      程序执行：API函数可以帮助应用程序执行各种任务，如文件操作、网络通信、图形渲染等。
        //      内存分配：API函数还涉及到内存的分配和管理，确保应用程序能够高效地利用系统资源。
        //      资源管理：通过调用API函数，应用程序可以访问和管理各种系统资源，如硬件设备、文件系统等。
        private static extern int GetPrivateProfileString(
            string setion,//节
            string key,//键
            string defval,//值无值时默认返回的值
            StringBuilder retval,//读取的内容，无内容为空
            int size,//返回值最大范围
            string filepath);//ini文件路径
        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(
            string section,//节
            string key,//键
            string val,//值
            string filepath);//文件

        public static string ReadINIValue(string section,string key)//节，键
        {
            StringBuilder retval = new StringBuilder(1024);
            GetPrivateProfileString(section,key,"", retval,1024, _iniPath);
            return retval.ToString();
        }
        public static void WriteINIValue(string section,string key,string val)
        {
            WritePrivateProfileString(section,key,val,_iniPath);
        }
    }
}
