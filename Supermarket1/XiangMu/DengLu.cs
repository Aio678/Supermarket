using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace XiangMu
{
    public partial class DengLu : Form
    {
        public DengLu()
        {
            InitializeComponent();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            string username, password;
            username = textBox1.Text;
            password = textBox2.Text;
            // 账号中不能出现中文汉字
            string pat = @"[\u4e00-\u9fa5]";
            Regex rg = new Regex(pat);
            Match mh = rg.Match(textBox1.Text);
            if (mh.Success)
            {
                MessageBox.Show("不允许输入中文汉字");
                return;
            }
            //账号密码是否为空否者提示输入账号密码
            if (textBox1.Text=="")
            {
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;

            }
            if (textBox2.Text == "")
            {
                label2.Visible = true;
                label3.Visible = false;
            }
            else
            {
                label2.Visible = false;
                label3.Visible = true;
            }

            //  数据库中查找账号  如果账号存在则登录成功否则登录失败
            string sql = "select AdminName,AdminPwd from Administrator where AdminName='" + username + "' and AdminPwd= '" + password + "'";
            DataTable r = DBHelper.GetDataTable(sql);
            if (r.Rows.Count > 0)
            {
                label3.Visible = false;
                MessageBox.Show("登录成功！");
                this.Hide();
                guanlixitong glxt = new guanlixitong();
                glxt.Show();
            }
            else
            {
                //MessageBox.Show("账号或密码错误，请重新输入。", "提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ZhuCe zc = new ZhuCe();
            zc.ShowDialog();
        }

        private void denglu_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
        }

        private void DengLu_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ZhuCe zc = new ZhuCe();
            zc.ShowDialog();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}
