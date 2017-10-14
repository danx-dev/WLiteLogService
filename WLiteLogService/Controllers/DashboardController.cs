using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WLiteLogService.Models;
using WLiteLogService.Repository;

namespace WLiteLogService.Controllers
{
    public class DashboardController : Controller
    {
        private IDatabaseRepository _databaseRepository = new DatabaseRepository();

        // GET: Dashboard
        public ActionResult Index()
        {
            var model = new DashboardViewModel();
            model.ListOfLogEntryViewModels = new List<LogEntryViewModel>();
            model.ListOfLogEntryViewModels = _databaseRepository.GetDefault();
            foreach (var app in _databaseRepository.GetApps())
            {
                model.ListOfApplications.Add(new BaseEntity{ Name = app});
            }
            return View(model);
        }
    }
}