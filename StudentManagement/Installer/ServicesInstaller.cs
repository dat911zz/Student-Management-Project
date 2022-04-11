using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using StudentManagement.Data.Database;
using StudentManagement.Interface.IData;
using StudentManagement.Interface.IServices;
using StudentManagement.Models;
using StudentManagement.Services;
using StudentManagement.Utilites;

namespace StudentManagement.Installer
{
    public class ServicesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Hàm thiết lập tùy chỉnh để đăng ký các Components vào DI container
        /// </summary>
        void IWindsorInstaller.Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<SinhVien>()
                    .LifestyleTransient());
            container.Register(
                Component
                    .For<MonHoc>()
                    .LifestyleTransient());
            container.Register(
                Component
                    .For<Manager>()
                    .LifestyleTransient());

            container.Register(
                Component
                    .For<IMonHocData, ISinhVienData>()
                    .ImplementedBy<SQL>()
                    .LifestyleTransient());
            container.Register(
                Component
                    .For<IMonHocData, ISinhVienData>()
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
        }
    }
}
