using PersonalLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalLogger.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private Repository<MyLog> _myLogs;
        private Repository<LogCategory> _logCategories;
        private Repository<FieldType> _fieldTypes;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<MyLog> MyLogs
        {
            get
            {
                return _myLogs ?? (_myLogs = new Repository<MyLog>(_dbContext));
            }
        }

        public IRepository<LogCategory> LogCategories
        {
            get
            {
                return _logCategories ?? (_logCategories = new Repository<LogCategory>(_dbContext));
            }
        }

        public IRepository<FieldType> FieldTypes
        {
            get
            {
                return _fieldTypes ?? (_fieldTypes = new Repository<FieldType>(_dbContext));
            }
        }

    }
}