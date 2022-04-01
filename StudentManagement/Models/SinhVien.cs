using System;

namespace StudentManagement.Models
{
    public class SinhVien
    {
        //==================================================================
        //Properties
        public virtual string MaSV { get; set; }
        public virtual string TenSV { get; set; }
        public virtual string GioiTinh { get; set; }
        public virtual DateTime NgaySinh { get; set; }
        public virtual string Lop { get; set; }
        public virtual string Khoa { get; set; }
        

        //==================================================================
        //Contructors
        public SinhVien(string ma, string ten, string gioitinh, DateTime ngaysinh, string lop, string khoa)
        {
            this.MaSV = ma;
            this.TenSV = ten;
            this.GioiTinh = gioitinh;
            this.NgaySinh = ngaysinh;
            this.Lop = lop;
            this.Khoa = khoa;
        }
    }
}
