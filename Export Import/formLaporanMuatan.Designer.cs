namespace Export_Import
{
    partial class formLaporanMuatan
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
            this.cbInvoice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomerContainer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbInvoice
            // 
            this.cbInvoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInvoice.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInvoice.FormattingEnabled = true;
            this.cbInvoice.Location = new System.Drawing.Point(140, 15);
            this.cbInvoice.Name = "cbInvoice";
            this.cbInvoice.Size = new System.Drawing.Size(300, 27);
            this.cbInvoice.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nomer Invoice";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(1263, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 31);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Location = new System.Drawing.Point(-1, 48);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.Size = new System.Drawing.Size(1351, 646);
            this.crystalReportViewer.TabIndex = 3;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Red;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(12, 700);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(490, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "Container No";
            // 
            // txtNomerContainer
            // 
            this.txtNomerContainer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomerContainer.Location = new System.Drawing.Point(590, 15);
            this.txtNomerContainer.Name = "txtNomerContainer";
            this.txtNomerContainer.Size = new System.Drawing.Size(200, 27);
            this.txtNomerContainer.TabIndex = 25;
            // 
            // formLaporanMuatan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 747);
            this.Controls.Add(this.txtNomerContainer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.crystalReportViewer);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbInvoice);
            this.Name = "formLaporanMuatan";
            this.Text = "formLaporanMuatan";
            this.Load += new System.EventHandler(this.formLaporanMuatan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbInvoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomerContainer;
    }
}