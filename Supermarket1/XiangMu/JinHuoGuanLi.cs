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
    public partial class JinHuoGuanLi : Form
    {
        public JinHuoGuanLi()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            XiaoShouGuanLi xsgl = new XiaoShouGuanLi();
            xsgl.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            HuiYuanGuanLi hygl = new HuiYuanGuanLi();
            hygl.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            XiaoShouMingXi xsmmx = new XiaoShouMingXi();
            xsmmx.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            KuCunChaXun kccx = new KuCunChaXun();
            kccx.Show();
        }

        private void jinhuoguanli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        /*
         *   页面加载
         */
        private void jinhuoguanli_Load(object sender, EventArgs e)
        {
            // 添加动态时间
            this.timer1.Start();
            // 给进货时间添加默认时间
            this.Text3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // 加载数据库
            string sql = "select Name 商品名称,BianHao 商品编号,Date 进货日期,Purchase 进货地址,Num 进货数量,PMuch 商品进价 from Purchase";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
        }
        /*
         *   进货时间变为动态
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /*
         *   添加商品信息
         */
        private void button7_Click(object sender, EventArgs e)
        {
            string mc,bh, shijian, dz, sl, jj, sj, lb;
            mc = Text1.Text;         // 商品名称
            bh = Text2.Text;         // 商品编号
            shijian = Text3.Text;    // 进货时间
            dz = Text4.Text;         // 进货地址
            sl = Text5.Text;         // 商品数量
            jj = Text6.Text;         // 商品进价
            sj = Text7.Text;         // 商品售价
            lb = Text8.Text;         // 商品类别
            if (mc == "")
            {
                MessageBox.Show("商品名称不能为空", "提示");
                Text1.Focus();
                return;
            }
            else if (bh == "")
            {
                MessageBox.Show("商品编号不能为空", "提示");
                Text3.Focus();
                return;
            }
            else if (shijian == "")
            {
                MessageBox.Show("进货时间不能为空", "提示");
                Text3.Focus();
                return;
            }
            else if (dz == "")
            {
                MessageBox.Show("进货地址不能为空", "提示");
                Text4.Focus();
                return;
            }
            else if (sl == "")
            {
                MessageBox.Show("进货数量不能为空", "提示");
                Text5.Focus();
                return;
            }
            else if (jj == "")
            {
                MessageBox.Show("商品进价不能为空", "提示");
                Text6.Focus();
                return;
            }else if (sj == "")
            {
                MessageBox.Show("商品售价不能为空", "提示");
                Text7.Focus();
                return;
            }else if (bh == "")
            {
                MessageBox.Show("商品编号不能为空", "提示");
                Text8.Focus();
                return;
            }
            // 验证商品编号唯一
            string sql4 = "select Goodsbh from Commodity where Goodsbh='" + bh + "'";
            DataTable dt = DBHelper.GetDataTable(sql4);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == bh)
                {
                    MessageBox.Show("该商品编号已经被使用，请重新输入");
                    return;
                }
            }
            // 向进货表和库存表中插入信息
            string sql1 = "insert into Purchase values ('" + mc + "','" + bh + "','" + shijian + "','" + dz + "','" + sl + "','" + jj + "')";
            string sql2 = "insert into Commodity values ('" + mc + "','" + sj + "','" + sl + "','" + lb + "','" + jj + "','" + bh + "')";
            int r = DBHelper.ExecuteNonQuery(sql1);
            int n = DBHelper.ExecuteNonQuery(sql2);
            if (r > 0 && n > 0)
            {
                MessageBox.Show("添加成功！","提示",MessageBoxButtons.OK);
                string sql3 = "select Name 商品名称,BianHao 商品编号,Date 进货日期,Purchase 进货地址,Num 进货数量,PMuch 商品进价 from Purchase";
                this.dataGridView1.DataSource = DBHelper.GetDataTable(sql3);

                // 成功提交信息后清楚文本框中的内容
                this.Text1.Text = "";
                this.Text2.Text = "";
                this.Text4.Text = "";
                this.Text5.Text = "";
                this.Text6.Text = "";
                this.Text7.Text = "";
                this.Text8.Text = "";
            }
        }
        /*
         *   清除当前输入框中的内容（添加信息）
         */
        private void button8_Click(object sender, EventArgs e)
        {
            // 清楚当前输入框中的内容
            this.Text1.Text = "";
            this.Text2.Text = "";
            this.Text4.Text = "";
            this.Text5.Text = "";
            this.Text6.Text = "";
            this.Text7.Text = "";
            this.Text8.Text = "";
        }
        /*
         *   查询功能
         */
        private void button5_Click(object sender, EventArgs e)
        {
            string name, bh, dz;
            name = textBox1.Text;
            bh = textBox2.Text.ToString();
            dz = textBox3.Text;

            // 根据名称查找
            if (name != "")
            {
                string sql = "select Name 商品名称,BianHao 商品编号,Date 进货日期,Purchase 进货地址,Num 进货数量,PMuch 商品进价 from Purchase where Name like '%" + name + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据编号查找
            if (bh != "")
            {
                string sql = "select Name 商品名称,BianHao 商品编号,Date 进货日期,Purchase 进货地址,Num 进货数量,PMuch 商品进价 from Purchase where BianHao like '%" + bh + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据地址查找
            if (dz != "")
            {
                string sql = "select Name 商品名称,BianHao 商品编号,Date 进货日期,Purchase 进货地址,Num 进货数量,PMuch 商品进价 from Purchase where Purchase like '%" + dz + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据名称、编号查找
            if (name != "" && bh != "")
            {
                string sql = "select Name 商品名称,BianHao 商品编号,Date 进货日期,Purchase 进货地址,Num 进货数量,PMuch 商品进价 from Purchase where Name like '%" + name + "%' and BianHao like '%" + bh + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据名称、编号、地址查找
            if (name != "" && bh != "" && dz != "")
            {
                string sql = "select Name 商品名称,BianHao 商品编号,Date 进货日期,Purchase 进货地址,Num 进货数量,PMuch 商品进价 from Purchase where Name like '%" + name + "%' and BianHao like '%" + bh + "%' and Purchase like '%" + dz + "%' ";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据编号、地址查找
            if (bh != "" && dz != "")
            {
                string sql = "select Name 商品名称,BianHao 商品编号,Date 进货日期,Purchase 进货地址,Num 进货数量,PMuch 商品进价 from Purchase where Name like '%" + bh + "%' and Purchase like '%" + dz + "%' ";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 不输入内容后提示内容
            if (name == "" && bh == "" && dz == "")
            {
                MessageBox.Show("请输入要查询的内容！");
            }
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";

        }
        /*
         *   清除当前输入框中的内容（查询信息）
         */
        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "select Name 商品名称,BianHao 商品编号,Date 进货日期,Purchase 进货地址,Num 进货数量,PMuch 商品进价 from Purchase";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
        }
        /*
         *   删除功能
         */
        private void 删除信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string n = this.dataGridView1.SelectedRows[0].Cells["商品编号"].Value.ToString();
            string sql = "delete from Purchase where BianHao='" + n + "'";
            if (DBHelper.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show("删除成功");
                string sql2 = "select Name 商品名称,BianHao 商品编号,Date 进货日期,Purchase 进货地址,Num 进货数量,PMuch 商品进价 from Purchase";
                this.dataGridView1.DataSource = DBHelper.GetDataTable(sql2);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
        /*
         *   更改信息
         */
        private void 更改信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string n = this.dataGridView1.SelectedRows[0].Cells["商品编号"].Value.ToString();
            JHupdata jh = new JHupdata(n);
            jh.ShowDialog();
            // 加载数据库
            string sql = "select Name 商品名称,BianHao 商品编号,Date 进货日期,Purchase 进货地址,Num 进货数量,PMuch 商品进价 from Purchase";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
        }
        /*
         *   显示命名窗口,并且只能打开一个
         */
        private void button1_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["Mm"];
            if (f == null)  //没打开过
            {
                Mm m = new Mm();
                m.Show();   //重新new一个Show出来
            }
            else
            {
                f.Focus();   //打开过就让其获得焦点
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
