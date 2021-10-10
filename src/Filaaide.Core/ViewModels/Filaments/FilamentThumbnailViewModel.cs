using Filaaide.Core.Model;

namespace Filaaide.Core.ViewModels.Filaments
{
	public class FilamentThumbnailViewModel: BaseViewModel<Filament>
	{
		public Filament CurrentFilament { get; set; }

		public override void Prepare(Filament parameter)
		{
			this.CurrentFilament = parameter;
		}
	}
}