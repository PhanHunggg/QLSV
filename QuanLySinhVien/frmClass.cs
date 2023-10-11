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
    public partial class frmClass : Form
    {
        public frmClass(string maLop)
        {
            this.maLop = maLop;
            InitializeComponent();
        }
        private string maLop;
        private string admin = "admin";
        private Database db;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmClass_Load(object sender, EventArgs e)
        {
            db = new Database();
            List<CustomParameter> lstPara = new List<CustomParameter>() { 
                new CustomParameter()
                {
                    Key = "@tuKhoa",
                    Value = ""
                }
            };
            cbMonHoc.DataSource =  db.SelectData("selectAllMonHoc", lstPara);
            cbMonHoc.DisplayMember = "ten_mon_hoc";
            cbMonHoc.ValueMember = "ma_mon_hoc";
            cbMonHoc.SelectedIndex = -1;

            cbGiaoVien.DataSource =  db.SelectData("selectAllGV", lstPara);
            cbGiaoVien.DisplayMember = "ho_ten";
            cbGiaoVien.ValueMember = "ma_giao_vien";
            cbGiaoVien.SelectedIndex = -1;


            if (string.IsNullOrEmpty(maLop))
            {
                this.Text = "Thêm lớp học";
            }
            else
            {
                this.Text = "Cập nhật lớp học";

                var r = db.Select("exec selectClass '" + maLop + "'");

                cbMonHoc.SelectedValue = r["ma_mon_hoc"].ToString();
                cbGiaoVien.SelectedValue = r["ma_giao_vien"].ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if(cbMonHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn môn học");
                return;
            }

            if (cbGiaoVien.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giáo viên");
                return;
            }

            string sql = "";
           // string maMonHoc = txtMonHoc.Text;
            //string maGiaoVien = txtGV.Text;

            List<CustomParameter> lstPara = new List<CustomParameter>();

            if (string.IsNullOrEmpty(maLop))
            {

                sql = "insertClass";
                lstPara.Add(new CustomParameter()
                {
                    Key = "@nguoiTao",
                    Value = admin
                });

            }
            else
            {
                sql = "updateClass";
                lstPara.Add(new CustomParameter()
                {
                    Key = "@maLopHoc",
                    Value = maLop,
                });
                lstPara.Add(new CustomParameter()
                {
                    Key = "@nguoiCapNhat",
                    Value = admin
                });
            }


            lstPara.Add(new CustomParameter()
            {
                Key = "@maMonHoc",
                Value = cbMonHoc.SelectedValue.ToString(),
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@maGiaoVien",
                Value = cbGiaoVien.SelectedValue.ToString(),
            });


            var rs = new Database().ExeCute(sql, lstPara);

            if (rs == 1)
            {
                if (string.IsNullOrEmpty(maLop))
                {
                    MessageBox.Show("Thêm mới lớp học thành công");
                }
                else
                {

                    MessageBox.Show("Cập nhật lớp học thành công");
                }
                this.Dispose(); // đóng form sau khi thực thi
            }
            else
            {
                MessageBox.Show("Thực thi thất bại");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
