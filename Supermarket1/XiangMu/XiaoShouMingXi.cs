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
    public partial class XiaoShouMingXi : Form
    {
        public XiaoShouMingXi()
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
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            KuCunChaXun kccx = new KuCunChaXun();
            kccx.Show();
        }
        private void xiaoshoumingxi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        /*
         *   页面加载
         */
        private void XiaoShouMingXi_Load(object sender, EventArgs e)
        {
            // 加载数据库
            string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
            // 默认添加当前日期
            this.textBox4.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        /*
         *   查询功能
         */
        private void button1_Click(object sender, EventArgs e)
        {
            string user, goodsname, card, date;
            user = this.textBox1.Text;
            goodsname = this.textBox2.Text;
            card = this.textBox3.Text;
            date = this.textBox4.Text;


            //Console.WriteLine(date);
            //return;
            /**
             *  根据单个条件查找
             */
            // 根据会员名称查找
            if (user != "")
            {
                string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID where o.UserName like '%" + user + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据商品名称查找
            if (goodsname != "")
            {
                string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID where t.GoodsName like '%" + goodsname + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据会员卡号查找
            if (card != "")
            {
                string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID where o.UserCard like '%" + card + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据交易时间查找
            if (date != "")
            {
                string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID where Convert(nvarchar,date,120) LIKE '%" + date + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            /*
             *  根据两个条件查找
             */
            // 根据会员名称、商品名称查找
            if (user != "" && goodsname != "")
            {
                string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID where o.UserName like '%" + user + "%' and t.GoodsName like '%" + goodsname + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据会员名称、会员卡号查找
            if (user != "" && card != "")
            {
                string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID where o.UserName like '%" + user + "%' and o.UserCard like '%" + card + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据会员名称、交易时间查找
            if (user != "" && date != "")
            {
                string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID where o.UserName like '%" + user + "%' and Convert(nvarchar,o.date,120) LIKE '" + date + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            /*
             *   根据三个条件查找
             */
            // 根据会员名称、商品名称、会员卡号查找
            if (user != "" && goodsname != "" && card != "")
            {
                string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID where o.UserName like '%" + user + "%' and t.GoodsName like '%" + goodsname + "%' and o.UserCard like '%" + card + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据会员名称、商品名称、交易时间查找
            if (user != "" && goodsname != "" && date != "")
            {
                string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID where o.UserName like '%" + user + "%' and t.GoodsName like '%" + goodsname + "%' and o.date like '%" + date + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据商品名称、会员卡号、交易时间查找
            if (user != "" && goodsname != "" && date != "")
            {
                string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID where t.GoodsName like '%" + goodsname + "%' and o.UserCard like '%" + card + "%' and Convert(nvarchar,o.date,120) LIKE '" + date + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }



            /*
             *   根据四个条件查找
             */
            // 根据会员名称、商品名称、会员卡号、交易时间查找
            if (user != "" && goodsname != "" && card != "" && date != "")
            {
                string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID where o.UserName like '%" + user + "%' and t.GoodsName like '%" + goodsname + "%' and o.UserCard like '%" + card + "%' and Convert(nvarchar,o.date,120) LIKE '" + date + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            /*
             *   不输入内容后提示
             */
            if (user == "" && goodsname == "" && card == "" && date == "")
            {
                MessageBox.Show("请输入要查询的内容！");
            }
            /*
             *  查询后清除原有文本框中的内容
             */
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
        }
        /*
         *   重置按钮（重新加载数据库）
         */
        private void button8_Click(object sender, EventArgs e)
        {
            // 重置按钮
            // 清除原有文本框中的内容
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            // 重新加载数据库
            string sql = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
        }
        /*
         *   删除功能
         */
        private void 删除信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string n = this.dataGridView1.SelectedRows[0].Cells["序号"].Value.ToString();
            string sql = "delete from [Order T] where id='" + n + "'";
            if (DBHelper.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show("删除成功");
                string sql2 = "select t.id 序号,o.UserName 会员姓名,o.UserCard 会员卡号,o.date 交易时间,t.GoodsName 商品名称,t.Num 商品数量 from [Order O] o join [Order T] t on o.id=t.OrderID";
                this.dataGridView1.DataSource = DBHelper.GetDataTable(sql2);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
