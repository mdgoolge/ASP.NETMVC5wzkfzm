using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst2.Model
{
    public partial class BlogArticle
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
