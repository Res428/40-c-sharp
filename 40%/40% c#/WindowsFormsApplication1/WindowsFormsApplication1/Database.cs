using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_Main
{
    public class Database
    {
        private string connectString =
            "Data Source = DESKTOP-FRT6KCM; Initial Catalog = QLTB; Integrated Security = True";

        private SqlConnection conn;
        private DataTable dt;
        private SqlCommand cmd;

        public Database()
        {
            try
            {
                conn = new SqlConnection(connectString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("connected failed: " + ex.Message);
            }
        }
        public DataTable SelectData(string sql, List<CustomParameter> lstPara)
        {
            try
            {
                conn.Open();
                //sql = "exec SelectAllSinhVien";
                cmd = new SqlCommand(sql, conn); // sql được truyền từ from vào
                cmd.CommandType = CommandType.StoredProcedure; // Khai báo sử dụng storeprocedure 

                foreach (var para in lstPara)
                {
                    cmd.Parameters.AddWithValue(para.key, para.value);
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load dữ liệu: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataRow Login(string sql, List<CustomParameter> lst)
        {
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var para in lst)
            {
                cmd.Parameters.AddWithValue(para.key, para.value);
            }
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];

            }
            else
            {
                return null;
            }
            conn.Close();
        }

        public DataRow Select(string sql)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi Load chi tiết: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public int ExeCute(string sql, List<CustomParameter> lstPara)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                //cmd.CommandType = CommandType.StoredProcedure; // khai báo sử dụng Procedure SQL
                foreach (var p in lstPara)
                {
                    cmd.Parameters.AddWithValue(p.key, p.value);
                }
                var rs = cmd.ExecuteNonQuery(); // lấy kết quả truy vấn (1) or (0) 
                return (int)rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi thực thi lệnh: " + ex.Message);
                return -100;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
