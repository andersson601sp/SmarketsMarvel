using Smarkets.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Smarkets.Marvel.Application.ViewModels
{
	public class FanViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Cpf { get; set; }		
		public string Email { get; set; }
		public string DataNascimento { get; set; }
	}
}