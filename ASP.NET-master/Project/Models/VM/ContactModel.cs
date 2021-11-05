using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models.VM
{
    public class ContactModel
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        
    }
}