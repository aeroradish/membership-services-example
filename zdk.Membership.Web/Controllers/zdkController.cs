using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zdk.Membership.Web.DALs;
using zdk.Membership.Web.Models;

namespace zdk.Membership.Web.Controllers
{
    [Authorize]
    public class zdkController : Controller
    {
        //
        // GET: /zdk/

        zdkMembershipProvider mp = new zdkMembershipProvider();

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            string ctrller = "";
            base.Initialize(requestContext);

            zdkUser = (zdkUserModel)mp.GetUser(requestContext.HttpContext.User.Identity.Name, true);
            ctrller = requestContext.HttpContext.Request.RequestContext.RouteData.Values["Controller"].ToString();

            //check for condition -- restricted to appropriate area
            switch (zdkUser.User.UserName)
            {
                case "fred":
                    if ("Lock" != ctrller)
                    {
                        requestContext.HttpContext.Response.Redirect("/Home/NotAuthorized", true);
                    }
                    break;

                default:
                    //internal user, restricted only by task
                    break;
            }

            TaskModelDAL tmDal = new TaskModelDAL();
            zdkUser.Tasks = tmDal.GetByUserId(zdkUser.User.UserId);
            ViewBag.HeaderToday = System.DateTime.Now.ToShortDateString();
            ViewBag.zdkUser = zdkUser;

        }

        private zdkUserModel _zdkUser;
        public zdkUserModel zdkUser
        {
            get { return _zdkUser; }
            set { _zdkUser = value; }
        }


    }
}
