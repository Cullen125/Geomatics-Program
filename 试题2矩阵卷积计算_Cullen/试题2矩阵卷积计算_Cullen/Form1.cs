namespace 试题2矩阵卷积计算_Cullen
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
                dataGridView1.RowCount = 10;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        dataGridView1[j, i].Value = Datacenter.N[i, j].ToString("F2");
                    }
                }

                dataGridView2.RowCount = 3;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        dataGridView2[j, i].Value = Datacenter.M[i, j].ToString("F2");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("导入失败");
                throw;
            }
            load_label.Text = "已导入";

        }

        private void compute_tool_Click(object sender, EventArgs e)
        {
            if (load_label.Text == "未导入")
            {
                MessageBox.Show("请先导入数据");
                return;
            }
            try
            {
                Algo.Cal();
                report = Datacenter.report;
                richTextBox1.Text = report;
                compute_label.Text = "已计算";
                MessageBox.Show("计算完成");
            }
            catch (Exception)
            {
                MessageBox.Show("计算失败");
                throw;
            }
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

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compute_tool_Click(sender, e);
        }
    }
}
