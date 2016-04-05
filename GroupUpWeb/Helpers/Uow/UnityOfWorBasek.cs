using GroupUpWeb.Helpers.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Helpers.Uow
{
    public abstract class UnityOfWorkBase<T> : IDisposable
                where T : DbContext, new()
    {
        public UnityOfWorkBase(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        protected void CreateDbContext()
        {
            DbContext = new T();

            // Desabilitar a geração de proxies dinãmicos para evitar problemas com serialização
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Usar eager loading, aumentar performance nas consultas e evitar problemas de serialização
            DbContext.Configuration.LazyLoadingEnabled = false;

            // A validação dos dados será realizada pelas camada de negócio
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        protected IRepository<TEntity> GetStandardRepo<TEntity>() where TEntity : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<TEntity>();
        }
        protected TEntity GetRepo<TEntity>() where TEntity : class
        {
            return RepositoryProvider.GetRepository<TEntity>();
        }

        protected T DbContext { get; set; }


        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}