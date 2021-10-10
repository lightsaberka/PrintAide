using Acr.UserDialogs;
using Android.App;
using Android.OS;
using Filaaide.Core.ViewModels.Main;
using MvvmCross.Forms.Platforms.Android.Views;

namespace Filaaide.Droid.Views
{
    [Activity(Theme = "@style/AppTheme")]
    public class MainActivity : MvxFormsAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            UserDialogs.Init(this);
        }
    }
}
