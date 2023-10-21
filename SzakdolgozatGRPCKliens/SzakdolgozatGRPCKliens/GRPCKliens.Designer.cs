namespace SzakdolgozatGRPCKliens
{
    partial class GRPCKliens
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
            enterExitComboBox = new ComboBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ClientDisplayLabel = new Label();
            scannerPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)scannerPictureBox).BeginInit();
            SuspendLayout();
            // 
            // doorListComboBox
            // 
            doorListComboBox.FormattingEnabled = true;
            doorListComboBox.Location = new Point(12, 12);
            doorListComboBox.Name = "doorListComboBox";
            doorListComboBox.Size = new Size(150, 23);
            doorListComboBox.TabIndex = 0;
            // 
            // enterExitComboBox
            // 
            enterExitComboBox.FormattingEnabled = true;
            enterExitComboBox.Items.AddRange(new object[] { "Enter", "Exit", "Enter/Exit" });
            enterExitComboBox.Location = new Point(12, 70);
            enterExitComboBox.Name = "enterExitComboBox";
            enterExitComboBox.Size = new Size(150, 23);
            enterExitComboBox.TabIndex = 4;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // ClientDisplayLabel
            // 
            ClientDisplayLabel.AutoSize = true;
            ClientDisplayLabel.BackColor = SystemColors.ActiveCaptionText;
            ClientDisplayLabel.Font = new Font("OCR A Extended", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ClientDisplayLabel.ForeColor = Color.ForestGreen;
            ClientDisplayLabel.Location = new Point(15, 109);
            ClientDisplayLabel.MaximumSize = new Size(150, 0);
            ClientDisplayLabel.MinimumSize = new Size(250, 50);
            ClientDisplayLabel.Name = "ClientDisplayLabel";
            ClientDisplayLabel.Size = new Size(250, 50);
            ClientDisplayLabel.TabIndex = 5;
            ClientDisplayLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scannerPictureBox
            // 
            scannerPictureBox.Location = new Point(12, 176);
            scannerPictureBox.Name = "scannerPictureBox";
            scannerPictureBox.Size = new Size(260, 273);
            scannerPictureBox.TabIndex = 6;
            scannerPictureBox.TabStop = false;
            // 
            // GRPCKliens
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 461);
            Controls.Add(scannerPictureBox);
            Controls.Add(ClientDisplayLabel);
            Controls.Add(enterExitComboBox);
            Controls.Add(doorListComboBox);
            Name = "GRPCKliens";
            Text = "Kliens";
            Load += GRPCKliensForm_Load;
            ((System.ComponentModel.ISupportInitialize)scannerPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox doorListComboBox;
        private ComboBox enterExitComboBox;
        private System.Windows.Forms.Timer timer1;
        private Label ClientDisplayLabel;
        private PictureBox scannerPictureBox;
    }
}