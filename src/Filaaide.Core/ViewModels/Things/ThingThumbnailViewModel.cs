using Filaaide.Core.Model;
using MvvmCross.Navigation;

namespace Filaaide.Core.ViewModels.Things
{
	public class ThingThumbnailViewModel: BaseViewModel
	{
		private readonly IMvxNavigationService _navigationService;

		public Thing CurrentThing { get; set; }

		public ThingThumbnailViewModel(Thing thing, IMvxNavigationService navigationService)
		{
			this.CurrentThing = thing;
			this._navigationService = navigationService;
		}
	}
}