using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

using netcore.Data;
using netcore.Models.Invent;

namespace netcore.Controllers.Invent
{
    [Authorize(Roles = "Stock")]
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


