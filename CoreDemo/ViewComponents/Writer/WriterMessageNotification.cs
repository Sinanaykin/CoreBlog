using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
     
        public IViewComponentResult Invoke()
        {
            string p;
            p = "sinanaykinnn@gmail.com";
            var values = mm.GetInboxtListByWriter(p);
            return View(values);

        }
    }
}
