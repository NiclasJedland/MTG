using System.Collections.Generic;
using Sakura.AspNetCore;

namespace MTG.Models
{
	public class HomeViewModel
	{
		public List<Set> Sets { get; set; }
		public List<Card> Cards { get; set; }

		public int CurrentPageCard { get; set; }
		public int CurrentPageSet { get; set; }

		public int PageSizeCard { get; set; }
		public int PageSizeSet { get; set; }

		public string HighlightedSets { get; set; }

		public PagedList<IEnumerable<Set>, Set> PaginatedSet { get; set; }
	}
}
