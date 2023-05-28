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
    public partial class frmQLyLH : Form
    {
        public frmQLyLH(string mgv)
        {
            this.mgv = mgv;
            InitializeComponent();
        }
        private string mgv;

        private void dgvKQ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadDSLop()
        {
           List<CustomParameter> lst = new List<CustomParameter>();
            lst.Add(new CustomParameter()
            {
                Key= "@maGiaoVien",
                Value = mgv
            });
            lst.Add(new CustomParameter()
            {
                Key = "@tuKhoa",
                Value = txtTuKhoa.Text
            });
            dgvKQ.DataSource = new Database().SelectData("trCuuLop", lst);
        }
        private void frmQLyLH_Load(object sender, EventArgs e)
        {
            loadDSLop();
        }
    }
}
