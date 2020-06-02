using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Veam.Data;
using Veam.FileStorage.Abstractions;
using Veam.Models;
using Veam.Services;

namespace Veam.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/UploadProfilePicture")]
    [Authorize]
    public class UploadProfilePictureController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IHostingEnvironment _env;
        private IFileStorage fileStorage;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UploadProfilePictureController(IFileService fileService,
            IHostingEnvironment env,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IFileStorage fileStorage)
        {
            _fileService = fileService;
            _env = env;
            _userManager = userManager;
            _context = context;
            this.fileStorage = fileStorage;
        }

        [HttpPost]
        [RequestSizeLimit(5000000)]
        public async Task<IActionResult> PostUploadProfilePicture(List<IFormFile> files)
        {
            try
            {
                var fileName = await _fileService.UploadFile(files, _env);
                //try to update the user profile pict
                ApplicationUser appUser = await _userManager.GetUserAsync(User);
                appUser.profilePictureUrl = "/uploads/" + fileName;
                _context.Update(appUser);
                _context.SaveChanges();
                return Ok(fileName);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }



        }

        //[HttpPost]
        //[RequestSizeLimit(5000000)]
        //public async Task<IActionResult> PostUploadProfilePicture(List<IFormFile> files)
        //{
        //    try
        //    {
        //        var folder = @"\User";

        //        foreach (IFormFile file in files)
        //        {
        //            string filename = Path.GetFileName(file.FileName);

        //            IFileProxy fileProxy = this.fileStorage.CreateFileProxy(folder, filename);

        //            await fileProxy.WriteStreamAsync(file.OpenReadStream());
        //            ApplicationUser appUser = await _userManager.GetUserAsync(User);
        //            appUser.profilePictureUrl = $"{folder}\\{filename}";
        //            _context.Update(appUser);
        //            _context.SaveChanges();// updates it

        //        }
        //        return Ok();


        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(500, new { message = ex.Message });
        //    }


        //}


    }
}