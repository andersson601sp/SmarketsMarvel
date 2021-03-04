using Smarkets.Marvel.Application.Common;
using Smarkets.Marvel.Application.Interfaces;
using Smarkets.Marvel.Domain.Entities;
using Smarkets.Marvel.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Application.Services
{
	public class FanService : IFanService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFanRepository fanRepository;

        public FanService(IFanRepository fanRepository,
                                IUnitOfWork unitOfWork)
        {
            this.fanRepository = fanRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Fan>> GetAllOrderedByFanNameAsync()
        {
            return await fanRepository.GetAllOrderedByFanNameAsync();
        }
    }
}
