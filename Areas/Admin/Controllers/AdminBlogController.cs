﻿using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using DataAcessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminBlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());

        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }


    }
}