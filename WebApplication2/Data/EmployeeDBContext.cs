using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class EmployeeDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EmployeeDBContext() : base("name=EmployeeDBContext")
        {
        }

        public System.Data.Entity.DbSet<WebApplication2.Models.Student> Students { get; set; }
        public System.Data.Entity.DbSet<WebApplication2.Models.Course> Courses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(t => t.Courses)
                .WithMany(t => t.Students)
                .Map(m =>
                {
                    m.ToTable("StudentCourses");
                    m.MapLeftKey("StudentID");
                    m.MapRightKey("CourseID");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
