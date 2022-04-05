using StudentManagement.Data.Database;
using StudentManagement.Models;
using StudentManagement.Services;
using StudentManagement.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        SinhVienService service = new SinhVienService(new SQL());
        public List<SinhVien> list_sv;
        public List<MonHoc> list_mh;

        public Form1()
        {
            InitializeComponent();
            list_sv = service.GetAllSV();
            list_mh = service.GetAllMH();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBoxWriter writer = new TextBoxWriter(txtConsole);
            Console.SetOut(writer);            
        }

        private void GetDataBtn_Click(object sender, EventArgs e)
        {
            DGVController dgvc = new DGVController();
            dgvc.BindDataGridView(dataGridView1);
            Console.WriteLine("Get data successfully!");
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {

        }

        private void InputScoreBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
