using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RealEstateTechnicalTest.Domain.UnitOfWork;
using RealEstateTechnicalTest.Infraestructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateTechnicalTest.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Entities _dbContext;

        public UnitOfWork(Entities entities)
        {
            _dbContext = entities;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
           return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
