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
using StudentManagement.Utilites;

namespace StudentManagement.View
{
    public partial class SearchForm : Form
    {
        SqlConnection conn = new SqlConnection(new SQL().GetConnection("", "SinhVien", "test01", "1234").ConnectionString);
        SearchBoxController boxC = new SearchBoxController();
        List<SinhVien> list_sv { get; set; }      

        public SearchForm(List<SinhVien> list_sv)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.list_sv = list_sv;
        }     
        private void SearchForm_Load(object sender, EventArgs e)
        {
            TextBoxWriter writer = new TextBoxWriter(txtConsole_SF);
            Console.SetOut(writer);
            boxC.SearchBox_Text_Form(maSV_SearchBox, tenSV_SearchBox);
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
        private void maSV_SearchBox_Click(object sender, EventArgs e)
        {
            boxC.UploadData_MaSV_Box(maSV_SearchBox, conn);
            maSV_SearchBox.Text = "";
            tenSV_SearchBox.Text = "--Chọn tên SV--";
        }
        private void tenSV_SearchBox_Click(object sender, EventArgs e)
        {
            boxC.UploadData_TenSV_Box(tenSV_SearchBox, conn);
            maSV_SearchBox.Text = "--Chọn mã SV--";
            tenSV_SearchBox.Text = "";
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            txtConsole_SF.Clear();
            txtConsole_SF.Refresh();
            SinhVienService svs = new SinhVienService(new SQL());
            MonHocService mhs = new MonHocService(new SQL());

            if (list_sv == null)
            {
                MessageBox.Show("Chưa tải dữ liệu lên hệ thống!", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            switch (chooseFuncBox.SelectedIndex)
            {
                case 0:
                    {
                        //--Chọn mã SV--
                        if (maSV_SearchBox.Text == "--Chọn mã SV--" || tenSV_SearchBox.Text == "--Chọn tên SV--")
                        {
                            ShowMessageNotFound();
                        }
                        txtConsole_SF.BringToFront();
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
                        Manager mng = new Manager();
                        DataTable table = new DataTable();
                        DataGridView grid = new DataGridView();

                        foreach (var item in list_sv)
                        {
                            if (item.TenSV == tenSV_SearchBox.Text)
                            {
                                //Create cols and fill data in DGV
                                panel2.Controls.Add(grid);
                                grid.BringToFront();
                                grid.Width = 700;
                                grid.Height = 200;
                                grid.DataSource = mng.UploadMonHocSVIntoDGV(item);
                                grid.Columns[0].Width = 50;//Chỉnh độ rộng của cột STT
                                grid.Columns[2].Width = 50;//Chỉnh độ rộng cột số tiết
                                return;
                            }
                        }
                        ShowMessageNotFound();
                        break;
                    }
                case 2:
                    {
                        Manager mng = new Manager();
                        DataTable table = new DataTable();
                        DataGridView grid = new DataGridView();

                        foreach (var item in list_sv)
                        {
                            if (item.TenSV == tenSV_SearchBox.Text)
                            {
                                //Create cols and fill data in DGV
                                panel2.Controls.Add(grid);
                                grid.BringToFront();
                                grid.Width = 700;
                                grid.Height = 200;
                                grid.DataSource = mng.UploadDiemSVIntoDGV(item);

                                for (int i = 0; i < item.CTHP.DSMH.Count; i++)
                                {
                                    if (int.Parse(grid.Rows[i].Cells[3].Value.ToString()) < 5)
                                    {
                                        grid.Rows[i].Cells[3].Style.BackColor = Color.Red;
                                    }
                                    if (int.Parse(grid.Rows[i].Cells[4].Value.ToString()) < 5)
                                    {
                                        grid.Rows[i].Cells[4].Style.BackColor = Color.Red;
                                    }
                                    
                                }

                                grid.Columns[0].Width = 50;//Chỉnh độ rộng của cột STT
                                grid.Columns[2].Width = 50;//Chỉnh độ rộng cột số tiết
                                return;
                            }
                        }
                        ShowMessageNotFound();
                        break;
                    }
                default:
                    MessageBox.Show("Vui lòng chọn chức năng trước!", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        public void ShowMessageNotFound()
        {
            MessageBox.Show("Không tìm thấy kết quả!", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
