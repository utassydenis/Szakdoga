namespace SzakdolgozatGRPCAdminKliens
{
    partial class GRPCAdminKliens
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
            userIDComboBox = new ComboBox();
            startDateCheckBox = new CheckBox();
            endDateCheckBox = new CheckBox();
            startDateTimePicker = new DateTimePicker();
            endDateTimePicker = new DateTimePicker();
            userEventsdataGridView = new DataGridView();
            submitButton = new Button();
            refreshButton = new Button();
            ((System.ComponentModel.ISupportInitialize)userEventsdataGridView).BeginInit();
            SuspendLayout();
            // 
            // userIDComboBox
            // 
            userIDComboBox.FormattingEnabled = true;
            userIDComboBox.Location = new Point(28, 32);
            userIDComboBox.Name = "userIDComboBox";
            userIDComboBox.Size = new Size(331, 23);
            userIDComboBox.TabIndex = 0;
            // 
            // startDateCheckBox
            // 
            startDateCheckBox.AutoSize = true;
            startDateCheckBox.Location = new Point(28, 81);
            startDateCheckBox.Name = "startDateCheckBox";
            startDateCheckBox.RightToLeft = RightToLeft.Yes;
            startDateCheckBox.Size = new Size(109, 19);
            startDateCheckBox.TabIndex = 1;
            startDateCheckBox.Text = "Select start date";
            startDateCheckBox.UseVisualStyleBackColor = true;
            startDateCheckBox.CheckedChanged += startDateCheckBox_CheckedChanged;
            // 
            // endDateCheckBox
            // 
            endDateCheckBox.AutoSize = true;
            endDateCheckBox.Location = new Point(28, 145);
            endDateCheckBox.Name = "endDateCheckBox";
            endDateCheckBox.RightToLeft = RightToLeft.Yes;
            endDateCheckBox.Size = new Size(106, 19);
            endDateCheckBox.TabIndex = 2;
            endDateCheckBox.Text = "Select end date";
            endDateCheckBox.UseVisualStyleBackColor = true;
            endDateCheckBox.CheckedChanged += endDateCheckBox_CheckedChanged;
            // 
            // startDateTimePicker
            // 
            startDateTimePicker.CustomFormat = "";
            startDateTimePicker.Location = new Point(159, 81);
            startDateTimePicker.Name = "startDateTimePicker";
            startDateTimePicker.Size = new Size(200, 23);
            startDateTimePicker.TabIndex = 3;
            // 
            // endDateTimePicker
            // 
            endDateTimePicker.Location = new Point(148, 140);
            endDateTimePicker.Name = "endDateTimePicker";
            endDateTimePicker.Size = new Size(200, 23);
            endDateTimePicker.TabIndex = 4;
            // 
            // userEventsdataGridView
            // 
            userEventsdataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userEventsdataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userEventsdataGridView.Location = new Point(383, 0);
            userEventsdataGridView.Name = "userEventsdataGridView";
            userEventsdataGridView.RowTemplate.Height = 25;
            userEventsdataGridView.Size = new Size(417, 450);
            userEventsdataGridView.TabIndex = 5;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(131, 360);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(75, 23);
            submitButton.TabIndex = 6;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(131, 198);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 23);
            refreshButton.TabIndex = 7;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // GRPCAdminKliens
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(refreshButton);
            Controls.Add(submitButton);
            Controls.Add(userEventsdataGridView);
            Controls.Add(endDateTimePicker);
            Controls.Add(startDateTimePicker);
            Controls.Add(endDateCheckBox);
            Controls.Add(startDateCheckBox);
            Controls.Add(userIDComboBox);
            Name = "GRPCAdminKliens";
            Text = "Admin Kliens";
            Load += GRPCAdminKliensForm_Load;
            ((System.ComponentModel.ISupportInitialize)userEventsdataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox userIDComboBox;
        private CheckBox startDateCheckBox;
        private CheckBox endDateCheckBox;
        private DateTimePicker startDateTimePicker;
        private DateTimePicker endDateTimePicker;
        private DataGridView userEventsdataGridView;
        private Button submitButton;
        private Button refreshButton;
    }
}