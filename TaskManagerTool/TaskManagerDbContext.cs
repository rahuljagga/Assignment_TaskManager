namespace TaskManagerTool
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TaskManagerTool.Models;

    public class TaskManagerDbContext : DbContext
    {

        public TaskManagerDbContext()
            : base("name=TaskManagerDbContext")
        {
        }
              

         public virtual DbSet<Tasks> Tasks { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}