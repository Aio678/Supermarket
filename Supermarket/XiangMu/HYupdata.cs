using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XiangMu
{
    public partial class HYupdata : Form
    {
        string En;
        public HYupdata(string n)
        {
            En = n;
            InitializeComponent();
        }
        /*
         *   调出原有数据
         */
        private void HYupdata_Load(object sender, EventArgs e)
        {
            string sql = "select * from Member where UserCard='" + En + "'";
            DataTable dt = DBHelper.GetDataTable(sql);
            this.textBox1.Text = dt.Rows[0][1].ToString();
            this.comboBox1.Text = dt.Rows[0][2].ToString();
            this.textBox2.Text = dt.Rows[0][3].ToString();
        }
        /*
         *   修改原有数据
         */
        private void button1_Click(object sender, EventArgs e)
        {
            string name, sex, phone;
            name = textBox1.Text;       // 会员名称
            sex = comboBox1.Text;       // 会员性别
            phone = textBox2.Text;      // 会员电话
            if (name == "")
            {
                MessageBox.Show("会员名称不能为空");
                return;
            }
            else if (sex == "")
            {
                MessageBox.Show("会员性别不能为空");
                return;
            }
            else if (phone == "")
            {
                MessageBox.Show("会员电话不能为空");
                return;
            }
            string sql = "update Member set UserName='" + name + "', UserSex='" + sex + "', UserTelephone='" + phone + "' where UserCard='" + En + "'";
            int r = DBHelper.ExecuteNonQuery(sql);
            if (r > 0)
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
            this.Close();
        }
        /*
         *   取消按钮
         */
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
