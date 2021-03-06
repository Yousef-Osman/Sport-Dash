﻿using Microsoft.AspNetCore.Http;
using SportDash.Data;
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
        public bool IsProfileImg { get; set; } = false;

        [NotMapped]
        [DisplayName("Upload an Image")]
        public IFormFile ImageFile { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
