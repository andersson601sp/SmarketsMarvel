using Smarkets.Marvel.Domain.Repositories;
using Smarkets.Marvel.Infra.Data.Context;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        SmarketsMarvelContext context;

        public UnitOfWork(SmarketsMarvelContext context)
        {
            this.context = context;
        }

        public Task<int> CommitAsync()
        {
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}