using bugTracker.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bugTracker.Models.ViewModels
{
    public class ManageMembersViewModel
    {
        public virtual List<ApplicationUser> Users { get; set; }
        public virtual List<ApplicationUser> Members { get; set; }
    }
}