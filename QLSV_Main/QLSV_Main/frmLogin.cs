using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace QLSV_Main
{
    public partial class frmLogin : Form
    {
        public bool login = false;
        public bool isThoat = false;
        //MD5 mD5 = MD5.Create();
        public frmLogin()
        {
            InitializeComponent();
        }

        public string Email = "";
        public string loaiTk = ""; /// note
        string mk = "";
        public string maSo = "";
        public string hoTen = ""; // note


        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            isThoat = true;
            Application.Exit();   
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (cbxLoaiTK.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại tài khoản đăng nhập");
                cbxLoaiTK.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Chưa nhập Email");
                txtEmail.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Chưa nhập Mật Khẩu");
                txtMatKhau.Select();
                return;
            }
            else
            {
                switch (cbxLoaiTK.Text)
                {
                    case "Giáo Viên":
                        loaiTk = "GV";
                        break;
                    case "Sinh Viên":
                        loaiTk = "SV";
                        break;
                }
                Email = txtEmail.Text;
                mk = (txtMatKhau.Text);
            }           

            List<CustomParameter> lst = new List<CustomParameter>()
            {
                new CustomParameter(){
                    key = "@loaiTK",
                    value = loaiTk
                },
                new CustomParameter(){
                    key = "@email",
                    value = Email
                },
                new CustomParameter(){
                    key = "@matKhau",
                    value = mk
                },
            };

            var rs = new Database().Login("dangNhap", lst);

            if (rs != null)            
            {
                login = true;
                hoTen = rs.ItemArray[1].ToString();
                maSo = rs.ItemArray[0].ToString();
                MessageBox.Show("Đăng nhập thành công", "Thành công");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kiểm tra lại Email hoặc Mật khẩu", "Không thành công", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Select();
            }            
        }
        
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        




    }
}
