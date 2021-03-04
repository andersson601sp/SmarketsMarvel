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
	public class FanController : Controller
	{
		private readonly IMapper mapper;
		private readonly IFanService fanService;

		public FanController(
			IMapper mapper,
			IFanService fanService)
		{
			this.mapper = mapper;
			this.fanService = fanService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = this.mapper.Map<IEnumerable<FanViewModel>>(fanService);

			return Json(result);
		}
	}
}