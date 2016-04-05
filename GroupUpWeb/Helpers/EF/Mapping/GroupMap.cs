using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Helpers.EF.Mapping
{
    public class GroupMap : EntityTypeConfiguration<Group>
    {
        public GroupMap()
        {
            this.HasKey(t => t.GroupID);

            this.ToTable("TB_Group", "dbo");

            this.Property(t => t.GroupID).HasColumnName("iId");
                
            this.Property(t => t.Description).HasColumnName("description").HasMaxLength(250).IsOptional();

            this.Property(t => t.CreatedTime).HasColumnName("creation_date").IsRequired();

            this.Property(t => t.LastUpTime).HasColumnName("last_update_date").IsOptional();

            this.Property(t => t.Title).HasColumnName("title").HasMaxLength(150).IsRequired();

            this.Property(t => t.OwnerId).HasColumnName("owner_id");

            this.HasRequired(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId);
        }
    }
}