using Refit;
using Smarkets.Marvel.Application.Common;
using Smarkets.Marvel.Domain.Entities;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Application.Interfaces.Interfaces
{
	public interface ICharacterApi
    {
        [Get("/v1/public/characters?nameStartsWith={name}&ts={timestamp}&apikey={apikey}&hash={hash}")]
        [Headers("Accept: application/json")]
        Task<MarvelApiResult<Character[]>> GetCharactersByNameStartsWithAsync(string name, string timestamp, string apikey, string hash);        
    }
}
