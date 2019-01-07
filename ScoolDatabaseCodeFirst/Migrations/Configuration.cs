namespace ScoolDatabaseCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<SchoolDatabaseCodeFirst.Connection>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SchoolDatabaseCodeFirst.Connection";
        }


        }
    }

