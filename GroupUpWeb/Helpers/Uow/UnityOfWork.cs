using GroupUpWeb.Helpers.EF;
using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GroupUpWeb.Helpers.Uow
{
    public class UnityOfWork : UnityOfWorkBase<GroupUpContext>, IUnityOfWork
    {
        public UnityOfWork(IRepositoryProvider repositoryProvider) : base(repositoryProvider) { }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }


        public IRepository<User> User
        {
            get { return GetStandardRepo<User>(); }
        }
        public IRepository<Group> Group
        {
            get { return GetStandardRepo<Group>(); }
        }
        public IRepository<GroupUser> GroupUser
        {
            get { return GetStandardRepo<GroupUser>(); }
        }
        public IRepository<UserFriends> UserUser
        {
            get { return GetStandardRepo<UserFriends>(); }
        }

    }
}