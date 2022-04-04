using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    /// <summary>
    /// Class for interact with MonHoc
    /// </summary>
    public class MonHocService
    {
        //Ghi dữ liệu của môn học
        public virtual void setData(MonHoc mh, string TenMH, int SoTiet)
        {
            mh.tenMH = TenMH;
            mh.soTiet = SoTiet;
        }
    }
}
