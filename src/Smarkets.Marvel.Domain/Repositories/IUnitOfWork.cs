using System;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Domain.Repositories
{
	public interface IUnitOfWork : IDisposable
    {        
        Task<int> CommitAsync();
    }
}