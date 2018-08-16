namespace CodeFirst2
{
    using CodeFirst2.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BlogDbModel : DbContext
    {
       
        public BlogDbModel()
            : base("name=BlogDbModel")
        {
        }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogArticle> BlogArticle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var blogTable = modelBuilder.Entity<Blog>()
                    .ToTable("BlogMainFiles");
            var blogArticleTable = modelBuilder.Entity<BlogArticle>()
                    .ToTable("BlogArticleFiles");

            blogTable.Property(c => c.Id)
                .IsRequired()
                .HasColumnType("bigint");
            blogArticleTable.Property(c => c.BlogId)
                .IsRequired()
                .HasColumnType("bigint");

            blogArticleTable.Property(c => c.Subject)
                .HasMaxLength(250).IsRequired();
            blogArticleTable.Property(c => c.Body)
                .HasMaxLength(4000)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }

}