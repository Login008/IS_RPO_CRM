namespace Приложение_для_amoCRM
{
    partial class Form2
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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.AutoScroll = true;
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Location = new Point(12, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(160, 374);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AllowDrop = true;
            panel2.AutoScroll = true;
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Location = new Point(178, 64);
            panel2.Name = "panel2";
            panel2.Size = new Size(160, 374);
            panel2.TabIndex = 1;
            panel2.Click += panel2_Click;
            // 
            // panel3
            // 
            panel3.AllowDrop = true;
            panel3.AutoScroll = true;
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Location = new Point(344, 64);
            panel3.Name = "panel3";
            panel3.Size = new Size(160, 374);
            panel3.TabIndex = 2;
            panel3.Click += panel3_Click;
            // 
            // panel4
            // 
            panel4.AllowDrop = true;
            panel4.AutoScroll = true;
            panel4.BackColor = SystemColors.ActiveBorder;
            panel4.Location = new Point(510, 64);
            panel4.Name = "panel4";
            panel4.Size = new Size(160, 374);
            panel4.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(189, 25);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 4;
            label1.Text = "Задачи на сегодня";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 25);
            label2.Name = "label2";
            label2.Size = new Size(168, 20);
            label2.TabIndex = 5;
            label2.Text = "Просроченные задачи";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(354, 25);
            label3.Name = "label3";
            label3.Size = new Size(129, 20);
            label3.TabIndex = 6;
            label3.Text = "Задачи на завтра";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(510, 25);
            label4.Name = "label4";
            label4.Size = new Size(142, 20);
            label4.TabIndex = 7;
            label4.Text = "Задачи на будущее";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form2";
            Text = "Задачи";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}