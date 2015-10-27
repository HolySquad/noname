using Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Repository
{
    public class SessionManager: ISessionManager
    {
        private readonly ISession _session;
        private readonly ISessionFactory _sessionFactory = SessionGenerator.Instance.GetSessionFactory();

        public SessionManager()
        {
            _session = _sessionFactory.OpenSession();
        }

        public ISession GetSession()
        {
            return _session;
        }
    }
}