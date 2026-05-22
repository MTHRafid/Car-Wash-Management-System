namespace WindowsFormsApp1
{
    partial class Start_Wash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start_Wash));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ServiceDGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SWCustomerNameCb = new System.Windows.Forms.ComboBox();
            this.SWServiceCb = new System.Windows.Forms.ComboBox();
            this.SWPhoneTb = new System.Windows.Forms.TextBox();
            this.SWPriceTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AddBillBtn = new System.Windows.Forms.Button();
            this.AddServiceBtn = new System.Windows.Forms.Button();
            this.TodayDate = new System.Windows.Forms.DateTimePicker();
            this.TotalLbl = new System.Windows.Forms.Label();
            this.ENameLbl = new System.Windows.Forms.Label();
            this.DeleteServiceBtn = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Aquamarine;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox7);
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(216, 450);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Castellar", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Invoice";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(36, 262);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(72, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(22, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(171, 130);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(12, 402);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(38, 36);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 11;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ServiceDGV);
            this.panel5.Location = new System.Drawing.Point(414, 174);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(373, 263);
            this.panel5.TabIndex = 22;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // ServiceDGV
            // 
            this.ServiceDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ServiceDGV.BackgroundColor = System.Drawing.Color.White;
            this.ServiceDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiceDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Customer,
            this.Column2,
            this.Column3});
            this.ServiceDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ServiceDGV.GridColor = System.Drawing.SystemColors.Control;
            this.ServiceDGV.Location = new System.Drawing.Point(15, 18);
            this.ServiceDGV.Name = "ServiceDGV";
            this.ServiceDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServiceDGV.Size = new System.Drawing.Size(345, 231);
            this.ServiceDGV.TabIndex = 0;
            this.ServiceDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StartWashDGV_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Service";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Price";
            this.Column3.Name = "Column3";
            // 
            // SWCustomerNameCb
            // 
            this.SWCustomerNameCb.FormattingEnabled = true;
            this.SWCustomerNameCb.Location = new System.Drawing.Point(257, 117);
            this.SWCustomerNameCb.Name = "SWCustomerNameCb";
            this.SWCustomerNameCb.Size = new System.Drawing.Size(121, 21);
            this.SWCustomerNameCb.TabIndex = 23;
            this.SWCustomerNameCb.SelectionChangeCommitted += new System.EventHandler(this.SWCustomerNameCb_SelectionChangeCommitted);
            // 
            // SWServiceCb
            // 
            this.SWServiceCb.FormattingEnabled = true;
            this.SWServiceCb.Location = new System.Drawing.Point(257, 246);
            this.SWServiceCb.Name = "SWServiceCb";
            this.SWServiceCb.Size = new System.Drawing.Size(121, 21);
            this.SWServiceCb.TabIndex = 24;
            this.SWServiceCb.SelectionChangeCommitted += new System.EventHandler(this.SWServiceCb_SelectionChangeCommitted);
            // 
            // SWPhoneTb
            // 
            this.SWPhoneTb.Enabled = false;
            this.SWPhoneTb.Location = new System.Drawing.Point(256, 173);
            this.SWPhoneTb.Name = "SWPhoneTb";
            this.SWPhoneTb.Size = new System.Drawing.Size(122, 20);
            this.SWPhoneTb.TabIndex = 25;
            // 
            // SWPriceTb
            // 
            this.SWPriceTb.Enabled = false;
            this.SWPriceTb.Location = new System.Drawing.Point(256, 306);
            this.SWPriceTb.Name = "SWPriceTb";
            this.SWPriceTb.Size = new System.Drawing.Size(122, 20);
            this.SWPriceTb.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Azure;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(258, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 18);
            this.label9.TabIndex = 27;
            this.label9.Text = "Customer Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Azure;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(260, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 18);
            this.label6.TabIndex = 28;
            this.label6.Text = "Service";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Azure;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(260, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "Phone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Azure;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(261, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 18);
            this.label8.TabIndex = 30;
            this.label8.Text = "Price";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkOrange;
            this.label10.Location = new System.Drawing.Point(394, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(227, 33);
            this.label10.TabIndex = 31;
            this.label10.Text = "Wash Your Car";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(767, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // AddBillBtn
            // 
            this.AddBillBtn.BackColor = System.Drawing.Color.GreenYellow;
            this.AddBillBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBillBtn.Location = new System.Drawing.Point(259, 385);
            this.AddBillBtn.Name = "AddBillBtn";
            this.AddBillBtn.Size = new System.Drawing.Size(106, 38);
            this.AddBillBtn.TabIndex = 33;
            this.AddBillBtn.Text = "Add Bill";
            this.AddBillBtn.UseVisualStyleBackColor = false;
            this.AddBillBtn.Click += new System.EventHandler(this.AddBillBtn_Click);
            // 
            // AddServiceBtn
            // 
            this.AddServiceBtn.BackColor = System.Drawing.Color.GreenYellow;
            this.AddServiceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddServiceBtn.Location = new System.Drawing.Point(468, 130);
            this.AddServiceBtn.Name = "AddServiceBtn";
            this.AddServiceBtn.Size = new System.Drawing.Size(106, 38);
            this.AddServiceBtn.TabIndex = 34;
            this.AddServiceBtn.Text = "Add Service";
            this.AddServiceBtn.UseVisualStyleBackColor = false;
            this.AddServiceBtn.Click += new System.EventHandler(this.AddServiceBtn_Click);
            // 
            // TodayDate
            // 
            this.TodayDate.Location = new System.Drawing.Point(497, 100);
            this.TodayDate.Name = "TodayDate";
            this.TodayDate.Size = new System.Drawing.Size(200, 20);
            this.TodayDate.TabIndex = 35;
            this.TodayDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // TotalLbl
            // 
            this.TotalLbl.AutoSize = true;
            this.TotalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalLbl.Location = new System.Drawing.Point(261, 354);
            this.TotalLbl.Name = "TotalLbl";
            this.TotalLbl.Size = new System.Drawing.Size(108, 18);
            this.TotalLbl.TabIndex = 36;
            this.TotalLbl.Text = "Total Amount";
            this.TotalLbl.Click += new System.EventHandler(this.TotalLbl_Click);
            // 
            // ENameLbl
            // 
            this.ENameLbl.AutoSize = true;
            this.ENameLbl.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENameLbl.Location = new System.Drawing.Point(226, 9);
            this.ENameLbl.Name = "ENameLbl";
            this.ENameLbl.Size = new System.Drawing.Size(156, 24);
            this.ENameLbl.TabIndex = 37;
            this.ENameLbl.Text = "Employee Name";
            this.ENameLbl.Click += new System.EventHandler(this.ENameLbl_Click);
            // 
            // DeleteServiceBtn
            // 
            this.DeleteServiceBtn.BackColor = System.Drawing.Color.GreenYellow;
            this.DeleteServiceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteServiceBtn.Location = new System.Drawing.Point(623, 130);
            this.DeleteServiceBtn.Name = "DeleteServiceBtn";
            this.DeleteServiceBtn.Size = new System.Drawing.Size(125, 38);
            this.DeleteServiceBtn.TabIndex = 38;
            this.DeleteServiceBtn.Text = "Delete Service";
            this.DeleteServiceBtn.UseVisualStyleBackColor = false;
            this.DeleteServiceBtn.Click += new System.EventHandler(this.DeleteServiceBtn_Click);
            // 
            // Start_Wash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteServiceBtn);
            this.Controls.Add(this.ENameLbl);
            this.Controls.Add(this.AddBillBtn);
            this.Controls.Add(this.TotalLbl);
            this.Controls.Add(this.TodayDate);
            this.Controls.Add(this.AddServiceBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SWPriceTb);
            this.Controls.Add(this.SWPhoneTb);
            this.Controls.Add(this.SWServiceCb);
            this.Controls.Add(this.SWCustomerNameCb);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Name = "Start_Wash";
            this.Text = "Start_Wash";
            this.Load += new System.EventHandler(this.Start_Wash_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView ServiceDGV;
        private System.Windows.Forms.ComboBox SWCustomerNameCb;
        private System.Windows.Forms.ComboBox SWServiceCb;
        private System.Windows.Forms.TextBox SWPhoneTb;
        private System.Windows.Forms.TextBox SWPriceTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AddBillBtn;
        private System.Windows.Forms.Button AddServiceBtn;
        private System.Windows.Forms.DateTimePicker TodayDate;
        private System.Windows.Forms.Label TotalLbl;
        private System.Windows.Forms.Label ENameLbl;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button DeleteServiceBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}