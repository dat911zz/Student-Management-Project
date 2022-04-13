using Castle.Windsor;
using StudentManagement.Data.Database;
using StudentManagement.Installer;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    public class KetQuaService
    {
        WindsorContainer container;

        public KetQuaService()
        {
            container = new WindsorContainer();
            container.Install(new ServicesInstaller());
            container.Dispose();
        }
        public void GetInfoAll(KetQua kq)
        {
            GetInfoMonHoc(kq);
            GetInfoDiem(kq);         
        }
        public void GetInfoMonHoc(KetQua kq)
        {
            MonHocService mhs = container.Resolve<MonHocService>();
            mhs.GetInfo(kq.CTMH);
        }
        public void GetInfoDiem(KetQua kq)
        {
            DiemService dsv = container.Resolve<DiemService>();
            dsv.GetInfo(kq.CTDiem);
        }
    }
}
