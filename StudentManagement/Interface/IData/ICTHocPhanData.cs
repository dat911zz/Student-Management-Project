using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interface.IData
{
    public interface ICTHocPhanData
    {
        void GetAllCTHP(ref List<SinhVien> list_sv, List<MonHoc> list_mh);
        void Add(CTHocPhan cthp);
    }
}
