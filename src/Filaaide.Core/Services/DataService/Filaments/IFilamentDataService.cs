using System.Collections.Generic;
using System.Threading.Tasks;
using Filaaide.Core.Model;

namespace Filaaide.Core.Services.DataService.Filaments
{
	public interface IFilamentDataService
	{
		/// <summary>
		/// Return all filaments.
		/// </summary>
		/// <returns></returns>
		Task<List<Filament>> GetAllFilaments();

		/// <summary>
		/// Return filament with given id.
		/// </summary>
		/// <param name="id">Filament id</param>
		/// <returns></returns>
		Task<Filament> GetFilamentById(int id);
		
		/// <summary>
		/// Add or Update given filament.
		/// </summary>
		/// <param name="filament">Filament to add or update</param>
		/// <returns>Filament id</returns>
		Task<int> SaveFilament(Filament filament);

		/// <summary>
		/// Delete given filament.
		/// </summary>
		/// <param name="filament">Filament to delete</param>
		/// <returns>Filament id</returns>
		Task<int> DeleteFilament(Filament filament);
	}
}