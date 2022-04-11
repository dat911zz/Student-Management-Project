using StudentManagement.Data.Database;
using StudentManagement.Models;
using StudentManagement.Services;
using StudentManagement.Utilites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.View
{
    public partial class InputForm : Form
    {
        SqlConnection conn = new SqlConnection(new SQL().GetConnection("", "SinhVien", "test01", "1234").ConnectionString);
        SearchBoxController boxC = new SearchBoxController();
        List<SinhVien> list_sv { get; set; }
        public InputForm(List<SinhVien> list_sv)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.list_sv = list_sv;
        }

        private void diemQTBox_ValueChanged(object sender, EventArgs e)
        {
            CheckExceptionOfDiem(diemQTBox, errorProvider1);
        }
        private void diemTPBox_ValueChanged(object sender, EventArgs e)
        {
            CheckExceptionOfDiem(diemTPBox, errorProvider1);
        }
        private void CheckExceptionOfDiem(NumericUpDown b, ErrorProvider e)
        {           
            if (b.Value < 0 || b.Value > 10)
            {
                e.SetError(b, "Chỉ nhập điểm trong khoảng 0 -> 10 thôi nhé !");
            }
            else
            {
                e.SetError(b, "");
            }
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
        private void InputBtn_Click(object sender, EventArgs e)
        {
            //Checking exceptions
            if (list_sv == null)
            {
                MessageBox.Show("Chưa tải dữ liệu lên hệ thống!", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (diemQTBox.Value > 10 || diemTPBox.Value > 10)
            {
                MessageBox.Show("Điểm nhập vô không hợp lệ!", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show($"Bạn có muốn nhập điểm vào môn {MonHocBox.Text} chứ?", "Hệ Thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            //Doing func
            list_sv.ForEach(x =>
            {
                if (x.MaSV == maSV_SearchBox.Text)
                {
                    x.CTHP.DSMH.ForEach(y =>
                    {
                        if (y.CTMH.tenMH == MonHocBox.Text)
                        {
                            DiemService ds = new DiemService();
                            ds.setDiem(y.CTDiem, double.Parse(diemQTBox.Value.ToString()), double.Parse(diemTPBox.Value.ToString()));
                        }
                    });
                    BindDataToDGV();
                    ResultPanel.Refresh();
                    return;
                }
            });
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (list_sv == null)
            {
                MessageBox.Show("Chưa tải dữ liệu lên hệ thống!", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            BindDataToDGV();           
        }
        private void FillMonHocBox()
        {
            try
            {
                DataTable dtDataFromDB = GetDataFromDatabaseinDataTable();
                MonHocBox.DataSource = dtDataFromDB;
                MonHocBox.ValueMember = "Tên MH";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void BindDataToDGV()
        {
            Manager mng = new Manager();
            DataTable table = new DataTable();
            DataGridView grid = new DataGridView();

            foreach (var item in list_sv)
            {
                if (item.TenSV == tenSV_SearchBox.Text)
                {
                    //Create cols and fill data in DGV
                    ResultPanel.Controls.Add(grid);
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
                    MonHocBox.Enabled = true;
                    FillMonHocBox();
                    return;
                }
            }
            MessageBox.Show("Không tìm thấy kết quả!", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DataTable GetDataFromDatabaseinDataTable()
        {
            Manager mng = new Manager();
            DataTable dt = new DataTable();
            foreach (var item in list_sv)
            {
                if (item.TenSV == tenSV_SearchBox.Text)
                {
                    return mng.UploadMonHocSVIntoDGV(item);
                }
            }
            return null;
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            MonHocBox.Enabled = false;
        }
    }
}
