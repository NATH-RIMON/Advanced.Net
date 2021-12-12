using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class ReactModel
    {
        public string Id { get; set; }
        public string ReactType { get; set; }
        public string ReactorName { get; set; }
        public virtual NewsModel News { get; set; }
    }
}
