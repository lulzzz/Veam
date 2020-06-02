//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using Veam.Models;

//namespace Veam.Application.Core.Common
//{
//    public interface IIdentityResolver
//    {
//        Guid GetUserId();
//        ApplicationUser GetUser();
//        bool IsAuthenticated();
//        IReadOnlyList<Claim> GetUserClaims();
//    }
//    public class IdentityResolver : IIdentityResolver
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public IdentityResolver(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = httpContextAccessor;
//        }

//        public Guid GetUserId()
//        {
//            if (IsAuthenticated())
//            {
//                string value = _httpContextAccessor.HttpContext.User.Identity.Name;

//                if (Guid.TryParse(value, out Guid id))
//                {
//                    if (id != Guid.Empty)
//                        return id;
//                    else
//                        throw new InvalidCastException("Failed to parse user id.");
//                }
//            }

//            throw new InvalidOperationException("User not authenticated.");
//        }

//        public ApplicationUser GetUser()
//        {
//            if (IsAuthenticated())
//            {
//                Guid id = GetUserId();
//                IReadOnlyList<Claim> claims = GetUserClaims();

//                return new ApplicationUser(id, claims);
//            }

//            throw new InvalidOperationException("User not authenticated");
//        }

//        public bool IsAuthenticated()
//        {
//            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
//        }

//        public IReadOnlyList<Claim> GetUserClaims()
//        {
//            if (IsAuthenticated())
//            {
//                return _httpContextAccessor.HttpContext.User.Claims.ToList();
//            }

//            throw new InvalidOperationException("User not authenticated");
//        }
//    }
//}
