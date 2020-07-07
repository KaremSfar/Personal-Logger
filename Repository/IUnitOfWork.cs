using PersonalLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLogger.Repository
{
    public interface IUnitOfWork
    {
        IRepository<MyLog> MyLogs { get; }
        IRepository<LogCategory> LogCategories { get; }
        IRepository<FieldType> FieldTypes { get; }
    }
}
