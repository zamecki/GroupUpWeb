using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Helpers.EF.Mapping
{
    public class UserFriendsMap : EntityTypeConfiguration<UserFriends>
    {
        public UserFriendsMap()
        {
            this.HasKey(t => t.UserFriendsID);

            this.ToTable("TB_UserFriends", "dbo");

            this.Property(t => t.UserFriendsID).HasColumnName("Id");

            this.HasRequired(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserID)
                .WillCascadeOnDelete(false);

            this.HasRequired(t => t.Friend)
                .WithMany()
                .HasForeignKey(t => t.FriendID)
                .WillCascadeOnDelete(false);
        }
    }
}