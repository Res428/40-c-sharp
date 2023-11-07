using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_Main
{
    public partial class frmDSSV : Form
    {
        public frmDSSV()
        {
            InitializeComponent();
        }

        private void frmDSSV_Load(object sender, EventArgs e)
        {
            LoadDSSV();
        }

        private string tuKhoa = "";

        private void LoadDSSV()
        {
            tuKhoa = txtTimKiem.Text;
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@TuKhoa",
                value = tuKhoa,
            });

            dgvDSSV.DataSource = new Database().SelectData("SelectAllSinhVien",lstPara);
            dgvDSSV.Columns["MaSinhVien"].HeaderText = "Mã SV";
            dgvDSSV.Columns["HoTen"].HeaderText = "Họ và Tên";
            dgvDSSV.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvDSSV.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvDSSV.Columns["QueQuan"].HeaderText = "Quê Quán";
            dgvDSSV.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvDSSV.Columns["Email"].HeaderText = "Email";
            dgvDSSV.Columns["DienThoai"].HeaderText = "Điện Thoại";
        }

        private void dgvDSSV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var msv = dgvDSSV.Rows[e.RowIndex].Cells["MaSinhVien"].Value.ToString();
                new frmSinhVien(msv).ShowDialog();
                LoadDSSV();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new frmSinhVien(null).ShowDialog();
            LoadDSSV();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {            
            LoadDSSV();
        }
    }
}
