using Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Repository
{
    public class SessionGenerator
    {
        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();
        private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();

        private SessionGenerator()
        {
        }

        public static SessionGenerator Instance
        {
            get { return _sessionGenerator; }
        }

        public ISessionFactory GetSessionFactory()
        {
            return SessionFactory;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(builder => builder.Database("NoName")
                        .Server("www.holystream.tk")
                        .Username("holy").Password("stream")
                    ))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof (EntityMap<>).Assembly))
                .ExposeConfiguration(
                    cfg => new SchemaUpdate(cfg).Execute(false, true));

            return configuration.BuildSessionFactory();
        }
    }
}