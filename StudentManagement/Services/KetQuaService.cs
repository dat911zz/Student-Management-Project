using StudentManagement.Data.Database;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    public class KetQuaService
    {
        public void GetInfoAll(KetQua kq)
        {
            GetInfoMonHoc(kq);
            GetInfoDiem(kq);         
        }
        public void GetInfoMonHoc(KetQua kq)
        {
            MonHocService mhs = new MonHocService(new SQL());
            mhs.GetInfo(kq.CTMH);
        }
        public void GetInfoDiem(KetQua kq)
        {
            DiemService dsv = new DiemService();
            dsv.GetInfo(kq.CTDiem);
        }
    }
}
