using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class frmDSGV : Form
    {
        public frmDSGV()
        {
            InitializeComponent();
        }
        private string tuKhoa = "";

        private void LoadDSGV ()
        {
            string sql = "selectAllGV";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter() { 
                Key = @"tuKhoa",
                Value = txtTuKhoa.Text
            });
            dgvDSGV.DataSource = new Database().SelectData(sql, lstPara);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDSGV();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDSGV_Load(object sender, EventArgs e)
        {
            LoadDSGV();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new frmGV(null).ShowDialog();
            LoadDSGV();
        }

        private void dgvDSGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var mgv = dgvDSGV.Rows[e.RowIndex].Cells["ma_giao_vien"].Value.ToString();
                new frmGV(mgv).ShowDialog();
                LoadDSGV();
            }
        }

        
    }
}
