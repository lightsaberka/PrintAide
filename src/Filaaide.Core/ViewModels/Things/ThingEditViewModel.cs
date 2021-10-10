using System.Threading.Tasks;
using Filaaide.Core.Model;
using MvvmCross.Navigation;

namespace Filaaide.Core.ViewModels.Things
{
	public class ThingEditViewModel: BaseViewModel<Thing>
	{
		private readonly IMvxNavigationService _navigationService;

		/// <summary>
		/// Currently creating or editing thing.
		/// </summary>
		public Thing CurrentThing { get; set; }

		public ThingEditViewModel(IMvxNavigationService navigationService)
		{
			this._navigationService = navigationService;
		}

		public override void Prepare(Thing parameter)
		{
			this.CurrentThing = parameter;
		}

		public override async Task Initialize()
		{
			await base.Initialize();

			if (this.CurrentThing == null) {
				this.CurrentThing = new Thing();
			}
		}
	}
}