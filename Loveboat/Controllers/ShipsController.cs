using System;
using System.Web.Mvc;
using Loveboat.Models;

namespace Loveboat.Controllers
{
    public class ShipsController : Controller
    {
        private readonly IViewModelCache viewModelCache;

        public ShipsController(IViewModelCache viewModelCache)
        {
            if (viewModelCache == null) throw new ArgumentNullException("viewModelCache");
            this.viewModelCache = viewModelCache;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var ships = viewModelCache.GetAll<ShipViewModel>();
            var model = new ShipsViewModel() {Ships = ships};
            return View("Index", model);
        }
        
        [HttpPost]
        public ActionResult Arrive(ArrivalCommand command)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public ActionResult Depart(DepatureCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}