namespace CodeFirst1
{
    using CodeFirst1.Model;
using System;
using System.Data.Entity;
using System.Linq;

    public class BlogDb : DbContext
    {
        public BlogDb()
            : base("name=BlogDb")
        {
        }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogArticle> BlogArticle { get; set; }
    
    }

  
}