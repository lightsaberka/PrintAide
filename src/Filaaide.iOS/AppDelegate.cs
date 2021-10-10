using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;

namespace Filaaide.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, UI.App>
    {
    }
}
