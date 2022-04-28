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
    public partial class XiaoShouGuanLi : Form
    {
        public XiaoShouGuanLi()
        {
            InitializeComponent();
        }

       

        private void xiaoshou_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
            this.Hide();
            KuCunChaXun kccx = new KuCunChaXun();
            kccx.Show();
        }
        /*
         *   页面加载
         */
        private void XiaoShouGuanLi_Load(object sender, EventArgs e)
        {
            string sql = "select id 商品序号,GoodsName 商品名称,Goodsl 商品类别,Goodsbh 商品编号,GoodsMoney 商品单价 from Commodity";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
        }
        /*
         *   重置功能
         */
        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            string sql = "select id 商品序号,GoodsName 商品名称,Goodsl 商品类别,Goodsbh 商品编号,GoodsMoney 商品单价 from Commodity";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
        }
        /*
         *   商品查询
         */
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.ToString();
            string sql = "select id 商品序号,GoodsName 商品名称,Goodsl 商品类别,Goodsbh 商品编号,GoodsMoney 商品单价 from Commodity where GoodsName like '%" + name + "%'";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
            // 查询完毕后清空当前输入框中的内容
            this.textBox1.Text = "";
        }



        /*
         *   添加已经购买的商品信息
         */
        int much = 0;
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string id = this.dataGridView1.SelectedRows[0].Cells["商品序号"].Value.ToString();
            string sql = "select * from Commodity where id='" + id + "'";
            DataTable dt = DBHelper.GetDataTable(sql);
            //  添加已经选择的商品名称
            comboBox1.Items.Add(dt.Rows[0][1].ToString());
            //  计算商品数量
            int num = int.Parse(this.label4.Text);
            num++;
            this.label4.Text = num.ToString();
            //  计算商品总价格
                //  重置商品信息或者提交商品信息后使much重新赋值为0
            if (this.label5.Text == "0")
            {
                much = 0;
            }
            much += int.Parse(dt.Rows[0][2].ToString());
            this.label5.Text = much.ToString();
            
        }
        /*
         *   重置已经购买的商品信息
         */
        private void button3_Click(object sender, EventArgs e)
        {
            this.comboBox1.Text = "";
            comboBox1.Items.Clear();
            this.label4.Text = "0";
            this.label5.Text = "0";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
        }
        /*
         *    结算金额
         */
        private void button4_Click(object sender, EventArgs e)
        {
            double m1, m2, m3;
            m1 = int.Parse(this.label5.Text);
            if (this.textBox2.Text == "")
            {
                MessageBox.Show("请输入付款金额。");
                return;
            }
            this.comboBox1.DroppedDown = true;      //  显示出已经购买的商品信息
            m2 = int.Parse(this.textBox2.Text);
            m3 = m2 - m1;
            this.textBox3.Text = m3.ToString();
        }

        /*
         *    查找会员卡号和名称功能
         */
        private void button5_Click(object sender, EventArgs e)
        {
            string name = this.textBox4.Text;       // 姓名
            string card = this.textBox5.Text;       // 卡号
            //  姓名和卡号不输入的话会提示出信息
            if (this.textBox4.Text == "" && this.textBox5.Text == "")
            {
                MessageBox.Show("请输入要查询的条件");
                return;
            }
            else if (this.textBox4.Text != "")          // 名称查卡号
            {
                string sql = "select UserCard,UserName from Member where UserName='" + name + "'";
                DataTable dt = DBHelper.GetDataTable(sql);
                //  如果没有查到信息则提示出信息
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有该会员名称");
                    return;
                }
                this.textBox5.Text = dt.Rows[0][0].ToString();
            }else if (this.textBox5.Text != "")         // 卡号查名称
            {
                string sql = "select UserCard,UserName from Member where UserCard='" + card + "'";
                DataTable dt = DBHelper.GetDataTable(sql);
                //  如果没有查到信息则提示出信息
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有改会员卡号");
                    return;
                }
                this.textBox4.Text = dt.Rows[0][1].ToString();
            }

        }

        /*
         *   提交订单
         */
        private void button7_Click(object sender, EventArgs e)
        {
            /*
             *    收款金额必须填写
             */
            string cc = this.textBox2.Text;
            if (cc == "")
            {
                MessageBox.Show("请输入收款金额");
                return;
            }
            /*
             *    判断金额
             */
            int aa = int.Parse(this.label5.Text);
            int bb = int.Parse(this.textBox2.Text);
            if (bb < aa)
            {
                MessageBox.Show("金额不足");
                return;
            }

            string name, card, much, data;
            name = this.textBox4.Text;      // 消费人员姓名
            card = this.textBox5.Text;      // 会员卡卡号
            much = this.label5.Text;        // 消费金额
            data = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");        // 添加销售时间

            int n = 0;   // 销售成功后库存数量没次减少1后         n加1
            int r = 0;   // 销售成功后订单表1中查入一条数据后     r加1
            int c = 0;   // 销售成功后订单表2中查入一条数据后     c加1

            bool q = true;   // 在订单表1中使用   使用一次后变为false

            //  出售成功后修改商品库存数量
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                //  取出用户所购买的每一项产品名称
                string dr = comboBox1.Items[i].ToString();
                //  获取该用户所购买的商品在库存表中的id
                string sql4 = "select id,GoodsNum from Commodity where GoodsName='" + dr + "'";
                DataTable tb = DBHelper.GetDataTable(sql4);
                // 获取该商品在库存表中的名称
                string z = tb.Rows[0][0].ToString();
                // 获取该商品在库存表中的库存量
                int num = int.Parse(tb.Rows[0][1].ToString());
                if (num > 0)
                {
                    // 更新库存表
                    string sql5 = "update Commodity set GoodsNum=GoodsNum-1 where id='" + z + "'";
                    int p = DBHelper.ExecuteNonQuery(sql5);
                    if (p > 0)
                    {
                        n++;
                    }
                    else
                    {
                        break;
                    }

                    //  向订单表1插入信息
                    if (q)
                    {
                        q = false;
                        string sql1 = "insert into [Order O] values ('" + name + "','" + much + "','" + data + "','" + card + "')";
                        r = DBHelper.ExecuteNonQuery(sql1);
                        if (r > 0)
                        {
                            r++;
                        }
                    }
                    

                    //  向订单表2插入信息
                    //  获取订单1中的id
                    string sql2 = "select id from [Order O] where date='" + data + "'";
                    DataTable dt = DBHelper.GetDataTable(sql2);
                    string getdata = dt.Rows[0][0].ToString();
                    // 循环遍历商品名称，然后插入订单表2
                    string sql3 = "insert into [Order T] values ('" + getdata + "','" + dr + "','1')";
                    int a = DBHelper.ExecuteNonQuery(sql3);
                    if (a > 0)
                    {
                        c++;
                    }
                }
                else
                {
                    string a = dr + "   商品不足";
                    MessageBox.Show(a);
                    break;
                }
            }
            
            /*
             *   出售成功
             */
            if (r > 0 && n > 0 && c > 0)
            {
                MessageBox.Show("销售成功");
                this.textBox1.Text = "";
                this.comboBox1.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.label4.Text = "0";
                this.label5.Text = "0";
            }
            else
            {
                MessageBox.Show("销售失败，请重新选择商品");
                this.textBox1.Text = "";
                this.comboBox1.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.label4.Text = "0";
                this.label5.Text = "0";
            }
        }
    }
}
