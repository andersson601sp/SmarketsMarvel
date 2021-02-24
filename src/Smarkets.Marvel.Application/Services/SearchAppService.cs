using Smarkets.Marvel.Application.Common;
using Smarkets.Marvel.Application.Interfaces;
using Smarkets.Marvel.Domain.Entities;
using Smarkets.Marvel.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Application.Services
{
	public class SearchAppService : ISearchAppService
    {
        private readonly ISearchHistoryRepository searchHistoryRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICharacterClient characterClient;

        public SearchAppService(ISearchHistoryRepository searchHistoryRepository,
                                ICharacterClient characterClient,
                                IUnitOfWork unitOfWork)
        {
            this.searchHistoryRepository = searchHistoryRepository;
            this.unitOfWork = unitOfWork;
            this.characterClient = characterClient;
        }

        public async Task<IEnumerable<SearchHistory>> GetAllOrderedBySearchDateAsync()
        {
            return await searchHistoryRepository.GetAllOrderedBySearchDateAsync();
        }

        public async Task<MarvelApiResult<Character[]>> GetCharactersByNameAsync(string name)
        {
            await searchHistoryRepository.InsertAsync(new SearchHistory(name));
            await unitOfWork.CommitAsync();

            return await this.characterClient.GetCharactersByNameStartsWithAsync(name);
        }
    }
}
