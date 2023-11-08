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

namespace WindowsFormsApplication1
{
    public partial class Giaodien : Form
    {
        private string maso = "";
        private string loaiTk = "";
        private string hoten = "";
        private string email = "";
        private bool login;
        public Giaodien()
        {
            InitializeComponent();
        }
        void phanQuyen()
        {
            if (loaiTk.Equals("GV"))
            {
                quảnLýToolStripMenuItem.Visible = true;
                đăngKýMượnThiếtBịToolStripMenuItem.Visible = true;
            }
            else if (loaiTk.Equals("SV"))
            {
                quảnLýToolStripMenuItem.Visible = false;
                đăngKýMượnThiếtBịToolStripMenuItem.Visible = true;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            var fn = new Login();
            fn.ShowDialog();
            //mk = fn.m;
            loaiTk = fn.loaiTk;
            hoten = fn.TaiKhoan;
            //email = fn.Email;
            label3.Text = loaiTk + ": " + hoten;
            phanQuyen();
            Giaodien f = new Giaodien();
            AddFromLoad(f);
        }

        private void AddFromLoad(Form f)
        {
            panel1.Controls.Clear();
            label3.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label1.Text = DateTime.Now.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApp();
        }
        private void ExitApp()
        {
            DialogResult h = MessageBox.Show("Bạn có muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fmk = new Đoimatkhau(maSo, hoTen, loaiTk, email);
            fmk.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dangxuat f = new Dangxuat();
            AddFromLoad(f);
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhanvien f = new Nhanvien();
            AddFromLoad(f);
        }

        private void thiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thietbi f = new Thietbi();
            AddFromLoad(f);
        }

        private void Giaodien_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitApp();
        }
    }
}
