using System;
using Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Utils;

namespace Repository
{
    public class SessionGenerator
    {
        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();

        private SessionGenerator()
        {
        }

        public static SessionGenerator Instance { get; } = new SessionGenerator();

        public ISessionFactory GetSessionFactory()
        {
            return SessionFactory;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var configuration = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(builder => builder.Database("NoName")
                        //      .Server("www.holystream.tk")
                        .Server("192.168.0.43")
                        .Username("sa").Password("Overlord132")
                        ))
                    .Mappings(x => x.FluentMappings.AddFromAssembly(typeof (EntityMap<>).Assembly))
                    .ExposeConfiguration(
                        cfg => new SchemaUpdate(cfg).Execute(false, true));

                return configuration.BuildSessionFactory();
            }
            catch (Exception e)
            {
                Logger.AddToLog(e);
                return null;
            }
        }
    }
}