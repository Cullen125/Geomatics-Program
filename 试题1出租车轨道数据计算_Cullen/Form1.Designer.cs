namespace 试题1出租车轨道数据计算_Cullen
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            文件ToolStripMenuItem = new ToolStripMenuItem();
            打开文件ToolStripMenuItem = new ToolStripMenuItem();
            保存报告ToolStripMenuItem = new ToolStripMenuItem();
            计算ToolStripMenuItem = new ToolStripMenuItem();
            退出ToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            open_tool = new ToolStripButton();
            compute_tool = new ToolStripButton();
            save_tool = new ToolStripButton();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            richTextBox1 = new RichTextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            load_label = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            toolStripStatusLabel4 = new ToolStripStatusLabel();
            compute_label = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(28, 28);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 文件ToolStripMenuItem, 计算ToolStripMenuItem, 退出ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1194, 37);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            文件ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 打开文件ToolStripMenuItem, 保存报告ToolStripMenuItem });
            文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            文件ToolStripMenuItem.Size = new Size(72, 33);
            文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开文件ToolStripMenuItem
            // 
            打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            打开文件ToolStripMenuItem.Size = new Size(315, 40);
            打开文件ToolStripMenuItem.Text = "打开文件";
            打开文件ToolStripMenuItem.Click += 打开文件ToolStripMenuItem_Click;
            // 
            // 保存报告ToolStripMenuItem
            // 
            保存报告ToolStripMenuItem.Name = "保存报告ToolStripMenuItem";
            保存报告ToolStripMenuItem.Size = new Size(315, 40);
            保存报告ToolStripMenuItem.Text = "保存报告";
            保存报告ToolStripMenuItem.Click += 保存报告ToolStripMenuItem_Click;
            // 
            // 计算ToolStripMenuItem
            // 
            计算ToolStripMenuItem.Name = "计算ToolStripMenuItem";
            计算ToolStripMenuItem.Size = new Size(72, 33);
            计算ToolStripMenuItem.Text = "计算";
            // 
            // 退出ToolStripMenuItem
            // 
            退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            退出ToolStripMenuItem.Size = new Size(72, 33);
            退出ToolStripMenuItem.Text = "退出";
            退出ToolStripMenuItem.Click += 退出ToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(50, 50);
            toolStrip1.Items.AddRange(new ToolStripItem[] { open_tool, compute_tool, save_tool });
            toolStrip1.Location = new Point(0, 37);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1194, 60);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // open_tool
            // 
            open_tool.Image = (Image)resources.GetObject("open_tool.Image");
            open_tool.ImageTransparentColor = Color.Magenta;
            open_tool.Name = "open_tool";
            open_tool.Size = new Size(150, 54);
            open_tool.Text = "打开文件";
            open_tool.Click += open_tool_Click;
            // 
            // compute_tool
            // 
            compute_tool.Image = (Image)resources.GetObject("compute_tool.Image");
            compute_tool.ImageTransparentColor = Color.Magenta;
            compute_tool.Name = "compute_tool";
            compute_tool.Size = new Size(150, 54);
            compute_tool.Text = "一键计算";
            compute_tool.Click += compute_tool_Click;
            // 
            // save_tool
            // 
            save_tool.Image = (Image)resources.GetObject("save_tool.Image");
            save_tool.ImageTransparentColor = Color.Magenta;
            save_tool.Name = "save_tool";
            save_tool.Size = new Size(150, 54);
            save_tool.Text = "保存报告";
            save_tool.Click += save_tool_Click;
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Bottom;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 99);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1182, 522);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1174, 481);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "显示数据";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 72;
            dataGridView1.Size = new Size(1165, 475);
            dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "车辆标识";
            Column1.MinimumWidth = 9;
            Column1.Name = "Column1";
            Column1.Width = 175;
            // 
            // Column2
            // 
            Column2.HeaderText = "运营状态";
            Column2.MinimumWidth = 9;
            Column2.Name = "Column2";
            Column2.Width = 175;
            // 
            // Column3
            // 
            Column3.HeaderText = "北京时间";
            Column3.MinimumWidth = 9;
            Column3.Name = "Column3";
            Column3.Width = 175;
            // 
            // Column4
            // 
            Column4.HeaderText = "x";
            Column4.MinimumWidth = 9;
            Column4.Name = "Column4";
            Column4.Width = 175;
            // 
            // Column5
            // 
            Column5.HeaderText = "y";
            Column5.MinimumWidth = 9;
            Column5.Name = "Column5";
            Column5.Width = 175;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(richTextBox1);
            tabPage2.Location = new Point(4, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1174, 481);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "查看报告";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1174, 478);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(28, 28);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, load_label, toolStripStatusLabel3, toolStripStatusLabel4, compute_label });
            statusStrip1.Location = new Point(0, 624);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1194, 37);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(117, 28);
            toolStripStatusLabel1.Text = "导入情况：";
            // 
            // load_label
            // 
            load_label.Name = "load_label";
            load_label.Size = new Size(75, 28);
            load_label.Text = "未导入";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(156, 28);
            toolStripStatusLabel3.Text = "                        ";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new Size(117, 28);
            toolStripStatusLabel4.Text = "计算情况：";
            // 
            // compute_label
            // 
            compute_label.Name = "compute_label";
            compute_label.Size = new Size(75, 28);
            compute_label.Text = "未计算";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 661);
            Controls.Add(statusStrip1);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "TAXI";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 打开文件ToolStripMenuItem;
        private ToolStripMenuItem 保存报告ToolStripMenuItem;
        private ToolStripMenuItem 计算ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton open_tool;
        private ToolStripButton compute_tool;
        private ToolStripButton save_tool;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataGridView1;
        private TabPage tabPage2;
        private RichTextBox richTextBox1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel load_label;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel compute_label;
    }
}
