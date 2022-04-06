using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interface.IServices
{
    public interface IMonHocService
    {
        List<MonHoc> GetAll();
        MonHoc Create(string tenMH, int soTiet);
    }
}
