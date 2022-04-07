using StudentManagement.Data.Database;
using StudentManagement.Models;
using StudentManagement.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.View
{
    public partial class SearchForm : Form
    {
        SqlConnection conn = new SqlConnection(new SQL().GetConnection("", "SinhVien", "test01", "1234").ConnectionString);

        public SearchForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        
        private void SearchForm_Load(object sender, EventArgs e)
        {
            TextBoxWriter writer = new TextBoxWriter(txtConsole_SF);
            Console.SetOut(writer);         
        }



        private void UploadData_MaSV_Box()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MaSV FROM SinhVien", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            maSV_SearchBox.DataSource = dt;
            maSV_SearchBox.DisplayMember = "MaSV";
            maSV_SearchBox.ValueMember = "MaSV";
        }
        private void UploadData_TenSV_Box()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TenSV FROM SinhVien", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            tenSV_SearchBox.DataSource = dt;
            tenSV_SearchBox.DisplayMember = "TenSV";
            tenSV_SearchBox.ValueMember = "TenSV";
        }

        private void maSV_SearchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter($"SELECT TenSV FROM SinhVien WHERE MaSV = '{maSV_SearchBox.SelectedValue}'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            tenSV_SearchBox.DataSource = dt;
            tenSV_SearchBox.DisplayMember = "TenSV";
            tenSV_SearchBox.ValueMember = "TenSV";   
        }
        private void tenSV_SearchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter($"SELECT MaSV FROM SinhVien WHERE TenSV = '{tenSV_SearchBox.SelectedValue}'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            maSV_SearchBox.DataSource = dt;
            maSV_SearchBox.DisplayMember = "MaSV";
            maSV_SearchBox.ValueMember = "MaSV";
        }
        private void SearchBox_Text_Form()
        {
            maSV_SearchBox.Text = "--Chọn mã SV--";
            tenSV_SearchBox.Text = "--Chọn tên SV--";
        }
        private void maSV_SearchBox_Click(object sender, EventArgs e)
        {
            UploadData_MaSV_Box();
            SearchBox_Text_Form();
        }

        private void tenSV_SearchBox_Click(object sender, EventArgs e)
        {
            UploadData_TenSV_Box();
            SearchBox_Text_Form();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            txtConsole_SF.Clear();
            txtConsole_SF.Refresh();
            SinhVienService svs = new SinhVienService(new SQL());
            MonHocService mhs = new MonHocService(new SQL());
            List<SinhVien> list_sv = svs.GetAll();
            List<MonHoc> list_mh = mhs.GetAll();
            switch (chooseFuncBox.SelectedIndex)
            {
                case 0:
                    {                                            
                        foreach (var item in list_sv)
                        {
                            if (item.MaSV == maSV_SearchBox.Text)
                            {
                                txtConsole_SF.AppendText(Environment.NewLine + Environment.NewLine);
                                svs.GetInfo(item);
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        foreach (var item in list_mh)
                        {
                            txtConsole_SF.AppendText(Environment.NewLine + Environment.NewLine);
                            mhs.GetInfo(item);
                        }

                        break;
                    }
                case 2:
                    {


                        break;
                    }
                default:
                    MessageBox.Show("Vui lòng chọn chức năng trước!", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }


        }
    }
}
