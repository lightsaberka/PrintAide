using System.Threading.Tasks;
using Filaaide.Core.Model;

namespace Filaaide.Core.ViewModels.Filaments
{
	public class FilamentEditViewModel: BaseViewModel<Filament>
	{
		public Filament CurrentFilament {get;set;}
		public override void Prepare(Filament parameter)
		{
			this.CurrentFilament = parameter;
		}

		public override async Task Initialize()
		{
			await base.Initialize();

			if (this.CurrentFilament == null) {
				this.CurrentFilament = new Filament();
			}
		}
	}
}