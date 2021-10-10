using System.Threading.Tasks;
using MvvmCross.ViewModels;

namespace Filaaide.Core.ViewModels
{
    public abstract class BaseViewModelResult<TResult> : BaseViewModel, IMvxViewModelResult<TResult>
        where TResult : notnull
    {
        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public override void ViewDestroy(bool viewFinishing = true)
        {
	        if (viewFinishing && this.CloseCompletionSource?.Task.IsCompleted == false && !this.CloseCompletionSource.Task.IsFaulted) {
		        this.CloseCompletionSource?.TrySetCanceled();
	        }

            base.ViewDestroy(viewFinishing);
        }
    }
}
