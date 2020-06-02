using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Veam.Centers.Application;
using Veam.Centers.ViewModels;

namespace Veam
{ 
    public class HallListViewComponent : ViewComponent
    {
        private readonly IHallService _services;
        private readonly IMapper Mapper;
        //public HallListViewComponent()
        //{

        //}
        public HallListViewComponent(IHallService services, IMapper Mapper)
        {
            _services = services;
            this.Mapper = Mapper;
        }

        //public HallListViewComponent(IHallService services)
        //{
        //    _services = services;
        //}

        public IViewComponentResult Invoke(long? id)
        {

            //if (id == null)
            //{
            //    return NotFound();
            //}

            var entity = _services.GetListByMaserId(id);
            var QVM = Mapper.Map<IList<HallQueryVM>>(entity);
            //if (QVM == null)
            //{
            //    return NotFound();
            //}
            return View(QVM);
        }
    }

}
