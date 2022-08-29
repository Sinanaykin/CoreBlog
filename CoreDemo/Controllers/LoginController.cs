﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]//Startup daki bütün kısıtlamalardan muaf olsun yani authorization işlemi yapmasada bu sayfaya erişebilir oluyor böylelikle.
        public IActionResult Index()
        {
            return View();
        }
    }
}
 