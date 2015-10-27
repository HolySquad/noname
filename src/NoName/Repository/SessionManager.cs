using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Repository
{
    public class SessionManager
    {
        private static readonly SessionManager _sessionGenerator = new SessionManager();
        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();

        private SessionManager()
        {
        }

        public static SessionManager Instance
        {
            get { return _sessionGenerator; }
        }

        public ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(builder => builder.Database("NoName")
                    .Server("92.115.133.188").Username("sa").Password("Overlord132")
                    ));
            //.Mappings(x=>x.FluentMappings.AddFromAssembly(typeof(PersMap).Assembly))
            //.ExposeConfiguration(
            //cfg => new SchemaUpdate(cfg).Execute(true,true));

            return configuration.BuildSessionFactory();
        }
    }
}