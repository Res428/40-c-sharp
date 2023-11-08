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

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
         
        }
        public string loaiTk = "";
        public string TaiKhoan = "";
        string MK = "";
        public string maso = "";
        public string hoten = "";


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loaitk.SelectedIndex < 0)
            { MessageBox.Show("Chọn tài khoản đăng nhập");
                loaitk.Select();
                return;
            }
            if (string.IsNullOrEmpty(tk.Text))
            {
                MessageBox.Show("Chưa có tài khoản kìa má");
                tk.Select();
                return;
            }
            if (string.IsNullOrEmpty(mk.Text))
            { MessageBox.Show("Nhập mật khẩu kìa");
                mk.Select();
            } else {
                switch (loaitk.Text)
                {
                    case "Giao Vien":
                        loaiTk = "GV";
                        break;

                    case "Sinh Vien":
                        loaiTk = "SV";
                        break;
                }
                TaiKhoan=tk.Text;
                MK = mk.Text;


                
            }
            List<CustomParameter> list = new List<CustomParameter>();
            {
                new CustomParameter()
                {
                    key = "@loaitk",
                    value = loaiTk
                };
                
                    new CustomParameter()
                    {
                        key = "@TaiKhoan",
                        value = TaiKhoan
                    };
                
                
                    new CustomParameter()
                    {
                        key = " @matkhau",
                        value = MK
                    };
                }
            //var  rs =new Database


               
            }
                
    }
}


