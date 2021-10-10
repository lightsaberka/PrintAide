using Filaaide.Core.Services.Repository;
using Filaaide.Core.ViewModels.Tabs;
using MvvmCross;
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

			Mvx.IoCProvider.RegisterSingleton(() => FilaaideDatabase.Database);

	        this.RegisterAppStart<TabsRootViewModel>();

	        Device.SetFlags(new string[] { "CarouselView_Experimental" });
        }
    }
}
