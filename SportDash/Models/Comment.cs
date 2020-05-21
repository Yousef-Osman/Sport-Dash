﻿using SportDash.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Body { get; set; }
        public DateTime DateTime { get; set; }

        public ApplicationUser User { get; set; }
        public Question Question { get; set; }

    }
}
