namespace MTG.Core.Data
{
	public static class StaticVariables
	{
		public static int CurrentPageCard { get; set; }
		public static int CurrentPageSet { get; set; }

		public static int PageSizeCard { get; set; } = 12;
		public static int PageSizeSet { get; set; } = 5;

		public static string HighlightedSets { get; set; }
	}
}
