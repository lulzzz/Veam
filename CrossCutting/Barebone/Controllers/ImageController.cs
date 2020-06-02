//using Barebone.Services;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Threading.Tasks;

//namespace Barebone.Controllers
//{
//    public class ImageController : Controller
//    {
//        private readonly IImageService _imageService;

//        public ImageController(IImageService imageService)
//        {
//            _imageService = imageService;
//        }

//        // GET: Image  
//        public ActionResult Upload()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<ActionResult> Upload(IFormFile photo)
//        {
//            var imageUrl = await _imageService.UploadImageAsync(photo);
//            TempData["LatestImage"] = imageUrl.ToString();
//            return RedirectToAction("LatestImage");
//        }

//        public ActionResult LatestImage()
//        {
//            var latestImage = string.Empty;
//            if (TempData["LatestImage"] != null)
//            {
//                ViewBag.LatestImage = Convert.ToString(TempData["LatestImage"]);
//            }

//            return View();
//        }
//    }
//}
