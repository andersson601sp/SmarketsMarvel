using System;

namespace Smarkets.Marvel.Domain.Entities
{
	public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public Thumbnail Thumbnail { get; set; }   
        public StorySummary Stories { get; set; }
    }
}