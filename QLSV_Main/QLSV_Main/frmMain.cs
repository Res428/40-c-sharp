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
    public partial class frmMain : Form
    {
        Timer timer1;
        private string maSo = "";
        private string loaiTk = "";
        private string hoTen = "";
        private string email = "";
        private bool login;
        public frmMain()
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
                quanLyToolStripMenuItem.Visible = true;
                dangKyMonoolStripMenuItem.Visible = false;
                nhapDiemToolStripMenuItem.Visible = true;
            }
            else if (loaiTk.Equals("SV"))
            {
                quanLyToolStripMenuItem.Visible = false;
                nhapDiemToolStripMenuItem.Visible = false;
                dangKyMonoolStripMenuItem.Visible = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            var fn = new frmLogin();
            fn.ShowDialog();
            maSo = fn.maSo;
            loaiTk = fn.loaiTk;
            hoTen = fn.hoTen;
            email = fn.Email;
            lblXinChao.Text = loaiTk + ": " + hoTen;
            phanQuyen();
            frmWelcome f = new frmWelcome();
            AddFromLoad(f);
        }

        private void AddFromLoad(Form f)
        {
            this.pnlContent.Controls.Clear();
            this.lblXinChao.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.pnlContent.Controls.Add(f);
            f.Show();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThoatApp();
        }

        private void ThoatApp()
        {
            DialogResult h = MessageBox.Show("Bạn có muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }

        private void giaoVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSGV f = new frmDSGV();
            AddFromLoad(f);
        }

        private void sinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSSV f = new frmDSSV();
            AddFromLoad(f);
        }

        private void monHocToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void diemSoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fn = new frmLogin();
            fn.ShowDialog();
            loaiTk = fn.loaiTk;
            hoTen = fn.hoTen;
            maSo = fn.maSo;
            email = fn.Email;
            lblXinChao.Text = loaiTk + ": " + hoTen;
            phanQuyen();
            frmWelcome f = new frmWelcome();
            AddFromLoad(f);
        }

        private void doiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new frmDoiMatKhau(maSo, hoTen, loaiTk, email);
            fm.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ThoatApp();
        }
    }
}
