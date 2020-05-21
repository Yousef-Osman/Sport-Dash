using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface IImageRepository
    {
        IEnumerable<Image> GetImages(string id);

        Image GetImageById(int pieId);

        Task CreateImage(Image image);

        Task DeleteImage(int id);
    }
}
