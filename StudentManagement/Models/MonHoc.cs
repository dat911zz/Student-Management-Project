using System;

namespace StudentManagement.Models
{
    public class MonHoc
    {
        //==================================================================
        //Contructors
        public MonHoc() { }
        public MonHoc(MonHoc mh)
        {
            this.tenMH = mh.tenMH;
            this.soTiet = mh.soTiet;
        }
        public MonHoc(string tenMH, int soTiet)
        {
            this.tenMH = tenMH;
            this.soTiet = soTiet;
        }
        //==================================================================
        //Properties
        public virtual string tenMH { get; set; }
        public virtual int soTiet { get; set; }
    }
}
