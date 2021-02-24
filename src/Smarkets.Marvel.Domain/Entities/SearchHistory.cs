using System;

namespace Smarkets.Marvel.Domain.Entities
{
	public class SearchHistory
    {
        public Guid Id { get; private set; }
        public string SearchTerm { get; private set; }
        public DateTime SearchDate { get; private set; }

        public SearchHistory()
        {
            Id = Guid.NewGuid();
            SearchDate = DateTime.Now;
        }

        public SearchHistory(string searchTerm) : this()
        {
            SearchTerm = searchTerm;            
        }
    }
}