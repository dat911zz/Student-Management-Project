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
    /// <summary>
    /// Class for interact with MonHoc
    /// </summary>
    public class MonHocService : IMonHocService
    {
        private IMonHocData _mhData;
        public MonHocService(IMonHocData mhData)
        {
            _mhData = mhData;
        }

        //Ghi dữ liệu của môn học
        public virtual void setData(MonHoc mh, string TenMH, int SoTiet)
        {
            mh.tenMH = TenMH;
            mh.soTiet = SoTiet;
        }
        public MonHoc Create(string tenMH, int soTiet)
        {
            return new MonHoc(tenMH, soTiet);
        }
        public List<MonHoc> GetAll()
        {
            return _mhData.GetAllMH();
        }

        //Lấy thông tin môn học
        public virtual void GetInfo(MonHoc mh)
        {
            Console.Write($"\tTên môn: {mh.tenMH}" + Environment.NewLine +
                $"\tSố tiết: {mh.soTiet}" + Environment.NewLine            
                );
        }
        
    }
}
