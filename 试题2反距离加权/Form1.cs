namespace 试题2反距离加权
{
    public partial class 反距离加权 : Form
    {
        string report = "";
        public 反距离加权()
        {
            InitializeComponent();
        }

        private void open_tool_Click(object sender, EventArgs e)
        {
            try
            {
                FileHelper.OpenFile();

                int i = 0;
                dataGridView1.RowCount = Datacenter.Kpoints.Count;

                foreach(var k  in Datacenter.Kpoints)
                {
                    dataGridView1[0, i].Value = k.Name;
                    dataGridView1[1, i].Value = k.x.ToString("F3");
                    dataGridView1[2, i].Value = k.y.ToString("F3");
                    dataGridView1[3, i].Value = k.H.ToString("F3");
                    i++;
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
            }
            catch (Exception)
            {
                MessageBox.Show("计算失败");
                throw;//漏掉了
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

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_tool_Click(sender, e);
        }

        private void 保存文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_tool_Click(sender, e);
        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compute_tool_Click(sender, e);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
