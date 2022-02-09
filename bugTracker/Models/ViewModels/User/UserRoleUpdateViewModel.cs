using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bugTracker.Models.ViewModels
{
    public class UserRoleUpdateViewModel
    {
        public string UserId { get; set; }
        public List<Boolean> UserRoles { get; set; }
    }
}