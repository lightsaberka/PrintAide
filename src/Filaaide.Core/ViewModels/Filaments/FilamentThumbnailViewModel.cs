using Filaaide.Core.Model;
using MvvmCross.Navigation;

namespace Filaaide.Core.ViewModels.Filaments
{
	public class FilamentThumbnailViewModel : BaseViewModel
	{
		private readonly IMvxNavigationService _navigationService;

		public Filament CurrentFilament { get; set; }

		public FilamentThumbnailViewModel(Filament filament, IMvxNavigationService navigationService)
		{
			this.CurrentFilament = filament;
			this._navigationService = navigationService;
		}
	}
}