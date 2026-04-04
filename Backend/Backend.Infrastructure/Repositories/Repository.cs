using Backend.Application.Common.Interfaces.Repositories;
using Backend.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Infrastructure.Repositories
{
    internal class Repository<Entity> : IRepository<Entity>
    {
        protected readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
    }
}
