using System;

namespace StudentManagement.Models
{
    public class KetQua
    {
        public KetQua(MonHoc cTMH, Diem cTDiem)
        {
            CTMH = cTMH;
            CTDiem = cTDiem;
        }

        public virtual MonHoc CTMH { get; set; }
        public virtual Diem CTDiem { get; set; }
    }
}
