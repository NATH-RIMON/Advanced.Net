using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
        public string Category { get; set; }
        public virtual UserModel User { get; set; }
        public virtual List<CommentModel> Comments { get; set; }
        public virtual List<ReactModel> Reacts { get; set; }
    }
}
