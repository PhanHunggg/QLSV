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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public string taiKhoan = "";
        public string loaiTK;
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(cbLogin.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản");
                return;
            }

            if (string.IsNullOrEmpty(txtTK.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản");
                txtTK.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                txtMK.Select();
                return;
            }
           
            taiKhoan = txtTK.Text;
            loaiTK = "";
            #region swtk
            switch (cbLogin.Text)
            {
                case "Quản trị viên":
                    loaiTK = "admin";                  
                    break;
                case "Giáo viên":
                    loaiTK = "gv";
                   
                    break;
                case "Sinh viên":
                    loaiTK = "sv";
                    break;              
            }
            #endregion

            List<CustomParameter> lst = new List<CustomParameter>() {
                new CustomParameter()
                {
                    Key = "@loaiTaiKhoan",
                    Value= loaiTK
                },

                new CustomParameter()
                {
                    Key = "@taiKhoan",
                    Value= txtTK.Text
                },

                new CustomParameter()
                {
                    Key = "@matKhau",
                    Value= txtMK.Text
                }
            };
            var rs = new Database().SelectData("dangNhap", lst);

            if (rs.Rows.Count > 0)
            {
                this.Hide();
            }else
            {

                MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ");
            }

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
