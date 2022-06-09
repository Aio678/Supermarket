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
    public partial class JHupdata : Form
    {
        string En;
        public JHupdata(string n)
        {
            En = n;
            InitializeComponent();
        }

        private void JHupdata_Load(object sender, EventArgs e)
        {
            string sql = "select * from Purchase where BianHao='" + En + "'";
            DataTable dt = DBHelper.GetDataTable(sql);
            this.textBox1.Text = dt.Rows[0][1].ToString();
            this.textBox2.Text = dt.Rows[0][4].ToString();
            this.textBox3.Text = dt.Rows[0][5].ToString();
            this.textBox4.Text = dt.Rows[0][6].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name, dz, num, Pmuch;
            name = textBox1.Text;                   // 商品名称
            dz = textBox2.Text;                     // 进货地址
            num = textBox3.Text;                    // 进货数量
            Pmuch = textBox4.Text.ToString();       // 商品进价
            if (name == "")
            {
                MessageBox.Show("商品名称不能为空");
                return;
            }
            else if (dz == "")
            {
                MessageBox.Show("进货地址不能为空");
                return;
            }
            else if (num == "")
            {
                MessageBox.Show("进货数量不能为空");
                return;
            }
            else if (Pmuch == "")
            {
                MessageBox.Show("商品进价不能为空");
                return;
            }
            string sql1 = "update Purchase set Name='" + name + "', Purchase='" + dz + "', Num='" + num + "', PMuch='" + Pmuch + "' where BianHao='" + En + "'";
            string sql2 = "update Commodity set GoodsName='" + name + "', PMuch='" + Pmuch + "' where Goodsbh='" + En + "'";
            int r = DBHelper.ExecuteNonQuery(sql1);
            int a = DBHelper.ExecuteNonQuery(sql2);
            if (r > 0 && a > 0)
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
         *   关闭
         */
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
