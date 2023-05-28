using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private string tk;
        private string loaiTK;
        private void frmMain_Load(object sender, EventArgs e)
        {
            var fn = new frmLogin();
            fn.ShowDialog();
            tk = fn.taiKhoan;
            loaiTK = fn.loaiTK;
            if (loaiTK.Equals("admin"))
            {
                chamDiemToolStripMenuItem.Visible = false;
                chucNangToolStripMenuItem.Visible = false;
            }
            else
            {
                quanLyToolStripMenuItem.Visible = false;
                if (loaiTK.Equals("gv"))
                {
                    chucNangToolStripMenuItem.Visible = false;
                }
                else
                {
                    chamDiemToolStripMenuItem.Visible = false;
                }
            }
            frmWelcome f = new frmWelcome();
            AddForm(f);
          //  dgvData.DataSource = db.SelectData(null);
        }

        private void AddForm(Form f)
        {
            this.pnlContent.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.pnlContent.Controls.Add(f);
            f.Show();
        }

        private void monToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSGV f = new frmDSGV();
            AddForm(f);
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSSV f = new frmDSSV();
            AddForm(f);
        }

        private void monHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSMH f = new frmDSMH();
            AddForm(f);
        }

        private void diemThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSDThi f = new frmDSDThi();
            AddForm(f);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lopHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSLH f = new frmDSLH();
            AddForm(f);
        }

        private void dangKyToolStripMenuItem_Click(object sender, EventArgs e)
        {
          new frmDSMHĐky(tk).ShowDialog();
        }

        private void traCuuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKQHocTap f = new frmKQHocTap(tk);
            AddForm(f);
        }

        private void chamDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLyLH f = new frmQLyLH(tk);
            AddForm(f);
        }
    }
}
