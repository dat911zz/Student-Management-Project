using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    /// <summary>
    /// Class to interact with Diem 
    /// </summary>
    public class DiemService
    {     
        //Ghi điểm môn học (sinh viên)
        public virtual void setDiem(Diem kq, double DiemQT, double DiemTP)
        {
            if ((DiemQT < 0 || DiemQT > 10) && (DiemTP < 0 || DiemTP > 10))
            {
                throw new Exception("Lỗi gòi: Nhập vượt ngoài phạm vi cho phép (0-10)");
            }
            kq.diemQT = DiemQT;
            kq.diemTP = DiemTP;
        }
        //Tính điểm tổng kết
        public virtual double diemTongKet(Diem d)
        {
            return (d.diemQT + d.diemTP) / 2;
        }
        //Kiểm tra sinh viên đậu hay rớt môn đã chọn
        public virtual bool isPass(Diem d)
        {
            return diemTongKet(d) >= 4;
        }
        //Lấy thông tin điểm
        public virtual void GetInfo(Diem d)
        {
            Console.Write($"\tĐiểm thành phần: {d.diemTP}" + Environment.NewLine +
                $"\tĐiểm qua trình: {d.diemQT}" + Environment.NewLine
                );
        }
    }
}
