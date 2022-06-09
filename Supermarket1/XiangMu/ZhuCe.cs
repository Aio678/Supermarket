using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace XiangMu
{
    public partial class ZhuCe : Form
    {
        public ZhuCe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, password, password2, zw;
            username = textBox1.Text;
            password = textBox2.Text;
            password2 = textBox3.Text;
            zw = comboBox1.Text;
            if (username == "")
            {
                MessageBox.Show("账号不能为空", "提示");
                textBox1.Focus(); // 获得焦点
                return;
            }
            else if (password == "")
            {
                MessageBox.Show("密码不能为空", "提示");
                textBox2.Focus();
                return;
            }
            else if (password2 == "")
            {
                MessageBox.Show("确认密码不能为空", "提示");
                textBox2.Focus();
                return;
            }
            else if (password != password2)
            {
                MessageBox.Show("两次密码不一致", "提示");
                textBox3.Focus();
                return;
            }
            else if (zw == "")
            {
                MessageBox.Show("请选择职位", "提示");
                textBox3.Focus();
                return;
            }


            // 账号不能出现汉字
            string pat = @"[\u4e00-\u9fa5]";
            Regex rg = new Regex(pat);
            Match mh = rg.Match(textBox1.Text);
            if (mh.Success)
            {
                MessageBox.Show("不允许输入中文汉字");
                return;
            }
            //  判断输入的账号是否已经
            string sql2 = "select AdminName from Administrator";
            DataTable dt = DBHelper.GetDataTable(sql2);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == username)
                {
                    MessageBox.Show("该账号已经被注册，请重新输入");
                    return;
                }
            }
            // 如果该账号没有被注册则插入数据库
            string sql = "insert into Administrator values ('" + username + "','" + password + "','" + zw + "')";
            int r = DBHelper.ExecuteNonQuery(sql);
            if (r > 0)
            {
                MessageBox.Show("注册成功！", "提示");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ZhuCe_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
