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
    public partial class frmDSLH : Form
    {
        public frmDSLH()
        {
            InitializeComponent();
        }

        private void LoadDSLH()
        {
            string sql = "selectAllClass";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                Key = @"tuKhoa",
                Value = txtTuKhoa.Text
            });
            dgvClass.DataSource = new Database().SelectData(sql, lstPara);
        }

        private void frmDSLH_Load(object sender, EventArgs e)
        {
            LoadDSLH();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDSLH();

        }

        private void dgvClass_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var mlh = dgvClass.Rows[e.RowIndex].Cells["ma_lop_hoc"].Value.ToString();
                new frmClass(mlh).ShowDialog();
                LoadDSLH();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new frmClass(null).ShowDialog();
                LoadDSLH();
        }
    }
}
