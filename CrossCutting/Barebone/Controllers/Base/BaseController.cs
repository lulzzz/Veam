// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Barebone.Controllers
{
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;
        private  IMapper _mapper;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        protected IMapper Mapper => _mapper ?? (_mapper = HttpContext.RequestServices.GetService<IMapper>());
     
        protected string GetCurrentUserName()
        {
            var name= User.Identity.Name; //use it or below
            //var claim = (System.Security.Claims.ClaimsIdentity)User.Identity;
            //var name = claim.FindFirst("name");

            return name == null ? "Unknown" : name;
        }
    }
}

//protected string GetCurrentUserName()
//{
//    var claim = (System.Security.Claims.ClaimsIdentity)User.Identity;
//    var name = claim.FindFirst("name");

//    return name == null ? "Unknown" : name.Value;
//}