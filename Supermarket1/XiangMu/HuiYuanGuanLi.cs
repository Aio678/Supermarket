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
    public partial class HuiYuanGuanLi : Form
    {
        public HuiYuanGuanLi()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            XiaoShouGuanLi xs = new XiaoShouGuanLi();
            xs.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            JinHuoGuanLi jhgl = new JinHuoGuanLi();
            jhgl.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // 取消本功能
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            XiaoShouMingXi xsmx = new XiaoShouMingXi();
            xsmx.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            KuCunChaXun kccx = new KuCunChaXun();
            kccx.Show();
        }

        private void huiyuanguanli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }




        /*
         *   页面加载
         */
        private void huiyuanguanli_Load(object sender, EventArgs e)
        {
            // 添加动态时间
            this.timer1.Start();
            // 性别默认选择“男”
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("男");
            // 给会员卡卡号添加默认值
            string card = Text3.Text;
            if (card == "")
            {
                Random rd = new Random();
                int r = rd.Next(0, 1000000000);
                Text3.Text = r.ToString();
            }
            // 给注册时间添加默认值
            this.Text4.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // 从数据库中输出会员信息
            string sql = "select UserName 会员姓名,UserSex 会员性别,UserTelephone 会员电话,UserCard 会员卡卡号,CardDate 注册时间 from Member";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text4.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }
        /*
         *   重新生成会员卡号
         */
        private void button5_Click(object sender, EventArgs e)
        {
            this.Text3.Text = "";
            string card = Text3.Text;
            if (card == "")
            {
                Random rd = new Random();
                int r = rd.Next(0, 1000000000);
                Text3.Text = r.ToString();
            }
        }
        /*
         *   添加功能
         */
        private void button1_Click(object sender, EventArgs e)
        {
            string name, sex, phone;
            name = Text1.Text;
            sex = comboBox1.Text;
            phone = Text2.Text.ToString();
            // 验证手机号唯一
            string sql3 = "select UserTelephone from Member where UserTelephone='" + phone + "'";
            DataTable dt1 = DBHelper.GetDataTable(sql3);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (dt1.Rows[i][0].ToString() == phone)
                {
                    MessageBox.Show("该手机号已经被注册，请重新输入");
                    return;
                }
            }
            // 验证会员卡号唯一
            string sql4 = "select UserCard from Member where UserCard='" + Text3.Text + "'";
            DataTable dt2 = DBHelper.GetDataTable(sql4);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (dt2.Rows[i][0].ToString() == phone)
                {
                    MessageBox.Show("该会员卡号已经被注册，请重新输入");
                    return;
                }
            }
            // 往数据库中插入数据
            string sql = "insert into Member values ('" + name + "','" + sex + "','" + phone + "','" + this.Text3.Text + "','" + this.Text4.Text + "')";
            int q = DBHelper.ExecuteNonQuery(sql);
            if (q > 0)
            {
                MessageBox.Show("添加成功！");
                string sql2 = "select UserName 会员姓名,UserSex 会员性别,UserTelephone 会员电话,UserCard 会员卡卡号,CardDate 注册时间 from Member";
                this.dataGridView1.DataSource = DBHelper.GetDataTable(sql2);
                this.Text1.Text = "";
                this.Text2.Text = "";
                // 重新生成卡号
                this.Text3.Text = "";
                string card = Text3.Text;
                if (card == "")
                {
                    Random rd = new Random();
                    int r = rd.Next(0, 1000000000);
                    Text3.Text = r.ToString();
                }
            }
        }
        /*
         *   查询功能
         */
        private void button3_Click(object sender, EventArgs e)
        {
            string name, phone, card;
            name = textBox1.Text;    // 会员名称
            phone = textBox5.Text;   // 会员电话
            card = textBox2.Text;    // 会员卡号
            // 根据名称查找
            if (name != "")
            {
                string sql = "select UserName 会员姓名,UserSex 会员性别,UserTelephone 会员电话,UserCard 会员卡卡号,CardDate 注册时间 from Member where UserName like '%" + name + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据手机号查找
            if (phone != "")
            {
                string sql = "select UserName 会员姓名,UserSex 会员性别,UserTelephone 会员电话,UserCard 会员卡卡号,CardDate 注册时间 from Member where UserTelephone like '%" + phone + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据会员卡卡号查找
            if (card != "")
            {
                string sql = "select UserName 会员姓名,UserSex 会员性别,UserTelephone 会员电话,UserCard 会员卡卡号,CardDate 注册时间 from Member where UserCard like '%" + card + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据名称、手机号查找
            if (name != "" && phone != "")
            {
                string sql = "select UserName 会员姓名,UserSex 会员性别,UserTelephone 会员电话,UserCard 会员卡卡号,CardDate 注册时间 from Member where UserName like '%" + name + "%' and UserTelephone like '%" + phone + "%'";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据名称、手机号、会员卡卡号查找
            if (name != "" && phone != "" && card != "")
            {
                string sql = "select UserName 会员姓名,UserSex 会员性别,UserTelephone 会员电话,UserCard 会员卡卡号,CardDate 注册时间 from Member where UserName like '%" + name + "%' and BianHao like '%" + phone + "%' and UserCard like '%" + card + "%' ";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 根据手机号、卡号查找
            if (phone != "" && card != "")
            {
                string sql = "select UserName 会员姓名,UserSex 会员性别,UserTelephone 会员电话,UserCard 会员卡卡号,CardDate 注册时间 from Member where UserTelephone like '%" + phone + "%' and UserCard like '%" + card + "%' ";
                DataTable r = DBHelper.GetDataTable(sql);
                dataGridView1.DataSource = r;
            }
            // 不输入内容后提示内容
            if (name == "" && phone == "" && card == "")
            {
                MessageBox.Show("请输入要查询的内容！");
            }
            //  提交后清楚文本款中的内容
            this.textBox1.Text = "";
            this.textBox5.Text = "";
            this.textBox2.Text = "";
        }
        /*
         *   查询公告（重置）
         */
        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "select UserName 会员姓名,UserSex 会员性别,UserTelephone 会员电话,UserCard 会员卡卡号,CardDate 注册时间 from Member";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
            this.textBox1.Text = "";
            this.textBox5.Text = "";
            this.textBox2.Text = "";
        }
        /*
         *   删除功能
         */
        private void 删除信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string n = this.dataGridView1.SelectedRows[0].Cells["会员卡卡号"].Value.ToString();
            string sql = "delete from Member where UserCard='" + n + "'";
            if (DBHelper.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show("删除成功");
                string sql2 = "select UserName 会员姓名,UserSex 会员性别,UserTelephone 会员电话,UserCard 会员卡卡号,CardDate 注册时间 from Member";
                this.dataGridView1.DataSource = DBHelper.GetDataTable(sql2);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
        /*
         *   修改功能
         */
        private void 更改信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string n = this.dataGridView1.SelectedRows[0].Cells["会员卡卡号"].Value.ToString();
            HYupdata hy = new HYupdata(n);
            hy.ShowDialog();
            string sql = "select UserName 会员姓名,UserSex 会员性别,UserTelephone 会员电话,UserCard 会员卡卡号,CardDate 注册时间 from Member";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql);
        }
        /*
         *   清除会员名称和会员手机号
         */
        private void button2_Click(object sender, EventArgs e)
        {
            this.Text1.Text = "";
            this.Text2.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Text2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Text1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Text3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Text4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
