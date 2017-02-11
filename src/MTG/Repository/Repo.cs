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
    public class Repo
    {
		public static List<Set> PopulateSet()
		{
			var returnList = new List<Set>();

			var file = @"wwwroot\Files\MTG.json";
			var json = File.ReadAllText(file);

			dynamic dynamicData = JsonConvert.DeserializeObject(json);

			foreach(var SetName in dynamicData)
			{
				foreach(var Set in SetName)
				{
					var set = PopulateSet(Set);

					returnList.Add(set);
				}
			}
			return returnList;
		}

		private static Set PopulateSet(dynamic s)
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
				var card = PopulateCard(Card);
				returnSet.Cards.Add(card);
			}

			return returnSet;
		}

		private static Card PopulateCard(dynamic c)
		{
			var returnCard = new Card();

			returnCard.Artist = c.artist;
			returnCard.Cmc = c.cmc;
			//returnCard.ColorIdentity
			//returnCard.Colors
			returnCard.Flavor = c.flavor;
			returnCard.Id = c.id;
			returnCard.ImageName = c.imageName;
			returnCard.Layout = c.layout;
			returnCard.Loyalty = c.loyalty;
			returnCard.ManaCost = c.manaCost;
			returnCard.MciNumber = c.mciNumber;
			returnCard.MultiverseId = c.multiverseid;
			returnCard.Name = c.name;
			//returnCard.Names
			returnCard.Number = c.number;
			returnCard.OriginalText = c.originalText;
			returnCard.OriginalType = c.originalType;
			returnCard.Power = c.power;
			//returnCard.Printings
			returnCard.Rarity = c.rarity;
			//returnCard.Rulings
			//returnCard.Subtypes
			//returnCard.SuperTypes
			returnCard.Text = c.text;
			returnCard.Toughness = c.toughness;
			returnCard.Type = c.type;
			//returnCard.Types
			//returnCard.Variations

			return returnCard;
		}


	}
}
