using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [NotMapped]
        [DisplayName("Upload an Image")]
        public IFormFile ImageFile { get; set; }
    }
}
