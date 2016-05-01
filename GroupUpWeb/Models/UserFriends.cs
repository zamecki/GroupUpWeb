using GroupUpWeb.BusinessInterface;
using GroupUpWeb.Helpers.Business;
using GroupUpWeb.Helpers.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Models
{
    public class UserFriends : BusinessBase, IUserFriends
    {
        public int UserFriendsID { get; set; }
        public int UserID { get; set; }
        public int FriendID { get; set; }
        public virtual User User { get; set; }
        public virtual User Friend { get; set; }

        public UserFriends(IUnityOfWork uow) : base(uow)
        {

        }

        public void AddFriend(User user, User friend)
        {
            UserID = user.UserID;
            FriendID = friend.UserID;
            User = user;
            Friend = friend;
            Uow.UserFriends.Add(this);
        }
        public void Delete()
        {
            Uow.UserFriends.Delete(this);
        }        

        public List<User> GetFriendsList(User user)
        {
            List<User> userTFriends = Uow.UserFriends
                .Where(me => me.UserID == user.UserID)
                        .Select(obj => (User)obj.Friend)
                        .ToList();

            return userTFriends;
        }
    }
}