using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpTime { get; set; }

    }
}