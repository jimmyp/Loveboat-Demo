using System;
using System.Web.Mvc;
using Loveboat.Commands;
using Loveboat.Models;

namespace Loveboat.Controllers
{
    public class ShipsController : Controller
    {
        private readonly IViewModelCache viewModelCache;
        private readonly ICommandProcessor commandProcessor;

        public ShipsController(IViewModelCache viewModelCache, ICommandProcessor commandProcessor)
        {
            if (viewModelCache == null) throw new ArgumentNullException("viewModelCache");
            this.viewModelCache = viewModelCache;
            this.commandProcessor = commandProcessor;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var ships = viewModelCache.GetAll<ShipViewModel>();
            var model = new ShipsViewModel() {Ships = ships};
            return View("Index", model);
        }

        private ActionResult Process<T>(T command)
        {
            if (!ModelState.IsValid)
                return Index();

            commandProcessor.Process(command);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Arrive(ArrivalCommand command)
        {
            return Process(command);
        }

        [HttpPost]
        public ActionResult Depart(DepatureCommand command)
        {
            return Process(command);
        }
    }
}