using System;

namespace StudentManagement.Models
{
    public class Diem
    {
        //==================================================================
        //Contructors
        public Diem() { }
        public Diem(double diemQT, double diemTP)
        {  
            this.diemQT = diemQT;
            this.diemTP = diemTP;
        }
        //==================================================================
        //Properties
        public double diemQT { get; set; }
        public double diemTP { get; set; }

    }
}
