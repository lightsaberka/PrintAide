using Filaaide.Core.ViewModels.Filaments;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Filaaide.UI.Pages.Filaments
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[MvxTabbedPagePresentation(WrapInNavigationPage = false, Title = "My filaments")]
	public partial class FilamentListPage : MvxContentPage<FilamentListViewModel>
	{
		public FilamentListPage()
		{
			this.InitializeComponent();
		}
	}
}