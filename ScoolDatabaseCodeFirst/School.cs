namespace ScoolDatabaseCodeFirst
{
    using SchoolDatabaseCodeFirst;
    using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;

        [Table("School")]
        public partial class School
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public School()
            {
                Student = new HashSet<Student>();
            }

            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int ID { get; set; }

            [Required]
            [StringLength(20)]
            public string SchoolName { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Student> Student { get; set; }
            
        }
    public class SchoolDBInitializer : CreateDatabaseIfNotExists<SchoolDatabaseCodeFirst.Connection>
    {

        protected override void Seed(Connection context) => context.School.AddOrUpdate(x => x.SchoolName,
            new School() { ID = 1, SchoolName = "Höglandsskolan" },
            new School() { ID = 2, SchoolName = "Arnässkolan" },
            new School() { ID = 3, SchoolName = "Geneskolan" },
            new School() { ID = 4, SchoolName = "Sörlidenskolan" },
            new School() { ID = 5, SchoolName = "Alneskolan" },
            new School() { ID = 6, SchoolName = "Husumskolan" },
            new School() { ID = 7, SchoolName = "Bredbyskolan" },
            new School() { ID = 8, SchoolName = "Björnaskolan" }

        );

        }
    }


