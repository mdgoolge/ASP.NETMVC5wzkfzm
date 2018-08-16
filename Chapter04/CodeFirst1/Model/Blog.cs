using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst1.Model
{
    public partial class Blog
    {
        public Blog()
        {
            this.BlogArticle = new HashSet<BlogArticle>();
        }

        public System.Guid Id { get; set; }
        public System.Guid OwnerId { get; set; }
        public string Caption { get; set; }
        public System.DateTime DateCreated { get; set; }

        public virtual ICollection<BlogArticle> BlogArticle { get; set; }
    }
}
