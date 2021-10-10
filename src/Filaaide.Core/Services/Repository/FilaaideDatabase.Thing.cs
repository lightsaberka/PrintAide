using System.Collections.Generic;
using System.Threading.Tasks;
using Filaaide.Core.Model;

namespace Filaaide.Core.Services.Repository
{
	public partial class FilaaideDatabase
	{
		public Task<List<Thing>> GetAllThings()
		{
			return this._connection.Table<Thing>().ToListAsync();
		}

		public Task<Thing> GetThingById(int id)
		{
			return this._connection.Table<Thing>().Where(i => i.Id == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveThing(Thing filament)
		{
			if (filament.Id != 0) {
				return this._connection.UpdateAsync(filament);
			} else {
				return this._connection.InsertAsync(filament);
			}
		}

		public Task<int> DeleteThing(Thing filament)
		{
			return this._connection.DeleteAsync(filament);
		}
	}
}