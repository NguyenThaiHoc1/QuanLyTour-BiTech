[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SystemTourBitech.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SystemTourBitech.App_Start.NinjectWebCommon), "Stop")]

namespace SystemTourBitech.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using Core.Services;
    using Services;

    using Core.Model;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IKhachHangServices>().To<KhachHangService>();

            kernel.Bind<INhanVienService>().To<NhanVienService>();

            kernel.Bind<ILoaiNhanVien>().To<LoaiNhanVienServies>();

            kernel.Bind<ITourPhuongTien>().To<TourPhuongTienServices>();

            kernel.Bind<ITourService>().To<TourServices>();

            kernel.Bind<IHDDangKyService>().To<HDDangKyService>();

            kernel.Bind<IHoaDonService>().To<HoaDonService>();

            kernel.Bind<IFactThongKeService>().To<FactThongKeService>();

            kernel.Bind<IChiTietKhachHangTourService>().To<ChiTietKhachHangTourService>();
        }        
    }
}
