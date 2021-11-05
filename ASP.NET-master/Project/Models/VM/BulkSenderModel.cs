using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models.VM
{
    public class BulkSenderModel
    {
        [Required]
        public int SenderNumberId { get; set; }


        public int GroupId { get; set; }



        [Required(ErrorMessage = "Please enter Message")]
        [MinLength(1)]
        public string Message { get; set; }


        public virtual ICollection<SenderNumber> SenderNumbers { get; set; }
        public virtual ICollection<Template> Templates { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}