using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gprinter_Zxh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//票据窗口
        {
            Form2 form = new Form2();
            form.UserName = btn_USB.Text.Trim();//去掉左右空格
            form.Show();//打开窗体
            this.Hide();

            //string userName = txtUserName.Text.Trim();//获取用户名
            //string pwd = txtPwd.Text.Trim();

            //using Sqlconnection conn = new Sqlconnection("Data Sourse=.:DataBase=MyStudentDemo:Integrated Security=ture")
            //{
            //    conn.open();
            //SqlCommand command = new SqlCommand(string.Format_"select count(*)from student where sname='{0}' and pwd ='{1}'",userName,pwd), conn);
            //int cout =Convert.ToInt32(command.ExecuteNonQuery());
            //if(count >0 )
            //{
            //    Form2 form = new Form2;
            //    form.Show();
            //    this.Hide;
            //}
            //else
            //{
            //    MessageBox.Show("用户名密码不匹配！")//登录
            ////}
            //}
        }


        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }

        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("版本：v1.0 作者：张旭瀚 blog.csdn.net/zxh1592000", "使用帮助", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button1_Click_1(object sender, EventArgs e)//标签窗口
        {
            Form3 form = new Form3();
            form.UserName = btn_USB.Text.Trim();//去掉左右空格
            form.Show();//打开窗体
            this.Hide();

        }
    }
}
