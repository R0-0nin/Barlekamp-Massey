namespace BMAlgorithm
{
    partial class Menu
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
            menuStrip1 = new MenuStrip();
            алгоритмToolStripMenuItem = new ToolStripMenuItem();
            дляБинарныхПоследовательностейToolStripMenuItem = new ToolStripMenuItem();
            надПроизвольнымПолемToolStripMenuItem = new ToolStripMenuItem();
            логжурналToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            историяЗапросовToolStripMenuItem = new ToolStripMenuItem();
            richTextBox1 = new RichTextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { алгоритмToolStripMenuItem, логжурналToolStripMenuItem, справкаToolStripMenuItem, историяЗапросовToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 42);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // алгоритмToolStripMenuItem
            // 
            алгоритмToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { дляБинарныхПоследовательностейToolStripMenuItem, надПроизвольнымПолемToolStripMenuItem });
            алгоритмToolStripMenuItem.Name = "алгоритмToolStripMenuItem";
            алгоритмToolStripMenuItem.Size = new Size(140, 38);
            алгоритмToolStripMenuItem.Text = "Алгоритм";
            алгоритмToolStripMenuItem.Click += алгоритмToolStripMenuItem_Click;
            // 
            // дляБинарныхПоследовательностейToolStripMenuItem
            // 
            дляБинарныхПоследовательностейToolStripMenuItem.Name = "дляБинарныхПоследовательностейToolStripMenuItem";
            дляБинарныхПоследовательностейToolStripMenuItem.Size = new Size(554, 44);
            дляБинарныхПоследовательностейToolStripMenuItem.Text = "Для бинарных последовательностей";
            дляБинарныхПоследовательностейToolStripMenuItem.Click += дляБинарныхПоследовательностейToolStripMenuItem_Click;
            // 
            // надПроизвольнымПолемToolStripMenuItem
            // 
            надПроизвольнымПолемToolStripMenuItem.Name = "надПроизвольнымПолемToolStripMenuItem";
            надПроизвольнымПолемToolStripMenuItem.Size = new Size(554, 44);
            надПроизвольнымПолемToolStripMenuItem.Text = "Над произвольным полем";
            надПроизвольнымПолемToolStripMenuItem.Click += надПроизвольнымПолемToolStripMenuItem_Click;
            // 
            // логжурналToolStripMenuItem
            // 
            логжурналToolStripMenuItem.Name = "логжурналToolStripMenuItem";
            логжурналToolStripMenuItem.Size = new Size(166, 38);
            логжурналToolStripMenuItem.Text = "Лог-журнал";
            логжурналToolStripMenuItem.Click += логжурналToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(126, 38);
            справкаToolStripMenuItem.Text = "Справка";
            справкаToolStripMenuItem.Click += справкаToolStripMenuItem_Click;
            // 
            // историяЗапросовToolStripMenuItem
            // 
            историяЗапросовToolStripMenuItem.Name = "историяЗапросовToolStripMenuItem";
            историяЗапросовToolStripMenuItem.Size = new Size(237, 38);
            историяЗапросовToolStripMenuItem.Text = "История запросов";
            историяЗапросовToolStripMenuItem.Click += историяЗапросовToolStripMenuItem_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(0, 43);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(800, 411);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Menu";
            Text = "Алгоритм Берлекэмпа-Мэсси";
            Load += Menu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem алгоритмToolStripMenuItem;
        private ToolStripMenuItem логжурналToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem историяЗапросовToolStripMenuItem;
        private RichTextBox richTextBox1;
        private ToolStripMenuItem дляБинарныхПоследовательностейToolStripMenuItem;
        private ToolStripMenuItem надПроизвольнымПолемToolStripMenuItem;
    }
}