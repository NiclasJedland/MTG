using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MTG.Models
{
    public class Card
    {
		[JsonProperty("artist")]
		public string Artist { get; set; }

		[JsonProperty("cmc")]
		public float? Cmc { get; set; }

		[JsonProperty("colorIdentity")]
		public List<string> ColorIdentity { get; set; }

		[JsonProperty("colors")]
		public List<string> Colors { get; set; }

		[JsonProperty("flavor")]
		public string Flavor { get; set; }

		//[JsonProperty("foreignNames")]
		//public List<ForeignName> ForeignName { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("imageName")]
		public string ImageName { get; set; }

		[JsonProperty("layout")]
		public string Layout { get; set; }

		//[JsonProperty("legalities")]
		//public List<FormatLegality> Legalities { get; set; }

		[JsonProperty("manaCost")]
		public string ManaCost { get; set; }

		[JsonProperty("mciNumber")]
		public string MciNumber { get; set; }

		[JsonProperty("multiverseid")]
		public string MultiverseId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("names")]
		public List<string> Names { get; set; }

		[JsonProperty("number")]
		public string Number { get; set; }

		[JsonProperty("originalText")]
		public string OriginalText { get; set; }

		[JsonProperty("originalType")]
		public string OriginalType { get; set; }

		[JsonProperty("power")]
		public string Power { get; set; }

		[JsonProperty("printings")]
		public List<string> Printings { get; set; }

		[JsonProperty("rarity")]
		public string Rarity { get; set; }
		
		[JsonProperty("rulings")]
		public List<Ruling> Rulings { get; set; }

		[JsonProperty("subtypes")]
		public List<string> Subtypes { get; set; }

		[JsonProperty("supertypes")]
		public List<string> SuperTypes { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("toughness")]
		public string Toughness { get; set; }

		[JsonProperty("loyalty")]
		public string Loyalty { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("types")]
		public List<string> Types { get; set; }

		[JsonProperty("variations")]
		public List<string> Variations { get; set; }
		
		public string Set { get;  set;}
	}
}
