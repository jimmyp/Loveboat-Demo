using System.Collections.Generic;
using System.Web.Mvc;
using Loveboat.Models;

namespace Loveboat.Controllers
{
    public class ShipsController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            throw new System.NotImplementedException();
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