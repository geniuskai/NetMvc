using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buddhism.Domain.Security;
using Buddhism.EntityFramework.Initializer;

namespace Buddhism.EntityFramework
{
    public class BuddhismContext:DbContext
    {
        public BuddhismContext()
            : base("name=BuddhismContext")
        {
            Database.SetInitializer<BuddhismContext>(new BuddhismContextInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//重写实体映射
        }
    }
}
