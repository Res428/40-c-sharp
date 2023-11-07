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
    public partial class frmDSGV : Form
    {
        private string tuKhoa = "";
        private string sql = "";
        public frmDSGV()
        {
            InitializeComponent();
        }

        private void frmDSGV_Load(object sender, EventArgs e)
        {
            LoadDSGV();
        }

        private void LoadDSGV()
        {
            tuKhoa = txtTimKiem.Text;
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@TuKhoa",
                value = tuKhoa
            });
            dgvDSGV.DataSource = new Database().SelectData("SelectAllGiaoVien", lstPara);
            dgvDSGV.Columns["MaGiaoVien"].HeaderText = "Mã GV";
            dgvDSGV.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvDSGV.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvDSGV.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvDSGV.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvDSGV.Columns["DienThoai"].HeaderText = "Điện Thoại";
                
        }

        private void dgvDSGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var mgv = dgvDSGV.Rows[e.RowIndex].Cells["MaGiaoVien"].Value.ToString();
                new frmGiaoVien(mgv).ShowDialog();
                LoadDSGV();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new frmGiaoVien(null).ShowDialog();
            LoadDSGV();
        }

        //private void btnTimKiem_Click(object sender, EventArgs e)
        //{
        //    LoadDSGV();
        //}
        string mgv = "";
        string tgv = "";
        private void dgvDSGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                mgv = dgvDSGV.Rows[e.RowIndex].Cells["MaGiaoVien"].Value.ToString();
                tgv = dgvDSGV.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mgv))
            {
                MessageBox.Show("Chọn giáo viên cần xóa");
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Xóa giáo viên: " + tgv, "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlr == DialogResult.Yes)
                {
                    List<CustomParameter> lstPara = new List<CustomParameter>();
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@MaGiaoVien",
                        value = mgv
                    });
                    sql = "DeleteGiaoVien";
                    var rs = new Database().ExeCute(sql, lstPara);
                    if (rs == 1)
                    {
                        MessageBox.Show("Đã xóa giáo viên khỏi danh sách");
                        LoadDSGV();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong quá trình xử lý");
                    }
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDSGV();
        }
    }
}
