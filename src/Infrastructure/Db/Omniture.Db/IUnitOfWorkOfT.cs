using System;
using Omniture.Db.Context;

namespace Omniture.Db
{
    public interface IUnitOfWork<TContext> : IUnitOfWork, IDisposable
        where TContext : IContext
    {
        TContext Context { get; }
    }
}
