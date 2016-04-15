using GroupUpWeb.Helpers.EF;
using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GroupUpWeb.Helpers.Uow
{
    public interface IUnityOfWork : IDisposable
    {
        /// <summary>
        /// Salva as alterações do contexto de dados e realiza a pesistencia das informações no banco de dados.
        /// </summary>
        void Commit();

        /// <summary>
        /// Realiza a persistência dos dados de forma asincrona.
        /// </summary>
        Task<int> CommitAsync();
        IRepository<User> User { get; }
        IRepository<Group> Group { get; }
        IRepository<GroupUser> GroupUser { get; }
        IRepository<UserUser> UserUser { get; }


    }
}