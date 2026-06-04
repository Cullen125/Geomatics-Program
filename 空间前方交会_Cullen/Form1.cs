using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 空间前方交会_Cullen
{
    public partial class Form1 : Form
    {
        string report = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void open_tool_Click(object sender, EventArgs e)
        {
            //静态类:既然类也是唯一的对象  随叫随到

            try
            {
                FileHelper.OpenFile();
            }
            catch (Exception)
            {
                MessageBox.Show("导入失败");
                throw;
            }
            load_label.Text = "已导入";

            dataGridView1.RowCount = 2;
            dataGridView1[0, 0].Value = Datacenter.name1;
            dataGridView1[1, 0].Value = Datacenter.Xs1;
            dataGridView1[2, 0].Value = Datacenter.Ys1;
            dataGridView1[3, 0].Value = Datacenter.Zs1;
            dataGridView1[4, 0].Value = Datacenter.phi1;
            dataGridView1[5, 0].Value = Datacenter.omiga1;
            dataGridView1[6, 0].Value = Datacenter.kapa1;
            dataGridView1[7, 0].Value = Datacenter.x1;
            dataGridView1[8, 0].Value = Datacenter.y1;
            dataGridView1[9, 0].Value = Datacenter.f1;

            dataGridView1[0, 1].Value = Datacenter.name2;
            dataGridView1[1, 1].Value = Datacenter.Xs2;
            dataGridView1[2, 1].Value = Datacenter.Ys2;
            dataGridView1[3, 1].Value = Datacenter.Zs2;
            dataGridView1[4, 1].Value = Datacenter.phi2;
            dataGridView1[5, 1].Value = Datacenter.omiga2;
            dataGridView1[6, 1].Value = Datacenter.kapa2;
            dataGridView1[7, 1].Value = Datacenter.x2;
            dataGridView1[8, 1].Value = Datacenter.y2;
            dataGridView1[9, 1].Value = Datacenter.f2;
        }

        private void compute_tool_Click(object sender, EventArgs e)
        {
            if (load_label.Text == "未导入")
            {
                MessageBox.Show("请先导入数据");
                return;
            }

            tabControl1.SelectedIndex = 1;
            compute_label.Text = "已计算";
            Algorithm.let_uvw();
            Algorithm.let_N_XYZ();

            report = "----------------结果报告----------------\n";
            report += "X:" + Datacenter.X.ToString("F6") + " Y:" + Datacenter.Y.ToString("F6") + " Z:" + Datacenter.Z.ToString("F6") + "\n";
            report += "---------------各点信息----------------\n";
            report += "点名\tu\t\tv\t\tw\t\tN\t\n";
            report += Datacenter.name1 + "\t" + Datacenter.u1.ToString("F6") + "\t" + Datacenter.v1.ToString("F6") + "\t" + Datacenter.w1.ToString("F6") + "\t" + Datacenter.N1.ToString("F6") + "\t\n";
            report += Datacenter.name2 + "\t" + Datacenter.u2.ToString("F6") + "\t" + Datacenter.v2.ToString("F6") + "\t" + Datacenter.w2.ToString("F6") + "\t" + Datacenter.N2.ToString("F6") + "\t\n";
            richTextBox1.Text = report;
        }

        private void save_tool_Click(object sender, EventArgs e)
        {
            if (compute_label.Text == "未计算")
            {
                MessageBox.Show("请先计算数据");
                return;
            }

            FileHelper.saveReport(report);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compute_tool_Click(sender, e);
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_tool_Click(sender, e);
        }

        private void 保存报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_tool_Click(sender, e);
        }
    }
}
