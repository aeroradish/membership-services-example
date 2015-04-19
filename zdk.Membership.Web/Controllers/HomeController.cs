using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zdk.Membership.Web.DALs;
using zdk.Membership.Web.Models;

namespace zdk.Membership.Web.Controllers
{
    public class HomeController : Controller
    {

        zdkMembershipProvider mp = new zdkMembershipProvider();
        private zdkUserModel currentUser;

        #region "DALs"
        UserModelDAL umDal = new UserModelDAL();
        #endregion

        public ActionResult Index()
        {

           //addNewUser();

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }


        public ActionResult NotAuthorized()
        {
            ViewBag.Message = "Your NotAuthorized page.";

            return View();
        }

        private void addNewUser()
        {

            string newPassword = "";

            string s = "1";

            if (!String.IsNullOrEmpty(s))
            {
                // Key exists
                if ("1" == s)
                {
                    UserModel usm;
                    usm = umDal.GetByUserName("drone");

                    if (null == usm)
                    {
                        //create admin
                        newPassword = "password"; 
                        usm = new UserModel();
                        usm.UserName = "drone";
                        usm.Password = newPassword;
                        usm.Email = "drone@email.com";
                        usm.Password = mp.EncryptPassword(usm.Password);
                        
                        umDal.Insert(usm);

                    }

                }

            }


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
