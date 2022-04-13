using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using StudentManagement.Data.Database;
using StudentManagement.Interface.IData;
using StudentManagement.Interface.IServices;
using StudentManagement.Models;
using StudentManagement.Services;
using StudentManagement.Utilites;
using StudentManagement.View;

namespace StudentManagement.Installer
{
    public class ServicesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Hàm thiết lập tùy chỉnh để đăng ký các Components vào DI container
        /// </summary>
        void IWindsorInstaller.Install(IWindsorContainer container, IConfigurationStore store)
        {
            //Manager only
            container.Register(
                Component
                    .For<Manager>()
                    .LifestyleTransient());
            //Services only
            container.Register(
                Component
                    .For<IMonHocData, ISinhVienData, ICTHocPhanData>()
                    .ImplementedBy<Data.ORM.Dapper>()
                    .DependsOn(Dependency.OnValue("connectionString", DatabaseHelper.GenerateConnectionString("","SinhVien","test01","1234")))
                    );
            container.Register(
                Component
                    .For<IMonHocData, ISinhVienData, ICTHocPhanData>()
                    .ImplementedBy<SQL>()
                    .LifestyleTransient());
            container.Register(
                Component
                    .For<IMonHocData, ISinhVienData, ICTHocPhanData>()
                    .ImplementedBy<XML>()
                    .LifestyleTransient());


            container.Register(
                Component
                    .For<ISinhVienService>()
                    .ImplementedBy<SinhVienService>()
                    .LifestyleTransient());           
            container.Register(
                Component
                    .For<IMonHocService>()
                    .ImplementedBy<MonHocService>()
                    .LifestyleTransient());
            container.Register(
                Component
                    .For<DiemService>()
                    .LifestyleTransient());
            container.Register(
                Component
                    .For<KetQuaService>()
                    .LifestyleTransient());

            //Views only
            container.Register(
                Component
                    .For<SearchBoxController>()
                    .LifestyleTransient());
            container.Register(
                Component
                    .For<DGVController>()
                    .LifestyleTransient());

        }
    }
}
