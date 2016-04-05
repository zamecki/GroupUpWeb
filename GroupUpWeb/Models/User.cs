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
        public string FbID { get; set; }
        public DateTime SinginDate { get; set; }
        public DateTime LastLogin { get; set; }
    }
}