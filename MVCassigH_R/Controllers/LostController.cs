using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCassigH_R.Controllers
{
    public class LostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}