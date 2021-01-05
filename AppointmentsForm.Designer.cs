
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
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            this.mainLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.Location = new System.Drawing.Point(1, 7);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(798, 32);
            this.mainLabel.TabIndex = 2;
            this.mainLabel.Text = "Appointments for $\"{user}\": ";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // appointmentDataGridView
            // 
            this.appointmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGridView.Location = new System.Drawing.Point(10, 52);
            this.appointmentDataGridView.Name = "appointmentDataGridView";
            this.appointmentDataGridView.RowHeadersWidth = 51;
            this.appointmentDataGridView.Size = new System.Drawing.Size(480, 184);
            this.appointmentDataGridView.TabIndex = 3;
            this.appointmentDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.appointmentDataGridView_DataBindingComplete);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(560, 377);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(211, 44);
            this.backButton.TabIndex = 25;
            this.backButton.Text = "Back to Main";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(560, 192);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(211, 44);
            this.deleteButton.TabIndex = 28;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(560, 132);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(211, 44);
            this.editButton.TabIndex = 27;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(560, 72);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(211, 44);
            this.addButton.TabIndex = 26;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.appointmentDataGridView);
            this.Controls.Add(this.mainLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AppointmentsForm";
            this.Text = "AppointmentsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppointmentsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.DataGridView appointmentDataGridView;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
    }
}