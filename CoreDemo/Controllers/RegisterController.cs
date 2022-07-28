using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()//Get ve post metodlarının isimleri aynı olmalıdır.Get sayfa açılınca çalışır
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)//Post kaydet buttonu tetilklenince çalısır
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);//WriterValidator de validate(kontrol) et  p değerlerini 
            if (results.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }
    }
}
