using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05
{
    //  部分类（分布类）
    //  partial（关键字）
    //  编译时有partial的一起编译
    //  private修饰的成员，同一部分类都可用
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            #region 后台加个控件，设计界面不好显示，运行时会显示
            ////  后台加个按键      后台麻烦
            //左、上、宽得控件位置和大小
            //Button but = new Button();
            //but.Text="Hello，you are my son's frend";
            //but.Left=10;
            ////but.Right=30;//Right 为只读
            //but.Top=20;
            //but.Width=400;

            //this.Controls.Add(but);//   把实例but加到界面中
            #endregion
        }
    }
}
