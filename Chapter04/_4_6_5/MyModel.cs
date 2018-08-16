namespace _4_6_5
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyModel : DbContext
    {

        public MyModel()
            : base("name=MyModel")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Map<Camera>(m =>
                    m.MapInheritedProperties()
                    .ToTable("Products")
                    .Requires("Discriminator")
                    .HasValue("Camera")
                    )
                .Map<SingleReflexCamera>(m =>
                    m.MapInheritedProperties()
                        .ToTable("Products")
                        .Requires("Discriminator")
                        .HasValue("SingleReflexCamera")
                    )
                .Map<Lens>(m =>
                    m.MapInheritedProperties()
                         .ToTable("Products")
                         .Requires("Discriminator")
                         .HasValue("Lens")
                );

            base.OnModelCreating(modelBuilder);
        }
    }

}