using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using SportDash.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Components
{
    public class ImageGallery: ViewComponent
    {
        private readonly IImageRepository _imageRepository;

        public ImageGallery(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public IViewComponentResult Invoke()
        {
            var images = _imageRepository.GetImages(9);
            return View(images);
        }
    }
}
