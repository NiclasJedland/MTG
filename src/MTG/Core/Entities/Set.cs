using System.Collections.Generic;
using Newtonsoft.Json;
using Sakura.AspNetCore;

namespace MTG.Models
{
	public class Set
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("releaseDate")]
		public string ReleaseDate { get; set; }

		[JsonProperty("border")]
		public string Border { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("block")]
		public string Block { get; set; }

		[JsonProperty("cards")]
		public List<Card> Cards { get; set; }

		public PagedList<IEnumerable<Card>, Card> PaginatedCard { get; set; }


	}
}
