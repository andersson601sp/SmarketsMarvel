using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using Smarkets.Marvel.Application.Common;
using Smarkets.Marvel.Application.Interfaces;
using Smarkets.Marvel.Application.Interfaces.Interfaces;
using Smarkets.Marvel.Domain.Entities;
using System.Text.Json;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Application.Services
{
	public class CharacterClient : ICharacterClient
	{
		private readonly IMarvelClient marvelClient;
		private readonly ICharacterApi characterApi;

		public CharacterClient(IMarvelClient marvelClient)
		{
			this.marvelClient = marvelClient;			

			characterApi = RestService.For<ICharacterApi>(this.marvelClient.Host, new RefitSettings
			{
				ContentSerializer = new NewtonsoftJsonContentSerializer
				(
					new JsonSerializerSettings
					{
						ContractResolver = new CamelCasePropertyNamesContractResolver()
					}
				)
			});
		}

		public async Task<MarvelApiResult<Character[]>> GetCharactersByNameStartsWithAsync(string name)
		{
			return await characterApi.GetCharactersByNameStartsWithAsync(name, this.marvelClient.GetTimeStamp(), this.marvelClient.GetApiKey(), this.marvelClient.GetHash());
		}
	}
}
