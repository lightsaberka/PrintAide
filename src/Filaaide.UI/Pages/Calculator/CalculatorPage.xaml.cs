using Filaaide.Core.ViewModels.Calculator;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Filaaide.UI.Pages.Calculator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[MvxTabbedPagePresentation(WrapInNavigationPage = false, Title = "Calculator")]
	public partial class CalculatorPage : MvxContentPage<CalculatorViewModel>
	{
		public CalculatorPage()
		{
			this.InitializeComponent();
		}
	}
}