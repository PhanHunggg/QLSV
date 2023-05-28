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
    public partial class frmKQHocTap : Form
    {
        public frmKQHocTap(string msv)
        {
            this.msv = msv;
            InitializeComponent();
        }
        private string msv;

        private void loadKQHT()
        {
            List<CustomParameter> lst = new List<CustomParameter>();
            lst.Add(new CustomParameter()
            {
                Key = "@maSinhVien",
                Value = msv
            });

            lst.Add(new CustomParameter()
            {
                Key = "@tuKhoa",
                Value = txtTuKhoa.Text
            });

            dgvQly.DataSource = new Database().SelectData("traCuuDiem", lst);
        }
        private void frmKQHocTap_Load(object sender, EventArgs e)
        {
            loadKQHT();

            dgvQly.Columns["ma_mon_hoc"].HeaderText = "Mã môn học";
            dgvQly.Columns["ten_mon_hoc"].HeaderText = "Tên môn học";
            dgvQly.Columns["lan_hoc"].HeaderText = "Lần học";
            dgvQly.Columns["diem_lan_1"].HeaderText = "Điểm lần 1";
            dgvQly.Columns["diem_lan_2"].HeaderText = "Điểm lần 2";
            dgvQly.Columns["giao_vien"].HeaderText = "Giáo viên";
        }

        private void dgvKQ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
