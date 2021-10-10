using System.Collections.Generic;
using System.Threading.Tasks;
using Filaaide.Core.Model;

namespace Filaaide.Core.Services.DataService.Filaments
{
	public interface IFilamentDataService
	{
		/// <summary>
		/// Returns all filaments.
		/// </summary>
		/// <returns></returns>
		Task<List<Filament>> GetAllFilaments();

		/// <summary>
		/// Returns filament with given id.
		/// </summary>
		/// <param name="id">Filament id</param>
		/// <returns></returns>
		Task<Filament> GetFilamentById(int id);

		/// <summary>
		/// Adds new filament.
		/// </summary>
		/// <param name="filament">Filament to add</param>
		/// <returns></returns>
		Task<Filament> AddNewFilament(Filament filament);

		/// <summary>
		/// Update given filament.
		/// </summary>
		/// <param name="filament">Filament to update</param>
		/// <returns></returns>
		Task<Filament> UpdateFilament(Filament filament);

		/// <summary>
		/// Delete given filament.
		/// </summary>
		/// <param name="filament">Filament to delete</param>
		/// <returns></returns>
		Task<Filament> DeleteFilament(Filament filament);
	}
}