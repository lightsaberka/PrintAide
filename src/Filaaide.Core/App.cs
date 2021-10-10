using Filaaide.Core.ViewModels.Tabs;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace Filaaide.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
	        this.CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

	        this.RegisterAppStart<TabsRootViewModel>();

	        Device.SetFlags(new string[] { "CarouselView_Experimental" });
        }
    }
}
