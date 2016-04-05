using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GroupUpWeb.Helpers.Business
{
    public interface ICommitable
    {
        void Commit();

        Task<int> CommitAsync();
    }
}