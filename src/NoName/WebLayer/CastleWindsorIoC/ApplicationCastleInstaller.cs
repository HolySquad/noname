using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Repository;
using Repository.Interfaces;

namespace WebLayer.CastleWindsorIoC
{
    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
          container.Register(
                Component.For(typeof (ISessionManager))
                    .ImplementedBy(typeof (SessionManager))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IMediaFileRepository))
                    .ImplementedBy(typeof(MediaFileRepository))
                    .LifestylePerWebRequest());

            var contollers =
                Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof (Controller)).ToList();

            foreach (var controller in contollers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }
        }
    }
}