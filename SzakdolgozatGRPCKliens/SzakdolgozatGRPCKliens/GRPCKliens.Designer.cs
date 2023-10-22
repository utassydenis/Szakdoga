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
            refreshButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)scannerPictureBox).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // doorListComboBox
            // 
            doorListComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            doorListComboBox.FormattingEnabled = true;
            doorListComboBox.Location = new Point(3, 3);
            doorListComboBox.Name = "doorListComboBox";
            doorListComboBox.Size = new Size(278, 23);
            doorListComboBox.TabIndex = 0;
            // 
            // enterExitComboBox
            // 
            enterExitComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            enterExitComboBox.FormattingEnabled = true;
            enterExitComboBox.Items.AddRange(new object[] { "Enter", "Exit", "Enter/Exit" });
            enterExitComboBox.Location = new Point(3, 83);
            enterExitComboBox.Name = "enterExitComboBox";
            enterExitComboBox.Size = new Size(278, 23);
            enterExitComboBox.TabIndex = 4;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // ClientDisplayLabel
            // 
            ClientDisplayLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ClientDisplayLabel.AutoSize = true;
            ClientDisplayLabel.BackColor = SystemColors.ActiveCaptionText;
            ClientDisplayLabel.Font = new Font("OCR A Extended", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ClientDisplayLabel.ForeColor = Color.ForestGreen;
            ClientDisplayLabel.Location = new Point(7, 120);
            ClientDisplayLabel.Margin = new Padding(7, 0, 3, 0);
            ClientDisplayLabel.MinimumSize = new Size(270, 50);
            ClientDisplayLabel.Name = "ClientDisplayLabel";
            ClientDisplayLabel.Size = new Size(274, 83);
            ClientDisplayLabel.TabIndex = 5;
            ClientDisplayLabel.Text = "Aaaaaaaaaaaaaa";
            ClientDisplayLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scannerPictureBox
            // 
            scannerPictureBox.Dock = DockStyle.Bottom;
            scannerPictureBox.Location = new Point(0, 203);
            scannerPictureBox.Name = "scannerPictureBox";
            scannerPictureBox.Size = new Size(284, 258);
            scannerPictureBox.TabIndex = 6;
            scannerPictureBox.TabStop = false;
            // 
            // refreshButton
            // 
            refreshButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            refreshButton.AutoSize = true;
            refreshButton.Location = new Point(3, 43);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(278, 34);
            refreshButton.TabIndex = 7;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(refreshButton, 0, 1);
            tableLayoutPanel1.Controls.Add(enterExitComboBox, 0, 2);
            tableLayoutPanel1.Controls.Add(doorListComboBox, 0, 0);
            tableLayoutPanel1.Controls.Add(ClientDisplayLabel, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.Size = new Size(284, 203);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // GRPCKliens
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 461);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(scannerPictureBox);
            Name = "GRPCKliens";
            Text = "Kliens";
            Load += GRPCKliensForm_Load;
            ((System.ComponentModel.ISupportInitialize)scannerPictureBox).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox doorListComboBox;
        private ComboBox enterExitComboBox;
        private System.Windows.Forms.Timer timer1;
        private Label ClientDisplayLabel;
        private PictureBox scannerPictureBox;
        private Button refreshButton;
        private TableLayoutPanel tableLayoutPanel1;
    }
}