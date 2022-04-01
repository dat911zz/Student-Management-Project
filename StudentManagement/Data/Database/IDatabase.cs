using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Database
{
    /// <summary>
    /// Database Interface for using another type of database in future
    /// </summary>
    public interface IDataBase
    {

        void Extract(ref List<SinhVien> list_SV, ref List<MonHoc> list_MH);

    }
}
