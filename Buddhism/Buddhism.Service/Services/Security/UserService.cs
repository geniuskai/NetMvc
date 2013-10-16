using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buddhism.Domain.Security;
using Buddhism.EntityFramework.Infrastructure;
using Buddhism.Service.IServices.Security;

namespace Buddhism.Service.Services.Security
{
    public class UserService : RepositoryBase<User>, IUserService
    {
        public UserService(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
