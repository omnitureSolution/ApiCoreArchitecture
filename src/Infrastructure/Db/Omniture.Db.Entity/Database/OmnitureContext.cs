using Omniture.Db.Context;
using Omniture.Db.Entity.Notification;
using Omniture.NotificationService.Context;
//using Omniture.Db.Entity.Utilities;
using Omniture.Shared.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Omniture.Db.Entity.Database
{
    public class OmnitureContext : OmnitureBaseContext<OmnitureContext>, IOmnitureContext, OmnitureNotificationContext
    {
        public OmnitureContext(DbContextOptions<OmnitureContext> options, IUserInfo userInfo)
          : base(options, userInfo)
        {
        }


        #region notification
        public DbSet<EmailLog> EmailLog { get; set; }
        public DbSet<Notification.Notification> Notification { get; set; }
        public DbSet<SMTPConfiguration> SMTPConfiguration { get; set; }
        public DbSet<NotificationQueue> NotificationQueue { get; set; }
        public DbSet<Scheduler> Scheduler { get; set; }
        public DbSet<ScheduleHistory> ScheduleHistory { get; set; }
        public DbSet<MessageTemplate> MessageTemplate { get; set; }
        public DbSet<User> User { get; set; }
        #endregion

        #region Utilities
        //public virtual DbSet<NotificationQueue> NotificationQueue { get; set; }
        #endregion

        #region Logger setup
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Development", StringComparison.OrdinalIgnoreCase))
                optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }


        public static readonly ILoggerFactory MyLoggerFactory
                = LoggerFactory.Create(builder =>
                {
                    builder
                        .AddFilter((category, level) =>
                            category == DbLoggerCategory.Database.Command.Name
                            && level == Microsoft.Extensions.Logging.LogLevel.Information)
                        .AddConsole();
                });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var type in GetEntityTypes())
            {
                var method = SetGlobalQueryMethod.MakeGenericMethod(type);
                method.Invoke(this, new object[] { modelBuilder });
            }

            base.OnModelCreating(modelBuilder);
        }

        private static readonly MethodInfo SetGlobalQueryMethod = typeof(OmnitureContext).
                                    GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                    .Single(t => t.IsGenericMethod && t.Name == "SetDeletedFilter");

        public void SetDeletedFilter<T>(ModelBuilder builder) where T : AuditEntity
        {
            builder.Entity<T>().HasQueryFilter(e => e.DeletedDate == null);
        }
        private static IList<Type> _entityTypeCache;
        private static IList<Type> GetEntityTypes()
        {
            if (_entityTypeCache != null)
            {
                return _entityTypeCache.ToList();
            }
            _entityTypeCache = (from a in GetReferencingAssemblies()
                                from t in a.DefinedTypes
                                where t.BaseType == typeof(AuditEntity)
                                select t.AsType()).ToList();
            return _entityTypeCache;
        }
        private static IEnumerable<Assembly> GetReferencingAssemblies()
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                try
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
                catch (FileNotFoundException)
                { }
            }
            return assemblies;
        }
        #endregion
    }
}
