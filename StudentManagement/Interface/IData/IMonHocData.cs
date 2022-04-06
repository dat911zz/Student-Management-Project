using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interface.IData
{
    public interface IMonHocData
    {
        List<MonHoc> GetAllMH();
        void Add(SinhVien sv);
    }
}
