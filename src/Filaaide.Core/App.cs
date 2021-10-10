using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Filaaide.Core.ViewModels.Home;

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

	        this.RegisterAppStart<HomeViewModel>();
        }
    }
}
