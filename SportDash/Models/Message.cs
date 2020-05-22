using SportDash.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime MessageDate { get; set; }
        [Required]
        public string Body { get; set; }

        public string SenderId { get; set; }
        [InverseProperty("SenderMessages")]
        public virtual ApplicationUser Sender { get; set; }
        public string ReceiverId { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
    }
}
