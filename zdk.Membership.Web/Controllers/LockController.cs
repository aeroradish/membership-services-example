using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zdk.Membership.Web.Controllers
{
    public class LockController : zdkController
    {
        //
        // GET: /Lock/

        public ActionResult Index()
        {
            return View();
        }

        [RequiresTask]
        public ActionResult LowSecurity()
        {
            return View();
        }

        [RequiresTask]
        public ActionResult HighSecurity()
        {
            return View();
        }

    }
}
