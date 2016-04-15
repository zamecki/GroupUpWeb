using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Models
{
    public class UserUser
    {
        public int UserUserID { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public virtual User FirstUser { get; set; }
        public virtual User SecondUser { get; set; }
    }
}