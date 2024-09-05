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
    public delegate void AddOrDelInfo(string Info,bool isRemove);
    public delegate void RemoveInfo(string str);
    public partial class 网口服务端 : Form
    {

        public 网口服务端()
        {
            InitializeComponent();
            AddOrDelInfo+=AddUserListBox1;
            RemoveInfo+=RecMsq;

        }
        AddOrDelInfo AddOrDelInfo;
        RemoveInfo RemoveInfo;
        Socket _socket;
        Thread _thread;
        Thread _thread2;
        Dictionary<string, Socket> dictionary = new Dictionary<string, Socket>();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                //IPAddress ip = IPAddress.Parse(textBox1.Text);
                //int port = Convert.ToInt32(textBox2.Text);
                //TcpListener tl = new TcpListener(ip,port);//只监听

                #region 服务端连接
                IPAddress ip = IPAddress.Parse(textBox1.Text);
                int port = Convert.ToInt32(textBox2.Text);
                IPEndPoint ipEndPoint = new IPEndPoint(ip,port);//监听，连接等socket操作
                _socket =new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//指定方案，使用传输控制协议，传输控制协议
                _socket.Bind(ipEndPoint);//网络与本地终结的连接
                #endregion

                MessageBox.Show("本地终结点连接成功");
                _socket.Listen(10);//监听上限

                _thread=new Thread(ListenFunction);
                _thread.IsBackground=true;
                _thread.Start();

            }
            else
            {
                MessageBox.Show("连接关闭");
            }
        }
        /// <summary>
        /// 后台监听
        /// </summary>
        private void ListenFunction()
        {
            while (true)
            {
                Socket socket = _socket.Accept();//Accept创建连接
                string Info = socket.RemoteEndPoint.ToString();//获得客户终结点信息
                dictionary.Add(Info, socket);//客户终结点信息,Socket类
                Invoke(AddOrDelInfo, Info, false);


                _thread2 = new Thread(ServiceInfo);
                _thread2.IsBackground=true;
                _thread2.Start(socket);//方法要的参数
            }
        }
        /// <summary>
        /// 接收客户信息
        /// </summary>
        /// <param name="obj"></param>
        private void ServiceInfo(object obj)
        {
            Socket socketClient = obj as Socket;//as用于转换为Socket类
            if (socketClient != null)
            {
                while (true)
                {
                    byte[] by = new byte[1024*1024];
                    int length = -1;
                    length=socketClient.Receive(by);//写入缓冲区，并返回比特长度
                    if (length==0)
                    {
                        string str = socketClient.RemoteEndPoint.ToString();
                        Invoke(AddOrDelInfo, str, true);//调用的委托，后面为委托要的参数
                        MessageBox.Show("断开连接,移除客户成功");
                        break;
                    }
                    else
                    {
                        string str = Encoding.UTF8.GetString(by, 0, length);//缓冲区，偏移量，读取数
                        str="接收来自"+socketClient.RemoteEndPoint.ToString()+"的信息："+str;
                        Invoke(RemoveInfo, str);//委托内有分行
                    }
                }
            }
        }
        /// <summary>
        /// 加入或移除listBox控件中
        /// </summary>
        private void AddUserListBox1(string Info,bool isRemove)
        {
            if(isRemove==true)
            {
                listBox1.Items.Remove(Info);
            }
            else
            {
                listBox1.Items.Add(Info);
            }
        }
        /// <summary>
        /// 接收客户信息
        /// </summary>
        private void RecMsq(string str)
        {
            this.textBox4.AppendText(str+"\r\n");
        }
        /// <summary>
        /// 单独对一个客户发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count==0)
            {
                MessageBox.Show("请选择客户");
            }
            else
            {
                foreach (string item in listBox1.SelectedItems)
                {
                    byte[] text = Encoding.UTF8.GetBytes(textBox3.Text);
                    dictionary[item].Send(text);//dictionary[item]内为Socket类
                    string str = "\r\n发送给"+item+":"+textBox3.Text;
                    textBox3.Clear();
                    Invoke(RemoveInfo,str);                   
                }
            }
        }
        /// <summary>
        /// 群发消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string item in dictionary.Keys)
            {
                byte[] text = Encoding.UTF8.GetBytes(textBox3.Text);
                dictionary[item].Send(text);
                string str="\r\n发送给"+item+":"+textBox3.Text;
                textBox3.Clear();
                Invoke(RemoveInfo,str);
            
            }
        }
    }
}
