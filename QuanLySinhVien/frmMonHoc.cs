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
    public partial class frmMonHoc : Form
    {
        public frmMonHoc(string mmh)
        {
            this.mmh = mmh;
            InitializeComponent();
        }
        private string mmh;
        private string admin = "admin";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "";
            string tenMonHoc = txtMonHoc.Text;
            string tinChi = txtTinChi.Text;

            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (string.IsNullOrEmpty(mmh) ){

                sql = "InsertMH";
                lstPara.Add(new CustomParameter()
                {
                    Key = "@nguoiTao",
                    Value = admin
                });

            }else
            {
                sql = "updateMH";
                lstPara.Add(new CustomParameter()
                {
                    Key = "@maMonHoc",
                    Value = mmh,
                });
                lstPara.Add(new CustomParameter()
                {
                    Key = "@nguoiCapNhat",
                    Value = admin
                });
            }

            lstPara.Add(new CustomParameter()
            {
                Key = "@tenMonHoc",
                Value = tenMonHoc,
            });
            lstPara.Add(new CustomParameter()
            {
                Key = "@soTinChi",
                Value = tinChi,
            });


            var rs = new Database().ExeCute(sql, lstPara);

            if (rs == 1)
            {
                if (string.IsNullOrEmpty(mmh))
                {
                    MessageBox.Show("Thêm mới môn học thành công");
                }
                else
                {

                    MessageBox.Show("Cập nhật môn học thành công");
                }
                this.Dispose(); // đóng form sau khi thực thi
            }
            else
            {
                MessageBox.Show("Thực thi thất bại");

            }
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mmh))
            {
                this.Text = "Thêm môn học";
            }else
            {
                this.Text = "Cập nhật môn học";
                var r = new Database().Select("selectMH '" + int.Parse(mmh) + "'");
                
                txtMonHoc.Text = r["ten_mon_hoc"].ToString();
                txtTinChi.Text = r["so_tin_chi"].ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
