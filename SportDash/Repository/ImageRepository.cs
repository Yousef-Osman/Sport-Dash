using Microsoft.AspNetCore.Hosting;
using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageRepository(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IEnumerable<Image> GetImages(string id)
        {
            var images = _context.Images.Where(i => i.UserId == id).ToList();
            return images;
        }

        public Image GetImageById(int id)
        {
            var image = _context.Images.SingleOrDefault(i => i.Id == id);
            return image;
        }

        public async Task CreateImage(Image image, string id)
        {
            if(image.IsProfileImg == true)
            {
                var profileImage = _context.Images.Where(a => a.IsProfileImg == true).SingleOrDefault();
                if (profileImage != null)
                {
                    await DeleteImage(profileImage.Id);
                }
            }

            string wwwroot = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string fileExtention = Path.GetExtension(image.ImageFile.FileName);
            image.Title = fileName = fileName + DateTime.Now.ToString("yyyyMMddHHmmssffff") + fileExtention;
            string path = Path.Combine(wwwroot + "/images/", fileName);
            using (FileStream fileStram = new FileStream(path, FileMode.Create))
            {
                await image.ImageFile.CopyToAsync(fileStram);
            }
            image.UserId = id;

            _context.Add(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImage(int id)
        {
            var image = await _context.Images.FindAsync(id);

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", image.Title);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }
    }
}
