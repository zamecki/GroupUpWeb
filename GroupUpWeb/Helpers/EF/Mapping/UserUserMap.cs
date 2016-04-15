using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Helpers.EF.Mapping
{
    public class UserUserMap : EntityTypeConfiguration<UserUser>
    {
        public UserUserMap()
        {
            this.HasKey(t => t.UserUserID);

            this.ToTable("TB_UserUser", "dbo");

            this.Property(t => t.UserUserID).HasColumnName("Id");

            this.HasRequired(t => t.FirstUser)
                .WithMany()
                .HasForeignKey(t => t.FirstUserId)
                .WillCascadeOnDelete(false);

            this.HasRequired(t => t.SecondUser)
                .WithMany()
                .HasForeignKey(t => t.SecondUserId)
                .WillCascadeOnDelete(false);
        }
    }
}