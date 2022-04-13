using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interface.IServices
{
    public interface ISinhVienService
    {
        List<SinhVien> GetAll();
        SinhVien Create(string ma, string ten, string gioitinh, DateTime ns, string lop, string khoa);
        void GetInfo(SinhVien sv);
    }
}
