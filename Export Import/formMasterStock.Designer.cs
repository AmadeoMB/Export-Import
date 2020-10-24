namespace Export_Import
{
    partial class formMasterStock
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBack = new System.Windows.Forms.Label();
            this.btnList = new System.Windows.Forms.Button();
            this.btnStockIssue = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 95);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(120, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 54);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "PT. EXPORT IMPORT INDONESIA";
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBack.Location = new System.Drawing.Point(12, 98);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(40, 19);
            this.lblBack.TabIndex = 4;
            this.lblBack.Text = "Back";
            this.lblBack.Click += new System.EventHandler(this.lblBack_Click);
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnList.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnList.Location = new System.Drawing.Point(186, 145);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(330, 62);
            this.btnList.TabIndex = 8;
            this.btnList.Text = "List Stock";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnStockIssue
            // 
            this.btnStockIssue.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnStockIssue.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockIssue.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStockIssue.Location = new System.Drawing.Point(186, 222);
            this.btnStockIssue.Name = "btnStockIssue";
            this.btnStockIssue.Size = new System.Drawing.Size(330, 62);
            this.btnStockIssue.TabIndex = 9;
            this.btnStockIssue.Text = "Stock Issue";
            this.btnStockIssue.UseVisualStyleBackColor = false;
            this.btnStockIssue.Click += new System.EventHandler(this.btnStockIssue_Click);
            // 
            // formMasterStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(720, 450);
            this.Controls.Add(this.btnStockIssue);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.panel1);
            this.Name = "formMasterStock";
            this.Text = "Stock";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnStockIssue;
    }
}