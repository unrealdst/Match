using DataLayer;
using LogicLayer;
using LogicLayer.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        IMatchService matchService;
        public HomeController()
        {
            var data = new DataRepositry();
            matchService = new MatchService(data);
        }


        public ActionResult Index()
        {
            var viewModel = new MainPageViewModel()
            {
                Matchs = Mapper.Map(matchService.GetMatches()).ToList()
            };
            return View(viewModel);
        }

        public ActionResult Play()
        {
            matchService.Play(new MatchPlayParameters()
            {
                Login = User.Identity.Name
            });

            return RedirectToAction("Home", "Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}