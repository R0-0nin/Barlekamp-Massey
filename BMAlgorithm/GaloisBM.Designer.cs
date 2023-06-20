namespace BMAlgorithm
{
    partial class GaloisBM
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
            numtb = new TextBox();
            seqtb = new TextBox();
            lengthtb = new TextBox();
            gradetb = new TextBox();
            lineartb = new TextBox();
            regstatetb = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            galoisbutt = new Button();
            label7 = new Label();
            primpolytb = new TextBox();
            SuspendLayout();
            // 
            // numtb
            // 
            numtb.Location = new Point(240, 41);
            numtb.Name = "numtb";
            numtb.Size = new Size(102, 39);
            numtb.TabIndex = 0;
            numtb.KeyPress += numtb_KeyPress;
            // 
            // seqtb
            // 
            seqtb.Location = new Point(446, 116);
            seqtb.Name = "seqtb";
            seqtb.Size = new Size(200, 39);
            seqtb.TabIndex = 1;
            seqtb.KeyPress += seqtb_KeyPress;
            // 
            // lengthtb
            // 
            lengthtb.Location = new Point(446, 189);
            lengthtb.Name = "lengthtb";
            lengthtb.ReadOnly = true;
            lengthtb.Size = new Size(200, 39);
            lengthtb.TabIndex = 2;
            // 
            // gradetb
            // 
            gradetb.Location = new Point(530, 41);
            gradetb.Name = "gradetb";
            gradetb.Size = new Size(116, 39);
            gradetb.TabIndex = 3;
            gradetb.KeyPress += gradetb_KeyPress;
            // 
            // lineartb
            // 
            lineartb.Location = new Point(446, 262);
            lineartb.Name = "lineartb";
            lineartb.ReadOnly = true;
            lineartb.Size = new Size(200, 39);
            lineartb.TabIndex = 4;
            // 
            // regstatetb
            // 
            regstatetb.Location = new Point(446, 334);
            regstatetb.Name = "regstatetb";
            regstatetb.ReadOnly = true;
            regstatetb.Size = new Size(200, 39);
            regstatetb.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 48);
            label1.Name = "label1";
            label1.Size = new Size(188, 32);
            label1.TabIndex = 6;
            label1.Text = "Характеристика";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(407, 48);
            label2.Name = "label2";
            label2.Size = new Size(105, 32);
            label2.TabIndex = 7;
            label2.Text = "Степень";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 123);
            label3.Name = "label3";
            label3.Size = new Size(243, 32);
            label3.TabIndex = 8;
            label3.Text = "Последовательность";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(88, 196);
            label4.Name = "label4";
            label4.Size = new Size(188, 32);
            label4.TabIndex = 9;
            label4.Text = "Длина регистра";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(88, 269);
            label5.Name = "label5";
            label5.Size = new Size(186, 32);
            label5.TabIndex = 10;
            label5.Text = "Обратная связь";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(88, 341);
            label6.Name = "label6";
            label6.Size = new Size(235, 32);
            label6.TabIndex = 11;
            label6.Text = "Состояние регистра";
            // 
            // galoisbutt
            // 
            galoisbutt.Location = new Point(299, 492);
            galoisbutt.Name = "galoisbutt";
            galoisbutt.Size = new Size(150, 46);
            galoisbutt.TabIndex = 12;
            galoisbutt.Text = "Рассчитать";
            galoisbutt.UseVisualStyleBackColor = true;
            galoisbutt.Click += galoisbutt_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(88, 416);
            label7.Name = "label7";
            label7.Size = new Size(301, 32);
            label7.TabIndex = 13;
            label7.Text = "Примитивный многочлен";
            // 
            // primpolytb
            // 
            primpolytb.Location = new Point(446, 409);
            primpolytb.Name = "primpolytb";
            primpolytb.ReadOnly = true;
            primpolytb.Size = new Size(200, 39);
            primpolytb.TabIndex = 14;
            // 
            // GaloisBM
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 576);
            Controls.Add(primpolytb);
            Controls.Add(label7);
            Controls.Add(galoisbutt);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(regstatetb);
            Controls.Add(lineartb);
            Controls.Add(gradetb);
            Controls.Add(lengthtb);
            Controls.Add(seqtb);
            Controls.Add(numtb);
            Name = "GaloisBM";
            Text = "GaloisBM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox numtb;
        private TextBox seqtb;
        private TextBox lengthtb;
        private TextBox gradetb;
        private TextBox lineartb;
        private TextBox regstatetb;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button galoisbutt;
        private Label label7;
        private TextBox primpolytb;
    }
}