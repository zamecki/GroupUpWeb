using GroupUpWeb.Helpers.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GroupUpWeb.Helpers.Business
{
    public abstract class BusinessBase : ICommitable
    {

        protected IUnityOfWork Uow { get; private set; }

        public BusinessBase(IUnityOfWork uow)
        {
            Uow = uow;
        }

        public void Commit()
        {
            Uow.Commit();
        }

        public Task<int> CommitAsync()
        {
            return Uow.CommitAsync();
        }

        protected void ThrowBusinessException(string exception)
        {
            throw new BusinessException(exception);
        }

        protected void ThrowBusinessException(string exception, Exception innerException)
        {
            throw new BusinessException(exception, innerException);
        }
    }
}