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
    public partial class frmDSMHĐky : Form
    {
        private string msv;
        public frmDSMHĐky(string msv)
        {
            this.msv = msv;
            InitializeComponent();
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadMHDaDKy()
        {
            List<CustomParameter> lst = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    Key= "@maSinhVien",
                    Value= msv
                }
            };
            dgvDSMHDKy.DataSource = new Database().SelectData("monDaDKy", lst);
        }

        private void frmDSMHĐky_Load(object sender, EventArgs e)
        {
            loadMHDaDKy();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new frmDangKy(msv).ShowDialog();
            loadMHDaDKy();
        }
    }
}
