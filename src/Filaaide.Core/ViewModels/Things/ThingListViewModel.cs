using System.Linq;
using System.Threading.Tasks;
using Filaaide.Core.Services.DataService.Things;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Filaaide.Core.ViewModels.Things
{
	public class ThingListViewModel: BaseViewModel
	{
		private readonly IMvxNavigationService _navigationService;
		private readonly IThingDataService _thingDataService;

		public MvxObservableCollection<ThingThumbnailViewModel> Things { get; set; }

		public ThingListViewModel(IMvxNavigationService navigationService, IThingDataService thingDataService)
		{
			this._navigationService = navigationService;
			this._thingDataService = thingDataService;

			this.Things = new MvxObservableCollection<ThingThumbnailViewModel>();
		}

		public override async Task Initialize()
		{
			await base.Initialize();

			var things = await this._thingDataService.GetAllThings();

			if (things != null) {
				var thingThumbnails = things.Select(x => new ThingThumbnailViewModel(x, this._navigationService));
				this.Things.ReplaceWith(thingThumbnails);
			}
		}
	}
}