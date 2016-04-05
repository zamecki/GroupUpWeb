﻿using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Helpers.EF.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(t => t.UserID);

            this.ToTable("TB_User", "dbo");

            this.Property(t => t.UserID).HasColumnName("Id");

            this.Property(t => t.FbID).HasColumnName("fbid").HasMaxLength(150).IsRequired();

            this.Property(t => t.SinginDate).HasColumnName("sing_date").IsRequired();

            this.Property(t => t.LastLogin).HasColumnName("last_login_date");            
        }
    }
}