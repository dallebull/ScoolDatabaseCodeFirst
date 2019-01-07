using System.Data.Entity.Migrations;

namespace SchoolDatabaseCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ScoolDatabaseCodeFirst;

    public partial class Connection : System.Data.Entity.DbContext
    {
        public Connection()
            : base("name=Connection")
    
        {
            Database.SetInitializer<Connection>(new CreateDatabaseIfNotExists<Connection>());
            Database.SetInitializer(new SchoolDBInitializer());
        }

        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .Property(e => e.SchoolName)
                .IsFixedLength();

            modelBuilder.Entity<School>()
                .HasMany(e => e.Student)
                .WithRequired(e => e.School)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsFixedLength();
        }

    }
}
