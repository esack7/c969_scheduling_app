
namespace C969___Scheduling_App___Isaac_Heist
{
    partial class AppointmentsForm
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
            this.mainLabel = new System.Windows.Forms.Label();
            this.appointmentDataGridView = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.monthRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.weekRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            this.mainLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.Location = new System.Drawing.Point(1, 9);
            this.mainLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(1064, 39);
            this.mainLabel.TabIndex = 2;
            this.mainLabel.Text = "Appointments for $\"{user}\": ";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // appointmentDataGridView
            // 
            this.appointmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGridView.Location = new System.Drawing.Point(13, 64);
            this.appointmentDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.appointmentDataGridView.Name = "appointmentDataGridView";
            this.appointmentDataGridView.RowHeadersWidth = 51;
            this.appointmentDataGridView.Size = new System.Drawing.Size(640, 226);
            this.appointmentDataGridView.TabIndex = 3;
            this.appointmentDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.appointmentDataGridView_DataBindingComplete);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(747, 464);
            this.backButton.Margin = new System.Windows.Forms.Padding(4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(281, 54);
            this.backButton.TabIndex = 25;
            this.backButton.Text = "Back to Main";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(747, 236);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(281, 54);
            this.deleteButton.TabIndex = 28;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(747, 162);
            this.editButton.Margin = new System.Windows.Forms.Padding(4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(281, 54);
            this.editButton.TabIndex = 27;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(747, 89);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(281, 54);
            this.addButton.TabIndex = 26;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(18, 311);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 30;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // monthRadioButton
            // 
            this.monthRadioButton.AutoSize = true;
            this.monthRadioButton.Checked = true;
            this.monthRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthRadioButton.Location = new System.Drawing.Point(429, 380);
            this.monthRadioButton.Name = "monthRadioButton";
            this.monthRadioButton.Size = new System.Drawing.Size(81, 22);
            this.monthRadioButton.TabIndex = 31;
            this.monthRadioButton.TabStop = true;
            this.monthRadioButton.Text = "Monthly";
            this.monthRadioButton.UseVisualStyleBackColor = true;
            this.monthRadioButton.CheckedChanged += new System.EventHandler(this.monthRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 24);
            this.label1.TabIndex = 32;
            this.label1.Text = "View option for appointments";
            // 
            // weekRadioButton
            // 
            this.weekRadioButton.AutoSize = true;
            this.weekRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekRadioButton.Location = new System.Drawing.Point(429, 446);
            this.weekRadioButton.Name = "weekRadioButton";
            this.weekRadioButton.Size = new System.Drawing.Size(78, 22);
            this.weekRadioButton.TabIndex = 33;
            this.weekRadioButton.Text = "Weekly";
            this.weekRadioButton.UseVisualStyleBackColor = true;
            this.weekRadioButton.CheckedChanged += new System.EventHandler(this.weekRadioButton_CheckedChanged);
            // 
            // AppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.weekRadioButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthRadioButton);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.appointmentDataGridView);
            this.Controls.Add(this.mainLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AppointmentsForm";
            this.Text = "AppointmentsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppointmentsForm_FormClosed);
            this.Load += new System.EventHandler(this.AppointmentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.DataGridView appointmentDataGridView;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.RadioButton monthRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton weekRadioButton;
    }
}