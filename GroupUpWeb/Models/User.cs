using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime SinginDate { get; set; }
        public DateTime LastLogin { get; set; }
    }
}