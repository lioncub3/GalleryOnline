using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GalleryOnline.Models;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace GalleryOnline.Controllers
{
    public class HomeController : Controller
    {
        CloudStorageAccount storageAccount;
        CloudBlobClient client;
        CloudBlobContainer container;
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Photo photo)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            if (photo.File != null)
            {
                string type = Path.GetExtension(book.Photo.FileName);
                string name = $"{DateTime.Now.ToString("ssmmhhddMMyyyy")}{type}";
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", name);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await book.Photo.CopyToAsync(fileStream);
                }

                book.PhotoUrl = "/photos/" + name;

                CloudBlockBlob file = container.GetBlockBlobReference(name);
                await file.UploadFromFileAsync(path);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
