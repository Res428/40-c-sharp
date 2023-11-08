using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_Main
{
    public partial class DoiMatKhau : Form
    {        
        private string maSo;
        private string hoTen;
        private string loaiTK;
        private string email;
        public DoiMatKhau(string maSo, string hoTen, string loaiTK,string email)
        {
            this.maSo = maSo;
            this.hoTen = hoTen;
            this.loaiTK = loaiTK;
            this.email = email;
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            lblHoTen.Text = hoTen;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMKcu.Text))
            {
                MessageBox.Show("Nhập mật khẩu cũ");
                txtMKcu.Select();
            }
            else
            {
                var mk = txtMKcu.Text;                

                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@loaiTK",
                    value = loaiTK
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@email",
                    value = email
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@maSo",
                    value = maSo
                });

                var rs = new Database().Login("checkMatKhau", lstPara);

                if (mk != rs.ItemArray[0].ToString())
                {
                    MessageBox.Show("Mật khẩu cũ không đúng");
                    txtMKcu.Select();
                }
            }
            if (string.IsNullOrEmpty(txtMKmoi.Text) || string.IsNullOrEmpty(txtReMKmoi.Text))
            {
                MessageBox.Show("Chưa nhập đủ mật khẩu mới và nhắc lại mật khẩu mới");
                txtMKmoi.Select();
            }
            else
            {
                if (txtMKmoi.Text != txtReMKmoi.Text)
                {
                    MessageBox.Show("Xác nhận mật khẩu mới không trùng khớp");
                    txtReMKmoi.Select();
                }
                else
                {
                    var mkMoi = txtMKmoi.Text;  

                    List<CustomParameter> lstPara = new List<CustomParameter>();
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@loaiTK",
                        value = loaiTK
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@matKhauMoi",
                        value = mkMoi
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@maSo",
                        value = maSo
                    });
                    var rss = new Database().ExeCute("doiMatKhau", lstPara);
                    if (rss == 1)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong quá trình xử lý");
                    }
                }
            }
            
        }
    }
}
