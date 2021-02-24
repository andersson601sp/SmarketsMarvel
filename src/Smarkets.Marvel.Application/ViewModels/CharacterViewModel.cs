using Smarkets.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Smarkets.Marvel.Application.ViewModels
{
	public class CharacterViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }		
		public string ThumbnailUrl { get; set; }
		public IEnumerable<Story> Stories { get; set; }
	}
}