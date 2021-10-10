using System.Collections.Generic;
using System.Threading.Tasks;
using Filaaide.Core.Model;

namespace Filaaide.Core.Services.DataService.Things
{
	public interface IThingDataService
	{
		/// <summary>
		/// Returns all things.
		/// </summary>
		/// <returns></returns>
		Task<List<Thing>> GetAllThings();

		/// <summary>
		/// Returns all things made by filament with given id.
		/// </summary>
		/// /// <param name="id">Filamnet id</param>
		/// <returns></returns>
		Task<List<Thing>> GetThingsByFilamentId(int id);

		/// <summary>
		/// Returns thing with given id.
		/// </summary>
		/// <param name="id">Thing id</param>
		/// <returns></returns>
		Task<Thing> GetFilamentById(int id);

		/// <summary>
		/// Adds new thing.
		/// </summary>
		/// <param name="thing">Thing to add</param>
		/// <returns></returns>
		Task<Thing> AddNewThing(Thing thing);

		/// <summary>
		/// Update given thing.
		/// </summary>
		/// <param name="thing">Thing to update</param>
		/// <returns></returns>
		Task<Thing> UpdateThing(Thing thing);

		/// <summary>
		/// Delete given thing.
		/// </summary>
		/// <param name="thing">Thing to delete</param>
		/// <returns></returns>
		Task<Thing> DeleteThing(Thing thing);
	}
}