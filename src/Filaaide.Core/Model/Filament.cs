using SQLite;

namespace Filaaide.Core.Model
{
	public class Filament
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public string Manufacturer { get; set; }

		public string Color { get; set; }

		public string Material { get; set; }

	}
}