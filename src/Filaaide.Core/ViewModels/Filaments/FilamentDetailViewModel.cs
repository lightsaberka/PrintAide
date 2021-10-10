using Filaaide.Core.Model;
using MvvmCross.Navigation;

namespace Filaaide.Core.ViewModels.Filaments
{
	public class FilamentDetailViewModel: BaseViewModel<Filament>
	{
		private readonly IMvxNavigationService _navigationService;

		/// <summary>
		/// Currently shown filament.
		/// </summary>
		public Filament CurrentFilament { get; set; }

		public FilamentDetailViewModel(IMvxNavigationService navigationService)
		{
			this._navigationService = navigationService;
		}

		public override void Prepare(Filament parameter)
		{
			this.CurrentFilament = parameter;
		}
	}
}