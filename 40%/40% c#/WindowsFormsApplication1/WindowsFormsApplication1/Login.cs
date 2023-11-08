using QLSV_Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
         
        }
        public string loaiTk = "";
        public string email = "";
        string mk = "";
        public string maso = "";
        public string hoten = "";

        public bool login = false;
        public bool exit = false;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbxltk.SelectedIndex < 0)
            { MessageBox.Show("Chọn tài khoản đăng nhập");
                cbxltk.Select();
                return;
            }
            if (string.IsNullOrEmpty(tk.Text))
            {
                MessageBox.Show("Chưa có tài khoản kìa má");
                tk.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtmk.Text))
            { 
                MessageBox.Show("Nhập mật khẩu kìa");
                txtmk.Select();
                return;
            } 
            else 
            {
                switch (cbxltk.Text)
                {
                    case "Giáo Viên":
                        loaiTk = "GV";
                        break;

                    case "Sinh Viên":
                        loaiTk = "SV";
                        break;
                }
                email = tk.Text;
                mk = txtmk.Text;
            }
            List<CustomParameter> list = new List<CustomParameter>()
            {
                new CustomParameter(){
                    key = "@loaiTK",
                    value = loaiTk
                },
                new CustomParameter(){
                    key = "@email",
                    value = email
                },
                new CustomParameter(){
                    key = "@matKhau",
                    value = mk
                },
            };

            var rs = new Database().Login("dangNhap", list);

            if (rs != null)
            {
                login = true;
                hoten = rs.ItemArray[1].ToString();
                maso = rs.ItemArray[0].ToString();
                MessageBox.Show("Đăng nhập thành công", "Thành công");
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kiểm tra lại Email hoặc Mật khẩu", "Không thành công", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tk.Select();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exit = true;
            Application.Exit();
        }
    }
}


