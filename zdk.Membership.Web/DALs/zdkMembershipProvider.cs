using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using zdk.Membership.Web.DALs;
using zdk.Membership.Web.Models;

public class zdkMembershipProvider : MembershipProvider
{


    public zdkMembershipProvider()
    {
    }

    public string EncryptPassword(string password)
    {

        byte[] encPwd = Utilities.StrToByteArray(password);
        byte[] encPassword = base.EncryptPassword(encPwd);
        string encString = Utilities.ByteArrayToString(encPassword);
        return encString;

    }

    public override string ApplicationName
    {
        get
        {
            throw new NotImplementedException();
        }
        set
        {
            throw new NotImplementedException();
        }
    }

    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {
        throw new NotImplementedException();
    }

    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
        throw new NotImplementedException();
    }

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
        throw new NotImplementedException();
    }

    public override bool EnablePasswordReset
    {
        get { throw new NotImplementedException(); }
    }

    public override bool EnablePasswordRetrieval
    {
        get { throw new NotImplementedException(); }
    }

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new NotImplementedException();
    }

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new NotImplementedException();
    }

    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        throw new NotImplementedException();
    }

    public override int GetNumberOfUsersOnline()
    {
        throw new NotImplementedException();
    }

    public override string GetPassword(string username, string answer)
    {
        throw new NotImplementedException();
    }

    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
        
        zdkUserModel loggedUser = new zdkUserModel();
        UserModelDAL umd = new UserModelDAL();

        UserModel currentUser = umd.GetByUserName(username);
        if (null != currentUser)
        {
            loggedUser.DistrictID = currentUser.DistrictID;
            loggedUser.DistrictName = currentUser.DistrictName;
            loggedUser.Email = currentUser.Email;
            loggedUser.FriendlyName = currentUser.FirstName;
            loggedUser.FacilitiesID = currentUser.FacilitiesID;
            loggedUser.Password = currentUser.Password;
            loggedUser.User = currentUser;

            if (currentUser.ServerAdmin == true)
            {
                //for ServerAdmin impersonation reasons
                
                if (null != currentUser.ImpersonatedID)
                {
                    loggedUser.ImpersonatedName = umd.GetById((Guid)currentUser.ImpersonatedID).UserName;
                }
                else
                {
                    loggedUser.ImpersonatedName = currentUser.UserName;
                }

            }

        }
        return loggedUser;

    }

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
        throw new NotImplementedException();
    }

    public override string GetUserNameByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public override int MaxInvalidPasswordAttempts
    {
        get { throw new NotImplementedException(); }
    }

    public override int MinRequiredNonAlphanumericCharacters
    {
        get { throw new NotImplementedException(); }
    }

    public override int MinRequiredPasswordLength
    {
        get { throw new NotImplementedException(); }
    }

    public override int PasswordAttemptWindow
    {
        get { throw new NotImplementedException(); }
    }

    public override MembershipPasswordFormat PasswordFormat
    {
        get { throw new NotImplementedException(); }
    }

    public override string PasswordStrengthRegularExpression
    {
        get { throw new NotImplementedException(); }
    }

    public override bool RequiresQuestionAndAnswer
    {
        get { throw new NotImplementedException(); }
    }

    public override bool RequiresUniqueEmail
    {
        get { throw new NotImplementedException(); }
    }

    public override string ResetPassword(string username, string answer)
    {
        throw new NotImplementedException();
    }

    public override bool UnlockUser(string userName)
    {
        throw new NotImplementedException();
    }

    public override void UpdateUser(MembershipUser user)
    {
        throw new NotImplementedException();
    }

    public override bool ValidateUser(string username, string password)
    {
        UserModel currentUser = default(UserModel);

        zdkMembershipProvider zdkmp = new zdkMembershipProvider();
        string encPassword = zdkmp.EncryptPassword(password);

        UserModelDAL umd = new UserModelDAL();

        //to set password for testing
        ////UserModel eraseMe = new UserModel();
        ////eraseMe.Password = encPassword;
        //umd.Update(eraseMe);

        currentUser = umd.GetByUserName(username);// userRep.GetByUserName(username);

        if (currentUser != null)
        {

            if ((currentUser.Password == encPassword) && (true == currentUser.IsActive)) //password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
}
