//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Veam.Data;
//using Veam.FileStorage.Abstractions;
//using Veam.Models;
//using Veam.Services;

//namespace Veam
//{


//    public class ProfilePictureViewComponent : ViewComponent
//    {
//        private IFileStorage fileStorage;
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly ApplicationDbContext _context;
//        public ProfilePictureViewComponent( IFileStorage fileStorage,
//            UserManager<ApplicationUser> userManager,
//            ApplicationDbContext context)
//        {
//            this.fileStorage = fileStorage;
//            _userManager = userManager;
//            _context = context;
//        }

       

//        public async Task<IViewComponentResult> InvokeAsync( )
//        {
//           // var pic=
           
//           IDirectoryProxy directoryProxy = this.fileStorage.CreateDirectoryProxy(@"\Test");
//          var sd = directoryProxy.RelativePath;
//            ApplicationUser appUser = await _userManager.GetUserAsync(User);
//            IFileProxy fileProxy = this.fileStorage.CreateFileProxy(sd,appUser.profilePictureUrl);

//            return View( );
//        }
//    }

//}
