using System.Collections.Generic;
using System.Threading.Tasks;
using Filaaide.Core.Model;
using Filaaide.Core.Services.Repository;

namespace Filaaide.Core.Services.DataService.Filaments
{
	public class FilamentDataService: IFilamentDataService
	{
		public async Task<List<Filament>> GetAllFilaments()
		{
			return await FilaaideDatabase.Database.GetAllFilaments();
		}

		public async Task<Filament> GetFilamentById(int id)
		{
			return await FilaaideDatabase.Database.GetFilamentById(id);
		}

		public async Task<int> SaveFilament(Filament filament)
		{
			return await FilaaideDatabase.Database.SaveFilament(filament);
		}

		public async Task<int> DeleteFilament(Filament filament)
		{
			return await FilaaideDatabase.Database.DeleteFilament(filament);
		}
	}
}