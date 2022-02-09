using Microsoft.AspNet.Identity.EntityFramework;
using bugTracker.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bugTracker.Models.ViewModels
{
    public class UsersListViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<IdentityUserRole> UserRoles { get; set; }
    }
}