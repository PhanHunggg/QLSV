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
    public partial class frmDSSV : Form
    {
        public frmDSSV()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDSSV_Load(object sender, EventArgs e)
        {
            LoadDSSV();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadDSSV()
        {

            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                Key = "@tuKhoa",
                Value = txtTuKhoa.Text
            });

            dgvSinhVien.DataSource = new Database().SelectData("SelectAllSinhVien", lstPara);

            dgvSinhVien.Columns["ma_sinh_vien"].HeaderText = "Mã sinh viên";
            dgvSinhVien.Columns["ho_ten"].HeaderText = "Họ tên";
            dgvSinhVien.Columns["ngay_sinh"].HeaderText = "Ngày sinh";
            dgvSinhVien.Columns["gioi_tinh"].HeaderText = "Giới tính";
            dgvSinhVien.Columns["que_quan"].HeaderText = "Quê quán";
            dgvSinhVien.Columns["dia_chi"].HeaderText = "Địa chỉ";
            dgvSinhVien.Columns["dien_thoai"].HeaderText = "Số điện thoại";
            dgvSinhVien.Columns["email"].HeaderText = "Email";
        }

        private void dgvSinhVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // khi double click vào sinh viên
            // sẽ hiện ra form cập nhật sinh viên
            // để cập nhật đc sinh viên phải lấy đc mã sinh viên
            if(e.RowIndex > 0)
            {
                var mssv = dgvSinhVien.Rows[e.RowIndex].Cells["ma_sinh_vien"].Value.ToString();
                // cần lấy mã sinh viên này truyền vào form sinh viên
                new frmSinhVien(mssv).ShowDialog();

                // sau khi thực thi và đóng form
                // load lại danh sách
                LoadDSSV();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new frmSinhVien(null).ShowDialog();
            LoadDSSV();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDSSV();
        }
    }
}
