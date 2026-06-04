using System.Windows.Forms;

namespace 点云数据统计_Cullen
{
    public partial class 点云数据统计_Cullen : Form
    {
        string report = "";//重点不要忘记！！！
        public 点云数据统计_Cullen()
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
            dataGridView1.RowCount = Datacenter.points.Count;
            foreach(var p in Datacenter.points)
            {
                dataGridView1[0, i].Value = p.name;
                dataGridView1[1, i].Value = p.x;
                dataGridView1[2, i].Value = p.y;
                i++;
            }//5


        }

        private void compute_tool_Click(object sender, EventArgs e)
        {
            if (load_label.Text == "未导入")
            {
                MessageBox.Show("请先导入数据");
                return;
            }
            compute_label.Text = "已计算";
            tabControl1.SelectedIndex = 1;//10：从“显示报告”自动跳转到“查看报告”

            Algorithm.let_avg();//11:第二小题至此完成
            Algorithm.let_std();
            Algorithm.let_XY();//17:至此第四小题完成

            int i = 1;
            report += "序号，说明，计算结果\n";
            report += i++.ToString() + "," + "K80的坐标x" + "," + Datacenter.K80.x.ToString("F3") + "\n";
            report += i++.ToString() + "," + "K80的坐标y" + "," + Datacenter.K80.y.ToString("F3") + "\n";
            report += i++.ToString() + "," + "点云总数n" + "," + Datacenter.points.Count + "\n";
            report += i++.ToString() + "," + "坐标分量x的平均值" + "," + Datacenter.x_avg.ToString("F3") + "\n";
            report += i++.ToString() + "," + "坐标分量y的平均值" + "," + Datacenter.y_avg.ToString("F3") + "\n";
            report += i++.ToString() + "," + "坐标分量x的标准差" + "," + Datacenter.x_sigema.ToString("F3") + "\n";
            report += i++.ToString() + "," + "坐标分量y的标准差" + "," + Datacenter.y_sigema.ToString("F3") + "\n";//18
            report += i++.ToString() + "," + "K13的标准化坐标X" + "," + Datacenter.K13.X.ToString("F3") + "\n";
            report += i++.ToString() + "," + "K13的标准化坐标Y" + "," + Datacenter.K13.Y.ToString("F3") + "\n";
            report += i++.ToString() + "," + "K53的标准化坐标X" + "," + Datacenter.K53.X.ToString("F3") + "\n";
            report += i++.ToString() + "," + "K53的标准化坐标Y" + "," + Datacenter.K53.Y.ToString("F3") + "\n";

            richTextBox1.Text = report;//21
        }

        private void save_tool_Click(object sender, EventArgs e)
        {
            if (compute_label.Text == "未计算")
            {
                MessageBox.Show("请先计算数据");
                return;
            }


            FileHelper.saveReport(report);//22
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
