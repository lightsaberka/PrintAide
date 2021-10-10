using Filaaide.Core.ViewModels.Things;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Filaaide.UI.Pages.Things
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[MvxTabbedPagePresentation(WrapInNavigationPage = false, Title = "All things")]
	public partial class ThingListPage : MvxContentPage<ThingListViewModel>
	{
		public ThingListPage()
		{
			this.InitializeComponent();
		}
	}
}