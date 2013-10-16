using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buddhism.Domain.Security;
using Buddhism.EntityFramework.Infrastructure;

namespace Buddhism.Service.IServices.Security
{
    public interface IUserService : IRepository<User>
    {
    }
}
