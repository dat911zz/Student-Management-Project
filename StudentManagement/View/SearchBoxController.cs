using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.View
{
    public class SearchBoxController
    {
        public void UploadData_MaSV_Box(ComboBox box, SqlConnection conn)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MaSV FROM SinhVien", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            box.DataSource = dt;
            box.DisplayMember = "MaSV";
            box.ValueMember = "MaSV";
        }
        public void UploadData_TenSV_Box(ComboBox box, SqlConnection conn)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TenSV FROM SinhVien", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            box.DataSource = dt;
            box.DisplayMember = "TenSV";
            box.ValueMember = "TenSV";
        }
        public void SearchBox_Text_Form(ComboBox boxMa, ComboBox boxTen)
        {
            boxMa.Text = "--Chọn mã SV--";
            boxTen.Text = "--Chọn tên SV--";
        }
    }
}
