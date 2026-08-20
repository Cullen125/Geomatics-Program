namespace 试题7滑坡变形应变
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

                dataGridView1.RowCount = Datacenter.stats.Count;
                int i = 0;

                foreach (var s in Datacenter.stats)
                {
                    dataGridView1[0, i].Value = s.Name;
                    dataGridView1[1, i].Value = s.Period;
                    dataGridView1[2, i].Value = s.x;
                    dataGridView1[3, i].Value = s.y;
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
    }
}
