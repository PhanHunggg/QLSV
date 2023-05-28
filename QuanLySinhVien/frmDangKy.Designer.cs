namespace QuanLySinhVien
{
    partial class frmDangKy
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
            this.dgvDSL = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSL)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDSL
            // 
            this.dgvDSL.AllowUserToAddRows = false;
            this.dgvDSL.AllowUserToDeleteRows = false;
            this.dgvDSL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSL.Location = new System.Drawing.Point(0, 0);
            this.dgvDSL.Name = "dgvDSL";
            this.dgvDSL.ReadOnly = true;
            this.dgvDSL.RowHeadersWidth = 51;
            this.dgvDSL.RowTemplate.Height = 24;
            this.dgvDSL.Size = new System.Drawing.Size(1047, 556);
            this.dgvDSL.TabIndex = 0;
            this.dgvDSL.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSL_CellDoubleClick);
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 556);
            this.Controls.Add(this.dgvDSL);
            this.Name = "frmDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dang sách lớp học";
            this.Load += new System.EventHandler(this.frmDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSL;
    }
}