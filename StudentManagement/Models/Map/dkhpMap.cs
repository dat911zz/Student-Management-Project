using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Map
{
    public class dkhpMap : ClassMap<DKHP>
    {
        public dkhpMap()
        {
            Id(x => x.STT);
            Map(x => x.MaSV);
            Map(x => x.MH1);
            Map(x => x.MH2);
            Map(x => x.MH3);
            Map(x => x.MH4);
            Map(x => x.MH5);
            Map(x => x.MH6);
            Map(x => x.MH7);
            Map(x => x.MH8);
            Map(x => x.MH9);
            Map(x => x.MH10);

            Table("dkhp");
        }
    }
}
