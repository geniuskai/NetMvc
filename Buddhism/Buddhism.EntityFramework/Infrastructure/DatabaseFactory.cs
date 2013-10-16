using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddhism.EntityFramework.Infrastructure
{
    public class DatabaseFactory:Disposable,IDatabaseFactory
    {
        private BuddhismContext dataContext;
        public BuddhismContext Get()
        {
            return dataContext??(dataContext =new BuddhismContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
