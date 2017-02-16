using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MTG.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MTG.Repository
{
	public static class Repo
	{
		public static List<Set> AllSets { get; set; }

		public static void PopulateSet()
		{
			var returnList = new List<Set>();

			var targetDate = DateTime.Parse("2011-07-14").Date;

			var file = @"wwwroot\Files\MTG.json";
			var json = File.ReadAllText(file);

			dynamic dynamicData = JsonConvert.DeserializeObject(json);

			foreach(var SetName in dynamicData)
			{
				foreach(var Set in SetName)
				{					
					var date = DateTime.Parse(Set.releaseDate.ToString()).Date;

					if((Set.type == "core" || Set.type == "expansion") && (date > targetDate))
					{
						var set = PopulateSet(Set, Set.name.ToString());
						returnList.Add(set);
					}
				}
			}
			AllSets = returnList;
		}

		private static Set PopulateSet(dynamic s, string set)
		{
			var returnSet = new Set();
			returnSet.Cards = new List<Card>();
			returnSet.Name = s.name;
			returnSet.Code = s.code;
			returnSet.ReleaseDate = s.releaseDate;
			returnSet.Border = s.border;
			returnSet.Type = s.type;
			returnSet.Block = s.block;

			foreach(var Card in s.cards)
			{
				if(Card.rarity == "Rare" || Card.rarity == "Mythic Rare")
				{
					var card = PopulateCard(Card);
					returnSet.Cards.Add(card);
				}
				else
				{
					//remove all non-rare/mythics
					var file = @"wwwroot\images\" + set + @"\" + Card.name.ToString() + ".jpg";
					if(File.Exists(file))
					{
						File.Delete(file);
					}
				}
			}
			return returnSet;
		}

		private static Card PopulateCard(dynamic c)
		{
			var returnCard = new Card();
			returnCard.ColorIdentity = new List<string>();
			returnCard.Colors = new List<string>();
			returnCard.Names = new List<string>();
			returnCard.Printings = new List<string>();
			returnCard.Rulings = new List<Ruling>();
			returnCard.Subtypes = new List<string>();
			returnCard.SuperTypes = new List<string>();
			returnCard.Types = new List<string>();
			returnCard.Variations = new List<string>();

			returnCard.Artist = c.artist;
			returnCard.Cmc = c.cmc;

			foreach(var item in c.colorIdentity ?? Enumerable.Empty<string>())
			{
				returnCard.ColorIdentity.Add((string)item);
			}

			foreach(var item in c.colors ?? Enumerable.Empty<string>())
			{
				returnCard.Colors.Add((string)item);
			}

			returnCard.Flavor = c.flavor;
			returnCard.Id = c.id;
			returnCard.ImageName = c.imageName;
			returnCard.Layout = c.layout;
			returnCard.Loyalty = c.loyalty;
			returnCard.ManaCost = c.manaCost;
			returnCard.MciNumber = c.mciNumber;
			returnCard.MultiverseId = c.multiverseid;
			returnCard.Name = c.name;

			foreach(var item in c.names ?? Enumerable.Empty<string>())
			{
				returnCard.Names.Add((string)item);
			}

			returnCard.Number = c.number;
			returnCard.OriginalText = c.originalText;
			returnCard.OriginalType = c.originalType;
			returnCard.Power = c.power;

			foreach(var item in c.printings ?? Enumerable.Empty<string>())
			{
				returnCard.Printings.Add((string)item);
			}

			returnCard.Rarity = c.rarity;

			foreach(var item in c.rulings ?? Enumerable.Empty<string>())
			{
				string date = item.date;
				string text = item.text;
				var ruling = new Ruling();
				ruling.Date = date;
				ruling.Text = text;
				returnCard.Rulings.Add(ruling);
			}

			foreach(var item in c.subtypes ?? Enumerable.Empty<string>())
			{
				returnCard.Subtypes.Add((string)item);
			}

			foreach(var item in c.supertypes ?? Enumerable.Empty<string>())
			{
				returnCard.SuperTypes.Add((string)item);
			}

			returnCard.Text = c.text;
			returnCard.Toughness = c.toughness;
			returnCard.Type = c.type;

			foreach(var item in c.types ?? Enumerable.Empty<string>())
			{
				returnCard.Types.Add((string)item);
			}

			foreach(var item in c.variations ?? Enumerable.Empty<string>())
			{
				returnCard.Variations.Add((string)item);
			}

			return returnCard;
		}
	}
}
