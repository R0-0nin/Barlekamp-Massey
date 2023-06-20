namespace BMAlgorithm
{
    partial class Algorithm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            binarybox = new TextBox();
            lengthbox = new TextBox();
            functb = new TextBox();
            registerbox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(268, 351);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 0;
            button1.Text = "Рассчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // binarybox
            // 
            binarybox.Location = new Point(399, 56);
            binarybox.Name = "binarybox";
            binarybox.Size = new Size(200, 39);
            binarybox.TabIndex = 1;
            binarybox.KeyPress += binarybox_KeyPress_1;
            // 
            // lengthbox
            // 
            lengthbox.Location = new Point(399, 131);
            lengthbox.Name = "lengthbox";
            lengthbox.ReadOnly = true;
            lengthbox.Size = new Size(200, 39);
            lengthbox.TabIndex = 2;
            // 
            // functb
            // 
            functb.Location = new Point(399, 208);
            functb.Name = "functb";
            functb.ReadOnly = true;
            functb.Size = new Size(200, 39);
            functb.TabIndex = 3;
            // 
            // registerbox
            // 
            registerbox.Location = new Point(399, 276);
            registerbox.Name = "registerbox";
            registerbox.ReadOnly = true;
            registerbox.Size = new Size(200, 39);
            registerbox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 59);
            label1.Name = "label1";
            label1.Size = new Size(243, 32);
            label1.TabIndex = 5;
            label1.Text = "Последовательность";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 138);
            label2.Name = "label2";
            label2.Size = new Size(188, 32);
            label2.TabIndex = 6;
            label2.Text = "Длина регистра";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 215);
            label3.Name = "label3";
            label3.Size = new Size(186, 32);
            label3.TabIndex = 7;
            label3.Text = "Обратная связь";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 283);
            label4.Name = "label4";
            label4.Size = new Size(235, 32);
            label4.TabIndex = 8;
            label4.Text = "Состояние регистра";
            // 
            // Algorithm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(registerbox);
            Controls.Add(functb);
            Controls.Add(lengthbox);
            Controls.Add(binarybox);
            Controls.Add(button1);
            MaximumSize = new Size(710, 521);
            MinimumSize = new Size(710, 521);
            Name = "Algorithm";
            Text = "BinaryBM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox binarybox;
        private TextBox lengthbox;
        private TextBox functb;
        private TextBox registerbox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}