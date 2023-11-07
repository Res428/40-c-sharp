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

namespace QLSV_Main
{
    public partial class frmGiaoVien : Form
    {
        private string mgv;
        public frmGiaoVien(string mgv)
        {
            this.mgv = mgv;
            InitializeComponent();
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(mgv))
            {// thêm mới
                this.Text = "Thêm mới Giáo Viên";
            }
            else // cập nhật
            {
                this.Text = "Cập nhật Giáo Viên";
                var gv = new Database().Select("SelectOneGiaoVien '"+mgv+"'");
                txtHo.Text = gv["Ho"].ToString();
                txtTenDem.Text = gv["TenDem"].ToString();
                txtTen.Text = gv["Ten"].ToString();
                mtbNgaySinh.Text = gv["NgaySinh"].ToString();
                if (gv["GioiTinh"].ToString() == "Nam")
                {
                    rbtNam.Checked = true;
                }
                else
                {
                    rbtNu.Checked = true;
                }
                txtDiaChi.Text = gv["DiaChi"].ToString();
                txtDienThoai.Text = gv["DienThoai"].ToString();
                txtEmail.Text = gv["Email"].ToString();
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
            catch (Exception)
            {
                MessageBox.Show("Định dạng ngày sinh không chính xác");
                mtbNgaySinh.Select();
                return;
            }
            string gioiTinh = rbtNam.Checked ? "1" : "2";
            string diaChi = txtDiaChi.Text;
            string dienThoai = txtDienThoai.Text;
            string email = txtEmail.Text;

            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@Ho",
                value = ho
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@TenDem",
                value = tenDem
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@Ten",
                value = ten
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@NgaySinh",
                value = ngaySinh.ToString("yyyy-MM-dd")
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@GioiTinh",
                value = gioiTinh
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@DiaChi",
                value = diaChi
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@DienThoai",
                value = dienThoai
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@Email",
                value = email
            });

            if (string.IsNullOrEmpty(mgv))
            {
                sql = "ThemMoiGiaoVien";
            }
            else
            {
                sql = "updateGiaoVien";
                lstPara.Add(new CustomParameter()
                {
                    key = "@MaGiaoVien",
                    value = mgv
                });
            }
            var rs = new Database().ExeCute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(mgv))
                {
                    MessageBox.Show("Thêm mới thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Có lỗi trong quá trình xử lý");
            }
        }
    }
}
