using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            INIHelper.WriteINIValue(textBox1.Text.Trim(),"IP",textBox2.Text.Trim());
            INIHelper.WriteINIValue(textBox1.Text.Trim(),"端口",textBox3.Text.Trim());
            INIHelper.WriteINIValue(textBox1.Text.Trim(),"插槽号",textBox7.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text=INIHelper.ReadINIValue(textBox4.Text,"IP");
            textBox6.Text=INIHelper.ReadINIValue(textBox4.Text, "端口");
            textBox8.Text=INIHelper.ReadINIValue(textBox4.Text, "插槽号");
        }
    }
}
