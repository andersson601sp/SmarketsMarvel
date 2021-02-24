using Smarkets.Marvel.Application.Common;
using Smarkets.Marvel.Domain.Entities;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Application.Interfaces
{
	public interface ICharacterClient
    {
        Task<MarvelApiResult<Character[]>> GetCharactersByNameStartsWithAsync(string name);
    }
}
