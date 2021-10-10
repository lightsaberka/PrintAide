using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Filaaide.Core.ViewModels.Filaments;
using Filaaide.Core.ViewModels.Things;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Filaaide.Core.ViewModels.Tabs
{
	/// <summary>
	/// Covers entire bottom tabs navigation.
	/// </summary>
	public class TabsRootViewModel: BaseViewModel
	{
		private readonly IMvxNavigationService _navigationService;

		/// <summary>
		/// List of tabs.
		/// </summary>
		public List<Type> AllTabs { get; }

		public IMvxAsyncCommand ShowTabsCommand { get; }

		public TabsRootViewModel(IMvxNavigationService navigationService)
		{
			this._navigationService = navigationService;

			this.AllTabs = new List<Type>
			{
				typeof(FilamentListViewModel),
				typeof(ThingEditViewModel)
			};

			this.ShowTabsCommand = new MvxAsyncCommand(this.InitializeTabs);
		}

		/// <summary>
		/// Initialize tabs for navigation.
		/// </summary>
		public Task InitializeTabs()
		{
			var tasks = new List<Task>();

			foreach (var tab in this.AllTabs) {
				tasks.Add(this._navigationService.Navigate(tab));
			}
			return Task.WhenAll(tasks);
		}
	}
}