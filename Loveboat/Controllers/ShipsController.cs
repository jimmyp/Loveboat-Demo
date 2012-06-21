using System;
using System.Web.Mvc;
using Loveboat.Messages.Commands;
using Loveboat.ViewModelCache;
using Loveboat.ViewModels;
using NServiceBus;

namespace Loveboat.Controllers
{
    public class ShipsController : Controller
    {
        private readonly IViewModelCache viewModelCache;
        private readonly IBus bus;

        public ShipsController(IViewModelCache viewModelCache, IBus bus)
        {
            if (viewModelCache == null) throw new ArgumentNullException("viewModelCache");
            if (bus == null) throw new ArgumentNullException("bus");
            this.viewModelCache = viewModelCache;
            this.bus = bus;
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

            bus.Send(command);

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