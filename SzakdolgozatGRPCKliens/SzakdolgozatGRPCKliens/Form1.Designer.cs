namespace SzakdolgozatGRPCKliens
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
            components = new System.ComponentModel.Container();
            doorListComboBox = new ComboBox();
            label1 = new Label();
            enterExitComboBox = new ComboBox();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            SuspendLayout();
            // 
            // doorListComboBox
            // 
            doorListComboBox.FormattingEnabled = true;
            doorListComboBox.Location = new Point(35, 26);
            doorListComboBox.Name = "doorListComboBox";
            doorListComboBox.Size = new Size(196, 23);
            doorListComboBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 167);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // enterExitComboBox
            // 
            enterExitComboBox.FormattingEnabled = true;
            enterExitComboBox.Items.AddRange(new object[] { "Enter", "Exit", "Enter/Exit" });
            enterExitComboBox.Location = new Point(35, 79);
            enterExitComboBox.Name = "enterExitComboBox";
            enterExitComboBox.Size = new Size(196, 23);
            enterExitComboBox.TabIndex = 4;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 289);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 450);
            Controls.Add(label2);
            Controls.Add(enterExitComboBox);
            Controls.Add(label1);
            Controls.Add(doorListComboBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox doorListComboBox;
        private Label label1;
        private ComboBox enterExitComboBox;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
    }
}