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
    public partial class frmSinhVien : Form
    {
        public frmSinhVien(string mssv)
        {
            this.mssv = mssv;
            InitializeComponent();
        }
        private string mssv;

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(mssv))
            {
                this.Text = "Thêm mới sinh viên";
            }
            else
            {
                this.Text = "Cập nhật thông tin sinh viên";
                // lấy thông tin sinh vien dựa vào mã số sinh viên
                
                var r = new Database().Select("selectSV '" + mssv + "'");
               // sau khi load thông tin sinh viên thành công 
               // set các thông tin vào form tương ứng

                txtHo.Text = r["ho"].ToString();
                txtTenDem.Text = r["ten_dem"].ToString();
                txtTen.Text = r["ten"].ToString();
                txtQueQuan.Text = r["que_quan"].ToString();
                txtDiaChi.Text = r["dia_chi"].ToString();
                txtSdt.Text = r["dien_thoai"].ToString();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // nếu mã sinh vien tồn --> cập nhật sinh viên
            // nếu mã sinh viên không tồn tại --> thêm sinh viên

            string sql = "";
            string ho = txtHo.Text;
            string tenDem = txtTenDem.Text;
            string ten = txtTen.Text;
            DateTime ngaySinh;
            try
            {
                ngaySinh = DateTime.ParseExact(mtbNgaySinh.Text,"dd/MM/yyyy",CultureInfo.InvariantCulture);
            }catch (Exception ex)
            {
                MessageBox.Show("Ngày sinh không hợp lệ: ");
                mtbNgaySinh.Select();
                return;
            }
            string gioiTinh = rbtNam.Checked ? "0" : "1";
            string queQuan = txtQueQuan.Text;
            string diaChi = txtDiaChi.Text;
            string dienThoai = txtSdt.Text;
            string email = txtEmail.Text;

            //khai báo 1 danh sách tham số = class CustomParameter 
            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (string.IsNullOrEmpty(mssv))
            {
                sql = "ThemMoiSV";
                
            }
            else
            {
                sql = "updateSV";
                lstPara.Add(new CustomParameter()
                {
                    Key = "@MaSinhVien",
                    Value = mssv,
                });
            }

            lstPara.Add(new CustomParameter()
            {
                Key = "@ho",
                Value = ho
            });

            lstPara.Add(new CustomParameter()
            {
                Key = "@tenDem",
                Value = tenDem
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@ten",
                Value = ten
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@ngaySinh",
                Value = ngaySinh.ToString("yyyy-MM-dd")
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@gioiTinh",
                Value = gioiTinh
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@queQuan",
                Value = queQuan
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@diaChi",
                Value = diaChi
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@dienThoai",
                Value = dienThoai
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@email",
                Value = email
            });

            var rs = new Database().ExeCute(sql,lstPara);

            if(rs == 1)
            {
                if (string.IsNullOrEmpty(mssv))
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
