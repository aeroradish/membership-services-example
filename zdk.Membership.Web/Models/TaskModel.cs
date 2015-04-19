using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace zdk.Membership.Web.Models
{
    public class TaskModel
    {
        public Int16 TaskID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string Description { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }
        public string TaskInformation { get; set; }
        public bool IsChecked { get; set; }

        public int MasterNode { get; set; }
        public string NodeDescription { get; set; }


    }
}