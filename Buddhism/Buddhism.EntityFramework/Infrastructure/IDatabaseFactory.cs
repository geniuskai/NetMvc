using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddhism.EntityFramework.Infrastructure
{
    public interface IDatabaseFactory
    {
        BuddhismContext Get();
    }
}
