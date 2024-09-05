using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 服务端
{

    public partial class Form1 : Form
    {
        TcpListener _TListener;
        TcpClient _TClient;
        NetworkStream _TStream;
        Thread _thOne;
        Thread _thTwo;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            IPAddress ip = IPAddress.Parse(textBox3.Text);//服务器（本机）地址
            _TListener=new TcpListener(ip, Convert.ToInt32(textBox4.Text));
            _TListener.Start();

            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() =>
            {
                MessageBox.Show("打开成功，等待用户连接");
                _TClient=_TListener.AcceptTcpClient();//等带用户连接
            }));
            Task.WhenAll(tasks).ContinueWith(t =>
            {
                button2.Enabled = true;
                button1.Enabled=false;
                _TStream=_TClient.GetStream();


                _thOne=new Thread(ReadMessage);
                _thOne.IsBackground=true;
                _thOne.Start();
            });





        }
        /// <summary>
        /// 接收信息
        /// </summary>
        private void ReadMessage()
        {
            byte[] bt = new byte[1024*1024];
            int num = _TStream.Read(bt, 0, bt.Length);
            if (num==0)
            {
                MessageBox.Show("连接结束");
            }
            else
            {
                string str = Encoding.UTF8.GetString(bt);
                str=str.Substring(0, num);

                textBox1.Text=DateTime.Now.ToString()+"[接收]:"+str+"\r\n";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] bt = Encoding.UTF8.GetBytes(textBox2.Text);
            _TStream.Write(bt, 0, bt.Length);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  跨线程异常不访问
            Control.CheckForIllegalCrossThreadCalls=false;
            button2.Enabled=false;
            textBox1.Enabled=false;
        }
    }
}
