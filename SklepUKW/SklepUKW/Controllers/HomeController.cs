﻿using SklepUKW.DAL;
using SklepUKW.Models;
using SklepUKW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepUKW.Controllers
{
    public class HomeController : Controller
    {
        FilmsContext db = new FilmsContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult StaticSite(string name)
        {
            return View(name);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}