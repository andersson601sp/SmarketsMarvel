using Smarkets.Marvel.Application.Common;
using Smarkets.Marvel.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Application.Interfaces
{
	public interface ISearchAppService
    {
        Task<IEnumerable<SearchHistory>> GetAllOrderedBySearchDateAsync();
        Task<MarvelApiResult<Character[]>> GetCharactersByNameAsync(string name);
    }
}