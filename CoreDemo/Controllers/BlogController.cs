using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {

        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }


        public IActionResult BlogListByWriter()
        {
            var values = bm.GetListWithCategoryByWriterBm(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
           
            
            List<SelectListItem> categoryValues = (from x in cm.GetList() //Kategorileri dropdown dan çekmek için burda name ve id sini aldık
                                                   select new SelectListItem
                                                   { 
                                                       Text=x.CategoryName,
                                                       Value=x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;//Burdada yukarda çektiğimiz veriyi viewbage atadık çünkü view tarafında bu değerleri alıcaz
            
            return View();
        }
        [HttpPost]  
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);//WriterValidator de validate(kontrol) et  p değerlerini 
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate =DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
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

        public IActionResult DeleteBlog(int id)//Buraya id yide view kısmında yolluyoruz
        {
            var blogbalue = bm.TGetById(id);
            bm.TDelete(blogbalue);  
            return RedirectToAction("BlogListByWriter");  
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryValues = (from x in cm.GetList() //Kategorileri dropdown dan çekmek için burda name ve id sini aldık
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;//Burdada yukarda çektiğimiz veriyi viewbage atadık çünkü view tarafında bu değerleri alıcaz


            return View(blogvalue);
        }


        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            p.WriterID = 1;
            p.BlogCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
           bm.TUpdate(p);   
            return RedirectToAction("BlogListByWriter");
        }



    }
}
