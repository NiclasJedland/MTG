using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

	}
}
