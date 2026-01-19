namespace Admission_Orbit
{
    partial class Apply
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
            this.cmbUniversities = new System.Windows.Forms.ComboBox();
            this.bkash = new System.Windows.Forms.Button();
            this.credit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbUniversities
            // 
            this.cmbUniversities.FormattingEnabled = true;
            this.cmbUniversities.Items.AddRange(new object[] {
            "BUET",
            "Dhaka University",
            "CKRUET",
            "BUP",
            "Jahangirnagar University",
            "University of Chittagong",
            "MIST",
            "GST",
            "Rajshahi University"});
            this.cmbUniversities.Location = new System.Drawing.Point(333, 67);
            this.cmbUniversities.Name = "cmbUniversities";
            this.cmbUniversities.Size = new System.Drawing.Size(121, 28);
            this.cmbUniversities.TabIndex = 0;
            // 
            // bkash
            // 
            this.bkash.Location = new System.Drawing.Point(363, 132);
            this.bkash.Name = "bkash";
            this.bkash.Size = new System.Drawing.Size(75, 41);
            this.bkash.TabIndex = 1;
            this.bkash.Text = "Bkash";
            this.bkash.UseVisualStyleBackColor = true;
            this.bkash.Click += new System.EventHandler(this.bkash_Click);
            // 
            // credit
            // 
            this.credit.Location = new System.Drawing.Point(363, 214);
            this.credit.Name = "credit";
            this.credit.Size = new System.Drawing.Size(75, 48);
            this.credit.TabIndex = 2;
            this.credit.Text = "Credit Card";
            this.credit.UseVisualStyleBackColor = true;
            this.credit.Click += new System.EventHandler(this.credit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Apply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.credit);
            this.Controls.Add(this.bkash);
            this.Controls.Add(this.cmbUniversities);
            this.Name = "Apply";
            this.Text = "Apply";
            this.Load += new System.EventHandler(this.Apply_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUniversities;
        private System.Windows.Forms.Button bkash;
        private System.Windows.Forms.Button credit;
        private System.Windows.Forms.Button button1;
    }
}