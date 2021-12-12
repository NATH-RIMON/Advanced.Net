using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string UserType { get; set; }
        public virtual List<NewsModel> News { get; set; }
    }
}
