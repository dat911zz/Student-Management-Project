using Castle.Windsor;
using Newtonsoft.Json;
using StudentManagement.Data.Database;
using StudentManagement.Data.ORM;
using StudentManagement.Installer;
using StudentManagement.Interface.IServices;
using StudentManagement.Models;
using StudentManagement.Services;
using StudentManagement.Utilites;
using StudentManagement.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        //Áp dụng DI
        //SinhVienService service_sv = new SinhVienService(new SQL());
        //MonHocService service_mh = new MonHocService(new SQL());

        //Áp dụng DI container
        WindsorContainer container;
        ISinhVienService service_sv;
        IMonHocService service_mh;

        public List<SinhVien> list_sv;
        public List<MonHoc> list_mh;

        public Form1()
        {
            InitializeComponent();

            //Bắt đầu chương trình
            container = new WindsorContainer();
            //Thêm và cấu hình tất cả các thành phần bằng WindsorInstaller
            container.Install(new ServicesInstaller());
            //Khởi tạo và cấu hình thành phần gốc và tất cả các phụ thuộc liên quan đến nó
            service_sv = container.Resolve<ISinhVienService>();
            service_mh = container.Resolve<IMonHocService>();
            //Dọn dẹp
            container.Dispose();
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
            Manager mng = container.Resolve<Manager>();
            list_sv = service_sv.GetAll();
            list_mh = service_mh.GetAll();

            mng.AutoWork(ref list_sv, list_mh);          
            dgvc.BindDataGridView(dataGridView1);
            Console.WriteLine("Get data successfully!");

            //var a = new NHibernate_();
            //a.GetDataSV(list_sv);

            
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

        private void exportFileBtn_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
            string jsonString = JsonConvert.SerializeObject(list_sv);
            var hash = Math.Abs(DateTime.Now.GetHashCode());
            string fname = $"fileData_{hash}.json";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Directory.CreateDirectory(path+ "\\Data\\");
            string flocate = path + "\\Data\\" + fname;
            File.WriteAllText(flocate, jsonString);
            Console.WriteLine($"File has been saved at: {flocate}");
        }
    }
}
