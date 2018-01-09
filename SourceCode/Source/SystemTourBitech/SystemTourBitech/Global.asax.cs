using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SystemTourBitech.App_Start;

namespace SystemTourBitech
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
    }
}
