﻿using QLSV_Main;
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
        public bool login = false;
        public bool isThoat = false;
        public Login()
        {
            InitializeComponent();
        }

        public string Email = "";
        public string loaiTk = ""; /// note
        string mk = "";
        public string maSo = "";
        public string hoTen = ""; // note



        private void button2_Click(object sender, EventArgs e)
        {
            isThoat = true;
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbxltk.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại tài khoản đăng nhập");
                cbxltk.Select();
                return;
            }
            if (string.IsNullOrEmpty(tk.Text))
            {
                MessageBox.Show("Chưa nhập Email");
                tk.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtmk.Text))
            {
                MessageBox.Show("Chưa nhập Mật Khẩu");
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
                Email = tk.Text;
                mk = txtmk.Text;
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

    }
}


