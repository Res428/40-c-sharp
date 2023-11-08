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
    public partial class main : Form
    {
        private string maSo = "";
        private string loaiTk = "";
        private string hoTen = "";
        private string email = "";
        private bool login;
        public main()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Tick += timer1_Tick;
            timer1.Interval = 1000;
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label1.Text = DateTime.Now.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            var fn = new Login();
            fn.ShowDialog();
            maSo = fn.maSo;
            loaiTk = fn.loaiTk;
            hoTen = fn.hoTen;
            email = fn.Email;
            label3.Text = loaiTk + ": " + hoTen;
            phanQuyen();
            main f = new main();
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

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void ExitApp()
        {
            DialogResult h = MessageBox.Show("Bạn có muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }

        

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fn = new Login();
            fn.ShowDialog();
            loaiTk = fn.loaiTk;
            hoTen = fn.hoTen;
            maSo = fn.maSo;
            email = fn.Email;
            label3.Text = loaiTk + ": " + hoTen;
            phanQuyen();
            main f = new main();
            AddFromLoad(f);
        }

        private void doiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new DoiMatKhau(maSo, hoTen, loaiTk, email);
            fm.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitApp();
        }
    }
}
