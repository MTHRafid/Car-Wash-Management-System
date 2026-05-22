namespace WindowsFormsApp1
{
    partial class AdminLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ALoginBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ALPassTb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(766, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(542, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 45;
            this.label1.Text = "Back";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ALoginBtn
            // 
            this.ALoginBtn.BackColor = System.Drawing.Color.GreenYellow;
            this.ALoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALoginBtn.Location = new System.Drawing.Point(473, 254);
            this.ALoginBtn.Name = "ALoginBtn";
            this.ALoginBtn.Size = new System.Drawing.Size(171, 38);
            this.ALoginBtn.TabIndex = 43;
            this.ALoginBtn.Text = "Login";
            this.ALoginBtn.UseVisualStyleBackColor = false;
            this.ALoginBtn.Click += new System.EventHandler(this.ALoginBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Azure;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(418, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 18);
            this.label7.TabIndex = 42;
            this.label7.Text = "Password";
            // 
            // ALPassTb
            // 
            this.ALPassTb.Location = new System.Drawing.Point(502, 206);
            this.ALPassTb.Name = "ALPassTb";
            this.ALPassTb.Size = new System.Drawing.Size(187, 20);
            this.ALPassTb.TabIndex = 41;
            this.ALPassTb.TextChanged += new System.EventHandler(this.ALPassTb_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkOrange;
            this.label10.Location = new System.Drawing.Point(468, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(191, 33);
            this.label10.TabIndex = 46;
            this.label10.Text = "Admin Panel";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Aquamarine;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(362, 450);
            this.panel3.TabIndex = 47;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(40, 108);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(278, 260);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // AdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ALoginBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ALPassTb);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AdminLogin";
            this.Text = "AdminLogin";
            this.Load += new System.EventHandler(this.AdminLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ALoginBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ALPassTb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}