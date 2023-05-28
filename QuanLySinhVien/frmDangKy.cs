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
    public partial class frmDangKy : Form
    {
        public frmDangKy(string msv)
        {
            this.msv = msv;
            InitializeComponent();
        }
        private string msv;

        private void loadDSLChuaDky() {
            string sql = "dsLopChuaDky";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                Key = "@maSinhVien",
                Value = msv
            });
            dgvDSL.DataSource = new Database().SelectData(sql, lstPara);
        }
        private void frmDangKy_Load(object sender, EventArgs e)
        {
            loadDSLChuaDky();

            dgvDSL.Columns["ma_lop_hoc"].HeaderText = "Mã lớp";
            dgvDSL.Columns["ma_mon_hoc"].HeaderText = "Mã môn học";
            dgvDSL.Columns["ten_mon_hoc"].HeaderText = "Tên môn học";
            dgvDSL.Columns["so_tin_chi"].HeaderText = "Tín chỉ";
            dgvDSL.Columns["giao_vien"].HeaderText = "Giáo viên";

        }

        private void dgvDSL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSL.Rows[e.RowIndex].Index >=0)
            {
                if (DialogResult.Yes == 
                    MessageBox.Show(
                        "Môn học đăng ký: " + dgvDSL.Rows[e.RowIndex].Cells["ten_mon_hoc"].Value.ToString() + " ?",
                        "Xác nhận đăng ký", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question)
                    )
                {
                    List<CustomParameter> lst = new List<CustomParameter>();
                    lst.Add(new CustomParameter()
                    {
                        Key = "@maSinhVien",
                        Value = msv
                    });
                    lst.Add(new CustomParameter()
                    {
                        Key = "@maLopHoc",
                        Value = dgvDSL.Rows[e.RowIndex].Cells["ma_lop_hoc"].Value.ToString()
                    });

                    var rs = new Database().ExeCute("[dkyMH]", lst);
                    if ( rs == -1)
                    {
                        MessageBox.Show("Học phần này đã đăng ký!!");
                        return;
                    }else
                    {
                        MessageBox.Show("Đã đăng ký thành công!!");
                        loadDSLChuaDky();

                    }

                }
            }
        }
    }
}
