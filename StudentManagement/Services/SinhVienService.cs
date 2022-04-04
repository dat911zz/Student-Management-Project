using StudentManagement.Interface.IData;
using StudentManagement.Interface.IServices;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    public class SinhVienService : ISinhVienService
    {
        private ISinhVienData _svData;
        public SinhVienService(ISinhVienData svData)
        {
            _svData = svData;
        }
        public SinhVien Create(string ma, string ten, string gioitinh, DateTime ns, string lop, string khoa)
        {
            return new SinhVien(ma, ten, gioitinh, ns, lop, khoa);
        }
        public List<SinhVien> GetAllSV()
        {
            return _svData.GetAllSV();
        }
        public List<MonHoc> GetAllMH()
        {
            return _svData.GetAllMH();
        }
    }
}
