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
    public partial class KCupdata : Form
    {
        string En;
        public KCupdata(string n)
        {
            En = n;
            InitializeComponent();
        }

        private void KCupdata_Load(object sender, EventArgs e)
        {
            string sql = "select * from Commodity where id='" + En + "'";
            DataTable dt = DBHelper.GetDataTable(sql);
            this.textBox1.Text = dt.Rows[0][1].ToString();
            this.textBox2.Text = dt.Rows[0][2].ToString();
            this.textBox3.Text = dt.Rows[0][4].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name, much, lb;
            name = textBox1.Text;               // 商品名称
            much = textBox2.Text.ToString();    // 商品单价
            lb = textBox3.Text;                 // 商品类别
            if (name == "")
            {
                MessageBox.Show("商品名称不能为空");
                return;
            }
            else if (much == "")
            {
                MessageBox.Show("商品单价不能为空");
                return;
            }
            else if (lb == "")
            {
                MessageBox.Show("商品类别不能为空");
                return;
            }
            string sql = "update Commodity set GoodsName='" + name + "',GoodsMoney='" + much + "',GoodsL='" + lb + "' where id='" + En + "'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
