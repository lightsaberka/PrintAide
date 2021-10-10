using System.Collections.Generic;
using System.Threading.Tasks;
using Filaaide.Core.Model;

namespace Filaaide.Core.Services.DataService.Things
{
	public interface IThingDataService
	{
		/// <summary>
		/// Return all things.
		/// </summary>
		/// <returns></returns>
		Task<List<Thing>> GetAllThings();

		/// <summary>
		/// Return all things made by filament with given id.
		/// </summary>
		/// /// <param name="id">Filamnet id</param>
		/// <returns></returns>
		Task<List<Thing>> GetThingsByFilamentId(int id);

		/// <summary>
		/// Return thing with given id.
		/// </summary>
		/// <param name="id">Thing id</param>
		/// <returns></returns>
		Task<Thing> GetThingById(int id);

		/// <summary>
		/// Add or update given thing.
		/// </summary>
		/// <param name="thing">Thing to add or update</param>
		/// <returns>Thing id</returns>
		Task<int> SaveThing(Thing thing);

		/// <summary>
		/// Delete given thing.
		/// </summary>
		/// <param name="thing">Thing to delete</param>
		/// <returns>Thing id</returns>
		Task<int> DeleteThing(Thing thing);
	}
}