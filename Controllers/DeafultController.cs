﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class DeafultController : Controller
    {
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
    }
}
