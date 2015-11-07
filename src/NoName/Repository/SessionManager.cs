using NHibernate;
using Utils;

namespace Repository
{
    public class SessionManager : ISessionManager
    {
        private readonly ISession _session;
        private readonly ISessionFactory _sessionFactory = SessionGenerator.Instance.GetSessionFactory();

        public SessionManager()
        {
            if (_sessionFactory != null)
            {
                _session = _sessionFactory.OpenSession();
            }
            else Logger.AddToLog("Failed to open session");
        }

        public ISession GetSession()
        {
            return _session;
        }
    }
}