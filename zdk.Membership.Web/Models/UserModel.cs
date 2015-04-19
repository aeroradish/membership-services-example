using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace zdk.Membership.Web.Models
{
    public class UserModel : MembershipUser
    {
        public UserModel()
        {
            IsConfirmed = true;
            IsActive = true;

            //LastPasswordFailureDate = DateTime.Now;
            //CreateDate = DateTime.Now;
            //PasswordChangedDate = DateTime.Now;
            //PasswordVerificationTokenExpirationDate = DateTime.Now;
            //LastActivityDate = DateTime.Now;
            // LastLockoutDate = DateTime.Now;
        }
        //Membership required
        [Key()]
        public virtual Guid UserId { get; set; }
        [Required()]
        [MaxLength(100)]
        public virtual string UserName { get; set; }
        [Required()]
        [MaxLength(250)]
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }
        //public  virtual string Email { get; set; }
        [Required()]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public virtual string PasswordConfirm { get; set; }

        public virtual bool IsConfirmed { get; set; }
        public virtual int PasswordFailuresSinceLastSuccess { get; set; }
        public virtual Nullable<DateTime> LastPasswordFailureDate { get; set; }
        [MaxLength(50)]
        public virtual string ConfirmationToken { get; set; }
        public virtual Nullable<DateTime> CreateDate { get; set; }
        public virtual Nullable<DateTime> PasswordChangedDate { get; set; }
        [MaxLength(50)]
        public virtual string PasswordVerificationToken { get; set; }
        public virtual Nullable<DateTime> PasswordVerificationTokenExpirationDate { get; set; }
        [DisplayName("Facility")]
        public virtual Guid? FacilitiesID { get; set; }
        [DisplayName("District")]
        public virtual Guid? DistrictID { get; set; }
        public virtual bool EmailResult { get; set; }
        public virtual bool IsActive { get; set; }
        [MaxLength(250)]
        public virtual string FileLocation { get; set; }
        public virtual bool ServerAdmin { get; set; }
        //public virtual ICollection<Role> Roles { get; set; }

        //Optional
        [MaxLength(50)]
        public virtual string FirstName { get; set; }
        [MaxLength(50)]
        public virtual string LastName { get; set; }
        [MaxLength(25)]
        public virtual string TimeZone { get; set; }
        [MaxLength(50)]
        public virtual string Culture { get; set; }

        [MaxLength(100)]
        public virtual string FacilitiesName { get; set; }
        [MaxLength(100)]
        public virtual string DistrictName { get; set; }

        public virtual Guid? ImpersonatedID { get; set; }
        [MaxLength(20)]
        public virtual string ImpersonatedName { get; set; }
        [MaxLength(50)]
        public virtual string EmployeeNumber { get; set; }

        [StringLength(1, ErrorMessage = "The MI can only be {1} characters long.")]
        public virtual string MI { get; set; }

        public virtual string Fullname
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual string NameLastFirst
        {
            get
            {
                return LastName + ", " + FirstName + " " + MI;
            }
        }

        [DisplayName("Classification")]
        public string Classification { get; set; }

        [DisplayName("Employment Type")]
        public int EmploymentTypeID { get; set; }


    }
}
