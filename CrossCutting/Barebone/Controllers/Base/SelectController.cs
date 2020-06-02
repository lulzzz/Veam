// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.



using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Veam.Application.Core;

namespace Barebone.Controllers
{
    public class SelectController : BaseController/*Api*/
    {
        private readonly IDropDownServices _ddservices;
        public SelectController(IDropDownServices ddservices)
        {
            _ddservices = ddservices;
        }

        [HttpGet]
        public async Task<JsonResult> GetHallbyCenterId(int centerId)
        {
            var items = await _ddservices.GetHallsByCenterId(centerId);

            return Json(new SelectList(items, "Value", "Text"));
        }
    }
}

//public BareboneController(IStorage storage) : base(storage) { }

//public ActionResult Index()
//{
//    return this.View(new IndexViewModelFactory().Create());
//}