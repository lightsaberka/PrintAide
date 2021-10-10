using SQLite;

namespace Filaaide.Core.Model
{
	public class Thing
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public string Name { get; set; }

		public int FilamentId { get; set; }

		public float Weight { get; set; }
	}
}