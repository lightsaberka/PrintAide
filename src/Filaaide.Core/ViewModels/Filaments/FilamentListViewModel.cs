using System.Linq;
using System.Threading.Tasks;
using Filaaide.Core.Model;
using Filaaide.Core.Services.DataService.Filaments;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Filaaide.Core.ViewModels.Filaments
{
	public class FilamentListViewModel: BaseViewModel
	{
		private readonly IMvxNavigationService _navigationService;
		private readonly IFilamentDataService _filamentDataService;

		public MvxObservableCollection<FilamentThumbnailViewModel> Filaments { get; set; }

		public FilamentListViewModel(IMvxNavigationService navigationService, IFilamentDataService filamentDataService)
		{
			this._navigationService = navigationService;
			this._filamentDataService = filamentDataService;

			this.Filaments = new MvxObservableCollection<FilamentThumbnailViewModel>();
		}

		public override async Task Initialize()
		{
			await base.Initialize();

			var filaments = await this._filamentDataService.GetAllFilaments();

			if (filaments != null) {
				var filamentThumbnails = filaments.Select(x => new FilamentThumbnailViewModel(x, this._navigationService));
				this.Filaments.ReplaceWith(filamentThumbnails);
			}
		}
	}
}