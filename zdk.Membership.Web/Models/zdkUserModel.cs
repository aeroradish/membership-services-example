using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace zdk.Membership.Web.Models
{
    public class zdkUserModel : MembershipUser
    {
        public zdkUserModel()
        {
        }

        public zdkUserModel(string FriendlyName, string UserId)
        {
            this.FriendlyName = FriendlyName;

        }

        private UserModel _user;
        public UserModel User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserModel();
                }
                return _user;
            }
            set { _user = value; }
        }

        private List<TaskModel> _tasks;
        public List<TaskModel> Tasks
        {
            get
            {
                if (_tasks == null)
                {
                    _tasks = new List<TaskModel>();
                }
                return _tasks;
            }
            set { _tasks = value; }
        }

        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public Guid? DistrictID { get; set; }
        public string FriendlyName { get; set; }
        public Guid? FacilitiesID { get; set; }

        public string DistrictName { get; set; }
        public string ImpersonatedName { get; set; }
    }
}
