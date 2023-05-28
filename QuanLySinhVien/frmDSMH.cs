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
    public partial class frmDSMH : Form
    {
        public frmDSMH()
        {
            InitializeComponent();
        }


        private void LoadDSMH()
        {
            string sql = "selectAllMonHoc";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                Key = @"tuKhoa",
                Value = txtTuKhoa.Text
            });
            dgvMH.DataSource = new Database().SelectData(sql, lstPara);
        }

        private void frmDSMH_Load(object sender, EventArgs e)
        {
            LoadDSMH();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDSMH();
        }

        private void dgvMH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var mmh = dgvMH.Rows[e.RowIndex].Cells["ma_mon_hoc"].Value.ToString();
                new frmMonHoc(mmh).ShowDialog();
                LoadDSMH();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new frmMonHoc(null).ShowDialog();
            LoadDSMH();
        }
    }
}
