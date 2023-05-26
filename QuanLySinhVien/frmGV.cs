using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class frmGV : Form
    {
        public frmGV(string mgv)
        {
            this.mgv = mgv;
            InitializeComponent();
        }
        private string mgv;
        private string admin = "admin";

        private void frmGV_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mgv))
            {
                this.Text = "Thêm mới giáo viên";
            }
            else
            {
                this.Text = "Cập nhật thông tin giáo viên";
                

                var r = new Database().Select("selectGV '" + int.Parse(mgv) + "'");
                // sau khi load thông tin sinh viên thành công 
                // set các thông tin vào form tương ứng

                txtHo.Text = r["ho"].ToString();
                txtTenDem.Text = r["ten_dem"].ToString();
                txtTen.Text = r["ten"].ToString();
                txtDiaChi.Text = r["dia_chi"].ToString();
                txtSdt.Text = r["so_dien_thoai"].ToString();
                txtEmail.Text = r["email"].ToString();
                mtbNgaySinh.Text = r["ngay_sinh"].ToString();
                if (int.Parse(r["gioi_tinh"].ToString()) == 1)
                {
                    rbtNu.Checked = true;
                }
                else
                {
                    rbtNam.Checked = true;
                }

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            string sql = "";
            string ho = txtHo.Text;
            string tenDem = txtTenDem.Text;
            string ten = txtTen.Text;
            DateTime ngaySinh;
            try
            {
                ngaySinh = DateTime.ParseExact(mtbNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ngày sinh không hợp lệ: ");
                mtbNgaySinh.Select();
                return;
            }
            string gioiTinh = rbtNam.Checked ? "0" : "1";
            string diaChi = txtDiaChi.Text;
            string dienThoai = txtSdt.Text;
            string email = txtEmail.Text;

            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (string.IsNullOrEmpty(mgv))
            {
                sql = "InsertGV";
                lstPara.Add(new CustomParameter()
                {
                    Key = "@nguoiTao",
                    Value = admin
                });

            }
            else
            {
                sql = "updateGV";
                lstPara.Add(new CustomParameter()
                {
                    Key = "@MaGiaoVien",
                    Value = mgv,
                });
                lstPara.Add(new CustomParameter()
                {
                    Key = "@NguoiCapNhat",
                    Value = admin
                });
            }

           
           
            lstPara.Add(new CustomParameter()
            {
                Key = "@Ho",
                Value = ho
            });

            lstPara.Add(new CustomParameter()
            {
                Key = "@TenDem",
                Value = tenDem
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@Ten",
                Value = ten
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@NgaySinh",
                Value = ngaySinh.ToString("yyyy-MM-dd")
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@GioiTinh",
                Value = gioiTinh
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@DiaChi",
                Value = diaChi
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@DienThoai",
                Value = dienThoai
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@Email",
                Value = email
            });
           

            var rs = new Database().ExeCute(sql, lstPara);

            if (rs == 1)
            {
                if (string.IsNullOrEmpty(mgv))
                {
                    MessageBox.Show("Thêm mới sinh viên thành công");
                }
                else
                {

                    MessageBox.Show("Cập nhật sinh viên thành công");
                }
                this.Dispose(); // đóng form sau khi thực thi
            }
            else
            {
                MessageBox.Show("Thực thi thất bại");

            }
        }
    }
}
