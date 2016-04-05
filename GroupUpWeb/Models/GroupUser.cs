using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Models
{
    public class GroupUser
    {
        public int GroupUserID { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}