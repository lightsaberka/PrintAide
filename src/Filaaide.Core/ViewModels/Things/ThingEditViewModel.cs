using System.Threading.Tasks;
using Filaaide.Core.Model;
using Filaaide.Core.Services.DataService.Things;
using Filaaide.Core.Utilities;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmValidation;

namespace Filaaide.Core.ViewModels.Things
{
	public class ThingEditViewModel : BaseViewModel<Thing>
	{
		private readonly IMvxNavigationService _navigationService;
		private readonly IThingDataService _thingDataService;

		private IMvxAsyncCommand _saveCommand;
		private IMvxAsyncCommand _deleteCommand;

		/// <summary>
		/// Currently creating or editing thing.
		/// </summary>
		public Thing CurrentThing { get; set; }

		public ThingEditViewModel(IMvxNavigationService navigationService, IThingDataService thingDataService)
		{
			this._navigationService = navigationService;
			this._thingDataService = thingDataService;
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

		public IMvxAsyncCommand SaveCommand
		{
			get {
				if (this._saveCommand == null) {
					this._saveCommand = new MvxAsyncCommand(async () => {

						if (this.Validate()) {
							await this._thingDataService.SaveThing(this.CurrentThing);
						}
					});
				}
				return this._saveCommand;
			}
		}

		public IMvxAsyncCommand DeleteCommand
		{
			get {
				if (this._deleteCommand == null) {
					this._deleteCommand = new MvxAsyncCommand(async () => {

						await this._thingDataService.DeleteThing(this.CurrentThing);
						await this._navigationService.Close(this);
					});
				}
				return this._deleteCommand;
			}
		}

		/// <summary>
		/// Validate user input.
		/// </summary>
		/// <returns></returns>
		private bool Validate()
		{
			this.Validator.AddRule(nameof(this.CurrentThing.Name), () => RuleResult.Assert(!string.IsNullOrEmpty(this.CurrentThing.Name), "Name cannot be empty."));
			this.Validator.AddRule(nameof(this.CurrentThing.Weight), () => RuleResult.Assert(this.CurrentThing.Weight > 0, "Weight cannot be 0."));

			var result = this.Validator.ValidateAll();
			this.Errors = result.AsObservableDictionary();
			this.RaisePropertyChanged(() => this.Errors);

			return result.IsValid;
		}
	}
}