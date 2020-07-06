using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLogger.Repository
{
    interface IRepository<TEntity> where TEntity : class
    {
    }
}
