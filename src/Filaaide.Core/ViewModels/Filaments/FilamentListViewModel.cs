using MvvmCross.Navigation;

namespace Filaaide.Core.ViewModels.Filaments
{
	public class FilamentListViewModel: BaseViewModel
	{
		private readonly IMvxNavigationService _navigationService;

		public FilamentListViewModel(IMvxNavigationService navigationService)
		{
			this._navigationService = navigationService;
		}
	}
}