using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Views.Exit
{
    public class EndSessionController : Controller
    {
        public ActionResult Exit() => RedirectToAction("Index","Card");
    }
}
