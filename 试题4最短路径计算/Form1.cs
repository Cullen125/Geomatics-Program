namespace 试题4最短路径计算
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
                FileHelper.OpenFile();

                dataGridView1.RowCount = Datacenter.edges.Count;

                int i = 0;
                
                foreach(var e1 in Datacenter.edges)
                {
                    dataGridView1[0, i].Value = e1.begin;
                    dataGridView1[1, i].Value = e1.end;
                    dataGridView1[2, i].Value = e1.wei;
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

                richTextBox1.Text = Datacenter.report;

                compute_label.Text = "已计算";
            }
            catch (Exception)
            {

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
            FileHelper.saveReport(Datacenter.report);
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
