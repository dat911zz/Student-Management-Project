using StudentManagement.Data.Database;
using StudentManagement.Models;
using StudentManagement.Services;
using StudentManagement.Utilites;
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
        //Console.Write("1. Lay data tu CSDL");
        //    Console.SetCursorPosition(35, y++);

        //    Console.Write("2. Xuat danh sach sinh vien");
        //    Console.SetCursorPosition(35, y++);

        //    Console.Write("3. Xuat thong tin sinh vien");
        //    Console.SetCursorPosition(35, y++);

        //    Console.Write("4. Xem so mon hoc");
        //    Console.SetCursorPosition(35, y++);

        //    Console.Write("5. Xem so diem mon hoc");
        //    Console.SetCursorPosition(35, y++);

        //    Console.Write("6. Nhap diem sinh vien");
        //    Console.SetCursorPosition(35, y++);

        //    Console.Write("7. Xem ket qua hoc tap");
        //    Console.SetCursorPosition(42, y++);





        SinhVienService service_sv = new SinhVienService(new SQL());
        MonHocService service_mh = new MonHocService(new SQL());
        public List<SinhVien> list_sv;
        public List<MonHoc> list_mh;
        //bool flag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBoxWriter writer = new TextBoxWriter(txtConsole);
            Console.SetOut(writer);
            this.CenterToScreen();          
        }

        private void GetDataBtn_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
            DGVController dgvc = new DGVController();
            Manager mng = new Manager();
            list_sv = service_sv.GetAll();
            list_mh = service_mh.GetAll();



            mng.AutoWork(ref list_sv, list_mh);
            

            dgvc.BindDataGridView(dataGridView1);
            Console.WriteLine("Get data successfully!");
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(list_sv);
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "SearchForm")
                {
                    return;
                }
            }
            
            search.Show();

        }

        private void InputScoreBtn_Click(object sender, EventArgs e)
        {
            InputForm inputF = new InputForm(list_sv);
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "InputForm")
                {
                    return;
                }
            }

            inputF.Show();
        }
    }
}
