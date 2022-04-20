using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Map
{
    public class SinhVienMap : ClassMap<SinhVien>
    {
        public SinhVienMap()
        {
            Id(x => x.MaSV);
            Map(x => x.TenSV);
            Map(x => x.GioiTinh);
            Map(x => x.NgaySinh);
            Map(x => x.Lop);
            Map(x => x.Khoa);

            Table("SinhVien");
        }
    }
}
