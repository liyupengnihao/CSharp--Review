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

namespace _10
{
    public partial class 网口客户端 : Form
    {
        public 网口客户端()
        {
            InitializeComponent();
        }
        Socket socketClient;
        Thread thread;
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            #region 客户端连接
            IPAddress ip = IPAddress.Parse(textBox1.Text);
            int port = Convert.ToInt32(textBox2.Text);
            IPEndPoint ipe=new IPEndPoint(ip, port);//将网络终结点设置为ip和端口
            socketClient=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            #endregion

            textBox3.Text="等待连接......";
            socketClient.Connect(ip, port);
            textBox3.Text="连接成功";

            thread=new Thread(ReceiveMsg);
            thread.IsBackground=true;
            thread.Start();
        }
        /// <summary>
        /// 接收信息
        /// </summary>
        private void ReceiveMsg()
        {
            byte[] bt = new byte[1024*1024];
            int length = -1;
            length=socketClient.Receive(bt);//写入缓冲区，返回长度
            if(length==0)
            {
                Invoke(new Action(()=>this.textBox3.AppendText("\r\n断开连接")));
            }
            else
            {
                string str = Encoding.UTF8.GetString(bt);
                string msgstr="接收来自"+socketClient.RemoteEndPoint.ToString()+"的信息："+str;
                Invoke(new Action(()=>this.textBox3.AppendText("\r\n"+msgstr)));
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] bt=Encoding.UTF8.GetBytes(textBox4.Text);
            string str = "发送到"+socketClient.RemoteEndPoint+"信息："+textBox4.Text;
            socketClient.Send(bt);
            Invoke(new Action(()=>this.textBox4.AppendText("\r\n"+str)));
            
        }
    }
}
