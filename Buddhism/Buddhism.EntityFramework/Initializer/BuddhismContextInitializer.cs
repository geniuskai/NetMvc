using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buddhism.Domain.Security;

namespace Buddhism.EntityFramework.Initializer
{
    public class BuddhismContextInitializer : DropCreateDatabaseIfModelChanges<BuddhismContext>
    {
        protected override void Seed(BuddhismContext context)
        {
            var users = new List<User>{
                new User{UserAccount = "Administrator",UserName="xx",UserPassword="111111"},
                new User{UserAccount = "User",UserName="xx",UserPassword="111111"}               
            };
            users.ForEach(r => context.Users.Add(r));
        }
    }
}
