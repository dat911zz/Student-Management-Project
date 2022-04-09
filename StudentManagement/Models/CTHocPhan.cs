using System.Collections.Generic;

namespace StudentManagement.Models
{
    public class CTHocPhan
    {
        public CTHocPhan(List<KetQua> dSMH)
        {
            DSMH = dSMH;
        }
        public CTHocPhan()
        {
            DSMH = new List<KetQua>();
        }
        public virtual List<KetQua> DSMH { get; set; }
    }
}
