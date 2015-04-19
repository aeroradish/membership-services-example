using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using zdk.Membership.Web.Models;
using System.Data;

namespace zdk.Membership.Web.DALs
{
    public class UserModelDAL
    {
        public UserModelDAL()
        {

        }
        public UserModel GetById(Guid id)
        {
            List<UserModel> rc = null;
            UserModel um = new UserModel();

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<UserModel>("UserGetById",
                    new
                    {
                        UserID = id
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc.FirstOrDefault();

        }

        public UserModel GetByUserName(string userName)
        {

            List<UserModel> rc = null;
            UserModel um = new UserModel();

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<UserModel>("UserGetByUserName",
                    new
                    {
                        UserName = userName
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc.FirstOrDefault();

        }

        public List<UserModel> GetAllByDistrict(Guid id)
        {

            List<UserModel> rc = null;

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<UserModel>("GetUserModelAllByDistrict",
                    new
                    {
                        DistrictID = id
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc;

        }

        public List<UserModel> GetSubstitutesOnly(Guid DistrictID)
        {

            List<UserModel> rc = null;

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<UserModel>("GetUserModelSubstitutesOnly",
                    new
                    {
                        DistrictID = DistrictID
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc;

        }

        public List<UserModel> GetAllByClassification(Guid DistrictID, bool NoSubstitutes)
        {

            List<UserModel> rc = null;

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<UserModel>("GetUserModelAllByClassification",
                    new
                    {
                        DistrictID = DistrictID
                        ,
                        NoSubstitutes = NoSubstitutes
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc;

        }

        public List<UserModel> GetAllByFacility(Guid DistrictID, Guid UserID)
        {

            List<UserModel> rc = null;

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<UserModel>("GetUserModelAllByFacility",
                    new
                    {
                        DistrictID = DistrictID
                        ,
                        UserID = UserID
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc;

        }

        public List<UserModel> GetAll()
        {

            List<UserModel> rc = null;

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<UserModel>("GetUserModelALL",
                    new
                    {

                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc;

        }

        public List<UserModel> GetUserModelAllByRole(Guid RoleID)
        {

            List<UserModel> rc = null;

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<UserModel>("GetUserModelAllByRole",
                    new
                    {
                        RoleID = RoleID
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc;

        }

        public void Insert(UserModel user)
        {
            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                con.Execute("UserInsert",
                    new
                    {
                        UserId = user.UserId
                        ,
                        UserName = user.UserName
                        ,
                        Email = user.Email
                        ,
                        Password = user.Password
                        ,
                        IsConfirmed = user.IsConfirmed
                        ,
                        PasswordFailuresSinceLastSuccess = user.PasswordFailuresSinceLastSuccess
                        ,
                        LastPasswordFailureDate = user.LastPasswordFailureDate
                            //,  ConfirmationToken = user.ConfirmationToken
                        ,
                        CreateDate = user.CreateDate
                        ,
                        PasswordChangedDate = user.PasswordChangedDate
                            //                     , PasswordVerificationToken = user.PasswordVerificationToken
                            //                     ,PasswordVerificationTokenExpirationDate = user.PasswordVerificationTokenExpirationDate
                       // ,
                       // FacilitiesID = user.FacilitiesID
                        //,
                       // DistrictID = user.DistrictID
                            // ,EmailResult = user.EmailResult
                        ,
                        IsActive = user.IsActive
                            //                     ,  FileLocation = user.FileLocation
                        ,
                        FirstName = user.FirstName
                        ,
                        LastName = user.LastName
                         ,
                        TimeZone = user.TimeZone
                            //                     ,  Culture = user.Culture
                       // ,
                      //  ServerAdmin = user.ServerAdmin

                        //  Comment = user.Comment
                            //  //    ,CreationDate =user.CreationDate
                            //  , IsApproved=user.IsApproved
                            //  , IsLockedOut=user.IsLockedOut
                            //  , IsOnline=user.IsOnline
                            //  , LastActivityDate=user.LastActivityDate
                            ////  , LastLockoutDate=user.LastLockoutDate
                            //  , LastLoginDate=DateTime.Now //user.LastLoginDate
                            //  //,LastPasswordChangedDate =user.LastPasswordChangedDate
                            //  , PasswordQuestion=user.PasswordQuestion
                            //  , ProviderName=user.ProviderName
                            //  , ProviderUserKey=user.ProviderUserKey
                            //  , UserId=user.UserId
                        // ,
                        ///EmployeeNumber = user.EmployeeNumber
                       // ,
                       // MI = user.MI
                    },
                    null, null, CommandType.StoredProcedure);
            }
        }
        public void Save(UserModel user)
        {
        }

        public bool Update(UserModel user)
        {
            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                con.Execute("UpdateUserModelByID",
                    new
                    {
                        UserId = user.UserId
                        ,
                        UserName = user.UserName
                        ,
                        Email = user.Email
                        ,
                        FacilitiesID = user.FacilitiesID
                        ,
                        DistrictID = user.DistrictID
                        ,
                        EmailResult = user.EmailResult
                        ,
                        IsActive = user.IsActive
                        ,
                        FirstName = user.FirstName
                        ,
                        LastName = user.LastName
                        ,
                        ServerAdmin = user.ServerAdmin
                        ,
                        ImpersonatedID = user.ImpersonatedID
                        ,
                        EmployeeNumber = user.EmployeeNumber
                        ,
                        MI = user.MI
                    },
                    null, null, CommandType.StoredProcedure);
            }

            return true;
        }

        public bool UpdatePassword(UserModel user)
        {
            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                con.Execute("UpdateUserPassword",
                    new
                    {
                        UserID = user.UserId
                        ,
                        Password = user.Password
                    },
                    null, null, CommandType.StoredProcedure);
            }

            return true;
        }

        public void InsertUsersFacilities(Guid userID, Guid facilityID)
        {
            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                con.Execute("UsersFacilitiesInsert",
                    new
                    {
                        FacilitiesID = facilityID
                        ,
                        UserID = userID
                    },
                    null, null, CommandType.StoredProcedure);
            }
        }

        public void DeleteUsersFacilities(Guid userID, Guid facilityID)
        {
            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                con.Execute("UsersFacilitiesDelete",
                    new
                    {
                        FacilitiesID = facilityID
                        ,
                        UserID = userID
                    },
                    null, null, CommandType.StoredProcedure);
            }
        }

        public void InsertUsersClassification(Guid userID, Guid classificationID, DateTime? HireDate, DateTime? EndDate, Guid? gl_PayrollRateID)
        {
            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                con.Execute("UsersClassificationInsert",
                    new
                    {
                        ClassificationID = classificationID
                        ,
                        UserID = userID
                        ,
                        HireDate = HireDate
                        ,
                        EndDate = EndDate
                        ,
                        GL_PayrollRateID = gl_PayrollRateID
                    },
                    null, null, CommandType.StoredProcedure);
            }
        }

        public void DeleteUsersClassification(Guid userID, Guid classificationID)
        {
            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                con.Execute("UsersClassificationDelete",
                    new
                    {
                        ClassificationID = classificationID
                        ,
                        UserID = userID
                    },
                    null, null, CommandType.StoredProcedure);
            }
        }

        public List<UserModel> GetSubstitutes(Guid DistrictID)
        {

            List<UserModel> rc = null;

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<UserModel>("UserGetSubstitutes",
                    new
                    {
                        DistrictID = DistrictID
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc;

        }

        public List<UserModel> GetSubstitutesAvailable(Guid DistrictID, DateTime EffectiveDate)
        {

            List<UserModel> rc = null;

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<UserModel>("UserGetSubstitutesAvailable",
                    new
                    {
                        DistrictID = DistrictID
                        ,
                        EffectiveDate = EffectiveDate
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc;

        }

    }
}