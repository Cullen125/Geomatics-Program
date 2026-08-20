namespace 试题8矩阵卷积计算
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

                dataGridView1.RowCount = 10;
                dataGridView2.RowCount = 3;

                for (int I = 0; I < 10; I++)
                {
                    for (int J = 0; J < 10; J++)
                    {
                        dataGridView1[J, I].Value = Datacenter.N[I, J];
                    }
                }

                for (int I = 0; I < 3; I++)
                {
                    for (int J = 0; J < 3; J++)
                    {
                        dataGridView2[J, I].Value = Datacenter.M[I, J];//注意dataGridView是先列后行
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

                richTextBox1.Text = Datacenter.report;

                compute_label.Text = "已计算";
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
