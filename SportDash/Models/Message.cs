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
        public int Message_Id { get; set; }

        [ForeignKey (nameof(User)) ]
        public String Sender_Id { get; set; }
        [ForeignKey(nameof(Target))]
        public String Receiver_Id { get; set; }

        [Required]
        public DateTime Message_Date { get; set; }
        [Required]
        public string Message_Body { get; set; }

        public ApplicationUser User { get; set; }
        public ApplicationUser Target { get; set; }
    }
}
