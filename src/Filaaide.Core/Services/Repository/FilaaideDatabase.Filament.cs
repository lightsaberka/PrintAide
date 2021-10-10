using System.Collections.Generic;
using System.Threading.Tasks;
using Filaaide.Core.Model;

namespace Filaaide.Core.Services.Repository
{
	public partial class FilaaideDatabase
	{
		public Task<List<Filament>> GetAllFilaments()
		{
			return this._connection.Table<Filament>().ToListAsync();
		}

		public Task<Filament> GetFilamentById(int id)
		{
			return this._connection.Table<Filament>().Where(i => i.Id == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveFilament(Filament filament)
		{
			if (filament.Id != 0) {
				return this._connection.UpdateAsync(filament);
			} else {
				return this._connection.InsertAsync(filament);
			}
		}

		public Task<int> DeleteFilament(Filament filament)
		{
			return this._connection.DeleteAsync(filament);
		}
	}
}