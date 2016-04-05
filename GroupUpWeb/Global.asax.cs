using GroupUpWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace GroupUpWeb
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        string connString = ConfigurationManager.ConnectionStrings["GroupUpConnectionString"].ConnectionString;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
