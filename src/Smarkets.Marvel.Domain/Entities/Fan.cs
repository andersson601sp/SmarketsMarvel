using System;

namespace Smarkets.Marvel.Domain.Entities
{
	public class Fan
    {
        public Fan()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }        
        public string Email { get; set; }   
        public string DataNascimento { get; set; }
    }
}