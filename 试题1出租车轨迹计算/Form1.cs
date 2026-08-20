namespace 试题1出租车轨迹计算
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

                int i = 0;
                dataGridView1.RowCount = Datacenter.taxis.Count;

                foreach(var taxi in Datacenter.taxis)
                {
                    dataGridView1[0, i].Value = taxi.Name;
                    dataGridView1[1, i].Value = taxi.Sta;
                    dataGridView1[2, i].Value = taxi.T;
                    dataGridView1[3, i].Value = taxi.x;
                    dataGridView1[4, i].Value = taxi.y;
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
            catch(Exception)
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

            FileHelper.saveReport(report);//这里没记住，需要清楚report的流动关系
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
