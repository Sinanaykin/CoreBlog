using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer p)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.WriterMail)

                };
                var useridentity = new ClaimsIdentity(claims, "a");//String türünde bir değer göndermek gerekiyor burda a olur b veya c olur
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return RedirectToAction("Index", "Writer");
            }


        }
    }
}




//        Context c = new Context();
//        var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
//            if (datavalue!=null)
//            {
//                HttpContext.Session.SetString("username",p.WriterMail);
//                return RedirectToAction("Index", "Writer");
//    }
//            else
//            {
//                return View();
//}

