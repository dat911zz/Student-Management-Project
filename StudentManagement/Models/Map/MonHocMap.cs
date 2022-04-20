using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Map
{
    public class MonHocMap : ClassMap<MonHoc>
    {
        public MonHocMap()
        {
            Id(x => x.tenMH);
            Map(x => x.soTiet);

            Table("MonHoc");
        }
    }
}
