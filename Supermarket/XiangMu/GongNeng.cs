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
    public partial class guanlixitong : Form
    {
        public guanlixitong()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HuiYuanGuanLi hygl = new HuiYuanGuanLi();
            hygl.ShowDialog();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            XiaoShouGuanLi xs = new XiaoShouGuanLi();
            xs.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            JinHuoGuanLi jhgl = new JinHuoGuanLi();
            jhgl.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            KuCunChaXun kccx = new KuCunChaXun();
            kccx.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            XiaoShouMingXi xsmx = new XiaoShouMingXi();
            xsmx.ShowDialog();
        }

        private void guanlixitong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            XiaoShouGuanLi xs = new XiaoShouGuanLi();
            xs.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            XiaoShouGuanLi xs = new XiaoShouGuanLi();
            xs.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            JinHuoGuanLi jhgl = new JinHuoGuanLi();
            jhgl.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            JinHuoGuanLi jhgl = new JinHuoGuanLi();
            jhgl.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            KuCunChaXun kccx = new KuCunChaXun();
            kccx.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            KuCunChaXun kccx = new KuCunChaXun();
            kccx.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            XiaoShouMingXi xsmx = new XiaoShouMingXi();
            xsmx.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            XiaoShouMingXi xsmx = new XiaoShouMingXi();
            xsmx.ShowDialog();
        }
    }
}
