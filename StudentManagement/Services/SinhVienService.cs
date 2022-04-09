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
        public List<SinhVien> GetAll()
        {
            return _svData.GetAllSV();
        }
        //Lấy thông tin Sinh Viên
        public void GetInfo(SinhVien sv)
        {           
            Console.Write($"\tMSSV: {sv.MaSV}" + Environment.NewLine +
                $"\tHọ tên: {sv.TenSV}" + Environment.NewLine +
                $"\tGiới tính: {sv.GioiTinh}" + Environment.NewLine +
                $"\tNgày sinh: {sv.NgaySinh.ToShortDateString()}" + Environment.NewLine +
                $"\tLớp: {sv.Lop}" + Environment.NewLine +
                $"\tKhóa: {sv.Khoa}" + Environment.NewLine
                );
        }
        //Auto DKHP cho Sinh Viên
        public void AutoImportCTHP(SinhVien sv, string tenMH, int soTiet, double diemQT, double diemTP)
        {
            KetQuaService kqs = new KetQuaService();
            sv.CTHP.DSMH.Add(new KetQua(new MonHoc(tenMH, soTiet), new Diem(diemQT, diemTP)));
            foreach (var item in sv.CTHP.DSMH)
            {
                kqs.GetInfoAll(item);
            }
        }
    }
}
