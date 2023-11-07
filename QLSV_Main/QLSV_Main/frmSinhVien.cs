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
    public partial class frmSinhVien : Form
    {
        private string msv;
        public frmSinhVien(string msv)
        {
            this.msv = msv;
            InitializeComponent();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(msv))
            {
                this.Text = "Thêm mới Sinh Viên";
            }
            else
            {
                this.Text = "Cập nhật thông tin Sinh Viên";
                var r = new Database().Select("SelectOneSinhVien '"+msv+"'");
                txtHo.Text = r["Ho"].ToString();
                txtTenDem.Text = r["TenDem"].ToString();
                txtTen.Text = r["Ten"].ToString();
                mtbNgaySinh.Text = r["NgaySinh"].ToString();
                if(r["GioiTinh"].ToString()=="Nam"){
                    rbtNam.Checked = true;
                }else{
                    rbtNu.Checked = true;
                };
                txtQueQuan.Text = r["QueQuan"].ToString();
                txtDiaChi.Text = r["DiaChi"].ToString();
                txtEmail.Text = r["Email"].ToString();
                txtDienThoai.Text = r["DienThoai"].ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // xử lý 2 tình huống
            //1. mã sinh viên không có giá trị -> thêm mới
            //2. cập nhật 
            string sql = "";
            string khoa = txtKhoa.Text;
            string ho = txtHo.Text;
            string tenDem = txtTenDem.Text;
            string ten = txtTen.Text;
            DateTime ngaysinh;
            try
            {
                ngaysinh = DateTime.ParseExact(mtbNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                mtbNgaySinh.Select();
                return;
            }
            string gioitinh = rbtNam.Checked ? "1" : "2";
            string QueQuan = txtQueQuan.Text;
            string DiaChi = txtDiaChi.Text;
            string DienThoai = txtDienThoai.Text;
            string Email = txtEmail.Text;

            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@Khoa",
                value = khoa
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@Ho",
                value = ho
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@TenDem",
                value = tenDem,
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@Ten",
                value = ten
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@NgaySinh",
                value = ngaysinh.ToString("yyyy-MM-dd"),
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@GioiTinh",
                value = gioitinh
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@QueQuan",
                value = QueQuan
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@DiaChi",
                value = DiaChi
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@DienThoai",
                value = DienThoai
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@Email",
                value = Email
            });

            if (string.IsNullOrEmpty(msv))
            { // thêm mới
                sql = "ThemMoiSinhVien";
            }
            else // cập nhật
            {
                sql = "updateSinhVien";
                lstPara.Add(new CustomParameter()
                {
                    key = "@MaSinhVien",
                    value = msv
                });
            }
            var rs = new Database().ExeCute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(msv))
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
                MessageBox.Show("Có lỗi trong quá trình thực thi");
            }
        }
    }
}
