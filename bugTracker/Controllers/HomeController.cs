using Microsoft.AspNet.Identity;
using bugTracker.Models;
using bugTracker.Models.Domain;
using bugTracker.Models.Helpers;
using bugTracker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bugTracker.Controllers
{
   public class HomeController : Controller
    {
        private ApplicationDbContext DbContext;
         private ProjectHelper ProjectHelper;

        public HomeController()
        {
            DbContext = new ApplicationDbContext();
            ProjectHelper = new ProjectHelper(DbContext);
        }
       
      
        public ActionResult Index()
        {
           
            return View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            ViewBag.Title = "Dash board";

            var userId = User.Identity.GetUserId();
            var model = new DashboardViewModel();
            if (User.IsInRole("Admin") || User.IsInRole("Project Manager"))
            {
                model.NumberOfProjects = DbContext.Projects.Where(p => p.Archive != true).Count();
                model.NumberOfTickets = DbContext.Tickets.Where(p => p.Project.Archive != true).Count();
                model.NumberOfTicketsOpen = DbContext.Tickets.Where(u => u.TicketStatusId == 1).Where(u => u.Project.Archive != true).Count();
                model.NumberOfTicketsResolved = DbContext.Tickets.Where(u => u.TicketStatusId == 2).Where(u => u.Project.Archive != true).Count();
                model.NumberOfTicketsRejected = DbContext.Tickets.Where(u => u.TicketStatusId == 3).Where(u => u.Project.Archive != true).Count();
            }
            else
            {
                model.NumberOfProjects = DbContext.Projects.Where(p => p.Archive != true).Where(p => p.Users.Any(u => u.Id
                == userId)).Count();

                if (User.IsInRole("Contributor"))
                {
                    model.NumberOfTicketsCreated = DbContext.Tickets.Where(p => p.Project.Archive != true).Where(p => p.CreatedById == userId).Count();
                }

                if (User.IsInRole("Developer"))
                {
                    model.NumberOfTicketsAssigned = DbContext.Tickets.Where(p => p.Project.Archive != true).Where(p => p.AssignedToId == userId).Count();
                }

            }
            return View(model);
        }

    }
}