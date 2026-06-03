using System.Reflection.Metadata.Ecma335;

namespace 试题1出租车轨道数据计算_Cullen
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
            try
            {
                FileHelper.Openfile();

            }
            catch (Exception)
            {
                MessageBox.Show("导入失败");
                throw;
            }

            load_label.Text = "已导入";

            int i = 0;
            dataGridView1.RowCount = Datacenter.taxis.Count;
            foreach (var t in Datacenter.taxis)
            {
                dataGridView1[0, i].Value = t.name;
                dataGridView1[1, i].Value = t.status;
                dataGridView1[2, i].Value = t.bjtime;
                dataGridView1[3, i].Value = t.x.ToString("F3");
                dataGridView1[4, i].Value = t.y.ToString("F3");
                i++;
            }
        }

        private void compute_tool_Click(object sender, EventArgs e)
        {
            if (load_label.Text == "未导入")
            {
                MessageBox.Show("请先导入数据");
                return;
            }
            compute_label.Text = "已计算";
            tabControl1.SelectedIndex = 1;

            Algo.Get_Mjd();
            Algo.Get_Result();


            report = "";

            report += "----------速度和方位角计算结果----------\r\n";

            foreach (Result r in Datacenter.results)
            {
                report += r.id.ToString("D2") + ", "
                       + r.b_Mjd.ToString("F5") + "-"
                       + r.e_Mjd.ToString("F5") + ", "
                       + r.speed.ToString("F3") + ", "
                       + r.angle.ToString("F3") + "\r\n";
            }

            report += "\r\n";
            report += "----------距离计算结果----------\r\n";
            report += "累积距离：" + Result.sumDistance.ToString("F3") + " km\r\n";
            report += "首尾直线距离：" + Result.straightDistance.ToString("F3") + " km\r\n";
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
