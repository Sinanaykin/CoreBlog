using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
    public class CommentList: ViewComponent //ViewComponent den miras almalıyız aşağıdaki metodun isminide Invoke vermeliyiz.
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    UserName="Sinan"
                },
                 new UserComment
                {
                    ID=2,
                    UserName="Murat"
                },
                   new UserComment
                {
                    ID=3,
                    UserName="Ahmet"
                }
            };
            return View(commentValues);
        }
    }
}
