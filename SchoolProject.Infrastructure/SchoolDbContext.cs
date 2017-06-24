using SchoolProject.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure
{
    public class SchoolDbInitialize : DropCreateDatabaseIfModelChanges<SchoolDbContext>
    {
        protected override void Seed(SchoolDbContext context)
        {
            if (context.Students.Any()) { return; }
            context.Students.Add(
                new Student { ID = 1, Name = "Rice" }
                );
            context.Students.Add(
                new Student { ID = 2, Name = "Second" }
                );
            context.SaveChanges();
            base.Seed(context);
        }
    }
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext() : base("name=SchoolConnectonString")
        {
            //Database.SetInitializer<SchoolDbContext>(new DropCreateDatabaseIfModelChanges<SchoolDbContext>());
        }
        public DbSet<Student> Students { get; set; }
    }
}