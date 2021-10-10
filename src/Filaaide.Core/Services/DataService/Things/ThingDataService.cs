using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filaaide.Core.Model;

namespace Filaaide.Core.Services.DataService.Things
{
	public class ThingDataService: IThingDataService
	{
		public Task<List<Thing>> GetAllThings()
		{
			throw new System.NotImplementedException();
		}

		public async Task<List<Thing>> GetThingsByFilamentId(int id)
		{
			var allThings = await this.GetAllThings();
			return allThings.Where(t => t.FilamentId == id).ToList();
		}

		public Task<Thing> GetFilamentById(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<Thing> AddNewThing(Thing thing)
		{
			throw new System.NotImplementedException();
		}

		public Task<Thing> UpdateThing(Thing thing)
		{
			throw new System.NotImplementedException();
		}

		public Task<Thing> DeleteThing(Thing thing)
		{
			throw new System.NotImplementedException();
		}
	}
}