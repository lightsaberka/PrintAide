using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filaaide.Core.Model;
using Filaaide.Core.Services.Repository;

namespace Filaaide.Core.Services.DataService.Things
{
	public class ThingDataService: IThingDataService
	{
		public async Task<List<Thing>> GetAllThings()
		{
			return await FilaaideDatabase.Database.GetAllThings();
		}

		public async Task<List<Thing>> GetThingsByFilamentId(int id)
		{
			return (await this.GetAllThings()).Where(t => t.FilamentId == id).ToList();
		}

		public async Task<Thing> GetThingById(int id)
		{
			return await FilaaideDatabase.Database.GetThingById(id);
		}

		public async Task<int> SaveThing(Thing thing)
		{
			return await FilaaideDatabase.Database.SaveThing(thing);
		}

		public async Task<int> DeleteThing(Thing thing)
		{
			return await FilaaideDatabase.Database.DeleteThing(thing);
		}
	}
}