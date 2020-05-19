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
        public int Sender_Id { get; set; }
        [ForeignKey(nameof(Target))]
        public int Receiver_Id { get; set; }

        public DateTime Message_Date { get; set; }
        public string Message_Body { get; set; }
        //public Boolean MessageRead { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationUser Target { get; set; }
    }
}
