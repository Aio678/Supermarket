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
    public partial class KuCunChaXun : Form
    {
        public KuCunChaXun()
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
            this.Hide();
            JinHuoGuanLi jhgl = new JinHuoGuanLi();
            jhgl.Show();
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
            
        }


        private void kucunchaxun_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }




        /*
         *   页面加载
         */
        private void kucunchaxun_Load(object sender, EventArgs e)
        {
            string sql = "select id 商品序号,GoodsName 商品名称,Goodsbh 商品编号,GoodsMoney 商品单价,Goodsl 商品类别,Goodsnum 库存数量,PMuch 进货单价 from Commodity";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
        }
        /*
         *   重置按钮
         */
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select id 商品序号,GoodsName 商品名称,Goodsbh 商品编号,GoodsMoney 商品单价,Goodsl 商品类别,Goodsnum 库存数量,PMuch 进货单价 from Commodity";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
        }


        /*
         *   查询功能
         */
        private void button4_Click(object sender, EventArgs e)
        {
            string mc, lb, bh;
            mc = textBox1.Text;
            lb = textBox2.Text;
            bh = textBox3.Text;
            // 根据名称查找
            if (mc != "")
            {
                string sql = "select id 商品序号,GoodsName 商品名称,Goodsbh 商品编号,GoodsMoney 商品单价,Goodsl 商品类别,Goodsnum 库存数量,PMuch 进货单价 from Commodity where GoodsName like '%" + mc + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据类别查找
            if (lb != "")
            {
                string sql = "select id 商品序号,GoodsName 商品名称,Goodsbh 商品编号,GoodsMoney 商品单价,Goodsl 商品类别,Goodsnum 库存数量,PMuch 进货单价 from Commodity where GoodsL like '%" + lb + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据编号查找
            if (bh != "")
            {
                string sql = "select id 商品序号,GoodsName 商品名称,Goodsbh 商品编号,GoodsMoney 商品单价,Goodsl 商品类别,Goodsnum 库存数量,PMuch 进货单价 from Commodity where Goodsbh like '%" + bh + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据名称、类别查找
            if (mc != "" && lb != "")
            {
                string sql = "select id 商品序号,GoodsName 商品名称,Goodsbh 商品编号,GoodsMoney 商品单价,Goodsl 商品类别,Goodsnum 库存数量,PMuch 进货单价 from Commodity where GoodsName like '%" + mc + "%' and GoodsL like '%" + lb + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据名称、类别、编号查找
            if (mc != "" && lb != "" && bh != "")
            {
                string sql = "select id 商品序号,GoodsName 商品名称,Goodsbh 商品编号,GoodsMoney 商品单价,Goodsl 商品类别,Goodsnum 库存数量,PMuch 进货单价 from Commodity where GoodsName like '%" + mc + "%' and GoodsL like '%" + lb + "%' and Goodsbh like '%" + bh + "%' ";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据类别、编号查找
            if (lb != "" && bh != "")
            {
                string sql = "select id 商品序号,GoodsName 商品名称,Goodsbh 商品编号,GoodsMoney 商品单价,Goodsl 商品类别,Goodsnum 库存数量,PMuch 进货单价 from Commodity where GoodsL like '%" + lb + "%' and Goodsbh like '%" + bh + "%' ";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 不输入内容后提示内容
            if (mc == "" && lb == "" && bh == "")
            {
                MessageBox.Show("请输入要查询的内容！");
            }
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
        }
        /*
         *   删除功能
         */
        private void 删除信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string n = this.dataGridView1.SelectedRows[0].Cells["商品序号"].Value.ToString();
            string sql = "delete from Commodity where id='" + n + "'";
            if (DBHelper.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show("删除成功");
                string sql2 = "select id 商品序号,GoodsName 商品名称,Goodsbh 商品编号,GoodsMoney 商品单价,Goodsl 商品类别,Goodsnum 库存数量,PMuch 进货单价 from Commodity";
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
            string n = this.dataGridView1.SelectedRows[0].Cells["商品序号"].Value.ToString();
            KCupdata kc = new KCupdata(n);
            kc.ShowDialog();
            string sql = "select id 商品序号,GoodsName 商品名称,Goodsbh 商品编号,GoodsMoney 商品单价,Goodsl 商品类别,Goodsnum 库存数量,PMuch 进货单价 from Commodity";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
        }
    }
}
