﻿using Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;

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
            try
            {

                var configuration = Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2012.ConnectionString(builder => builder.Database("NoName")
                .Server("www.holystream.tk")
                  //  .Server("192.168.0.43")
                  .Username("sa").Password("Overlord132")
                  ))
              .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(EntityMap<>).Assembly))
              .ExposeConfiguration(
                  cfg => new SchemaUpdate(cfg).Execute(false, true));

                return configuration.BuildSessionFactory();
            }
            catch (Exception e)
            {
                Utils.Logger.AddToLog(e);
                return null;
            }
          
          
        }
    }
}