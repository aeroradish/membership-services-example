using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using System.Web;
using System.Security.Policy;
using zdk.Membership.Web.Models;
using zdk.Membership.Web.DALs;

// /// <summary>
///// Checks the User's authentication using FormsAuthentication
///// and redirects to the Login Url for the application on fail
///// </summary>
public class RequiresAuthenticationAttribute : ActionFilterAttribute
{

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        ////redirect if not authenticated

        if ((filterContext.HttpContext.User.Identity.IsAuthenticated == false))
        {
            //            //use the current url for the redirect
            string redirectOnSuccess = filterContext.HttpContext.Request.Url.AbsolutePath;

            // //send them off to the login page
            string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
            string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
            filterContext.HttpContext.Response.Redirect(loginUrl, true);
        }
    }

}



///// <summary>
///// Checks the User's role using FormsAuthentication
///// and throws and UnauthorizedAccessException if not authorized
///// </summary>
public class RequiresRoleAttribute : ActionFilterAttribute
{

    private string _roleToCheckFor;
    public string RoleToCheckFor
    {
        get { return _roleToCheckFor; }
        set { _roleToCheckFor = value; }
    }

    public RequiresRoleAttribute(string RoleToCheckFor)
    {
        this.RoleToCheckFor = RoleToCheckFor;
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        //  //redirect if the user is not authenticated
        if ((string.IsNullOrEmpty(RoleToCheckFor) == false))
        {
            if ((filterContext.HttpContext.User.Identity.IsAuthenticated == false))
            {
                ////use the current url for the redirect
                string redirectOnSuccess = filterContext.HttpContext.Request.Url.AbsolutePath;

                ////send them off to the login page
                string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
                filterContext.HttpContext.Response.Redirect(loginUrl, true);

            }
            else
            {
                bool isAuthorized = filterContext.HttpContext.User.IsInRole(this.RoleToCheckFor);
                if ((isAuthorized == false))
                {
                    throw new UnauthorizedAccessException("You are not authorized to view this page");
                }

            }
        }
        else
        {
            throw new InvalidOperationException("No Role Specified");
        }


    }


}




///// <summary>
///// Checks the User's role using FormsAuthentication
///// and throws and UnauthorizedAccessException if not authorized
///// </summary>
public class RequiresTaskAttribute : ActionFilterAttribute
{

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        string ctrller = "";
        string act = "";
        string searchValue = "";

        TaskModelDAL tmDal = new TaskModelDAL();
        //UserModelDAL umDal = null;

        zdkMembershipProvider mp = new zdkMembershipProvider();
        zdkUserModel zdkUser;

        zdkUser = (zdkUserModel)mp.GetUser(filterContext.HttpContext.User.Identity.Name, true);

        ctrller = filterContext.HttpContext.Request.RequestContext.RouteData.Values["Controller"].ToString();
        act = filterContext.HttpContext.Request.RequestContext.RouteData.Values["Action"].ToString();

        if (null != zdkUser.User)
        {
            zdkUser.Tasks = tmDal.GetByUserId(zdkUser.User.UserId);
        }

        //check to see if user has access to this controller
        searchValue = ctrller + "/" + act;

        TaskModel wt;

        wt = (from w in zdkUser.Tasks
              where w.Controller == ctrller & w.Action == act
              select w).FirstOrDefault();
        if (null == wt)
        {

            filterContext.HttpContext.Response.Redirect("/Home/NotAuthorized", true);

        }

    }


}




