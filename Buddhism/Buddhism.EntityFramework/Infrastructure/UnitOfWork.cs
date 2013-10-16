using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddhism.EntityFramework.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private BuddhismContext dataContext;
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }
        protected BuddhismContext DataContext
        {
            get { 
                return dataContext??(dataContext=databaseFactory.Get());
            }
        }
        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
