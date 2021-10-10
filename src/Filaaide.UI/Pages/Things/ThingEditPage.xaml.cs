using Filaaide.Core.ViewModels.Things;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Filaaide.UI.Pages.Things
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[MvxTabbedPagePresentation(WrapInNavigationPage = false, Title = "Add thing")]
	public partial class ThingEditPage : MvxContentPage<ThingEditViewModel>
	{
		public ThingEditPage()
		{
			this.InitializeComponent();
		}
	}
}