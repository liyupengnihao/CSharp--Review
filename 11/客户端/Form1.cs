using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//  Tcp
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
//
using System.Text;
//  线程异步
using System.Threading;
using System.Threading.Tasks;
//
using System.Windows.Forms;

namespace 客户端
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        TcpClient _TcpClient;//Tcp连接
        NetworkStream _NS;//网络中传输数据
        Thread _TH;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {// 建立连接
                //_TcpClient = new TcpClient(textBox3.Text.Trim(), Convert.ToInt32(textBox4.Text.Trim()));//string的ip与int的端口号
                //                                                                                        //   初始化 System.Net.Sockets.TcpClient 类的新实例并连接到指定主机上的指定端口。

                _TcpClient=new TcpClient();
                _TcpClient.Connect(textBox3.Text.Trim(), Convert.ToInt32(textBox4.Text.Trim()));

                _NS =_TcpClient.GetStream(); //连接后_TcpClient.GetStream数据赋值给_NS
                                             //  返回用于发送和接收数据的 System.Net.Sockets.NetworkStream。

               
                _TH=new Thread(ReadMessage);
                _TH.IsBackground = true;
                _TH.Start();
                button2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;

            }
            catch
            {
                MessageBox.Show("连接失败");
            }
            //  接收数据
           
        }
        /// <summary>
        /// 读信息
        /// </summary>
        private void ReadMessage()
        {
            while (true)
            {
                byte[] bt = new byte[1024*1024]; //1M
                int num = _NS.Read(bt, 0, bt.Length);
                if(num==0)
                {
                    MessageBox.Show("断开连接");
                    break;
                }
                else
                {
                    string str = Encoding.UTF8.GetString(bt);
                    str=str.Substring(0, num);
                    textBox1.Text+=DateTime.Now.ToString()+"[接收]:"+str+"\r\n";
                }
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] bt=Encoding.UTF8.GetBytes(textBox2.Text.Trim());
            _NS.Write(bt, 0, bt.Length);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  跨线程异常不访问
            Control.CheckForIllegalCrossThreadCalls=false;
            textBox1.Enabled=true;
            button2.Enabled=false;
        }
    }
}
