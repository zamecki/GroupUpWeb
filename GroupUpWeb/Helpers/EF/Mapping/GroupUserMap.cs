using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Helpers.EF.Mapping
{
    public class GroupUserMap : EntityTypeConfiguration<GroupUser>
    {
        public GroupUserMap()
        {
            this.HasKey(t => t.GroupUserID);

            this.ToTable("TB_GroupUser", "dbo");

            this.Property(t => t.GroupUserID).HasColumnName("Id");

            this.HasRequired(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId);

            this.HasRequired(t => t.Group)
                .WithMany()
                .HasForeignKey(t => t.GroupId);
        }
    }
}