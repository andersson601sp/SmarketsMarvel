using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smarkets.Marvel.Application.Interfaces;
using Smarkets.Marvel.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class CharacterController : Controller
	{
		private readonly IMapper mapper;
		private readonly ISearchAppService searchAppService;

		public CharacterController(
			IMapper mapper,
			ISearchAppService searchAppService)
		{
			this.mapper = mapper;
			this.searchAppService = searchAppService;
		}

		[HttpGet]
		public async Task<IActionResult> SearchCharacterAsync([FromQuery]string term)
		{
			var characters = await this.searchAppService.GetCharactersByNameAsync(term);
			var result = this.mapper.Map<IEnumerable<CharacterViewModel>>(characters.Data.Results);

			return Json(result);
		}
	}
}