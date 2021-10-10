using Filaaide.Core.ViewModels.Tabs;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Filaaide.UI.Pages
{
	[MvxTabbedPagePresentation(TabbedPosition.Root, NoHistory = true)]
	public partial class TabsRootPage : MvxTabbedPage<TabsRootViewModel>
	{
		public TabsRootPage()
		{
			this.InitializeComponent();
		}

		private bool _firstTime = true;

		protected override void OnAppearing()
		{
			base.OnAppearing();

			// set tabs on Android to the bottom
			this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

			// disable swiping tabs on Android
			this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);

			if (this._firstTime) {
				this.ViewModel.ShowTabsCommand.ExecuteAsync(null);
				this._firstTime = false;
			}
		}
	}
}