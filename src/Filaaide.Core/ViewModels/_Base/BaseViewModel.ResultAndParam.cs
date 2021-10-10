using MvvmCross.ViewModels;

namespace Filaaide.Core.ViewModels._Base
{
    public abstract class BaseViewModel<TParameter, TResult> : BaseViewModelResult<TResult>, IMvxViewModel<TParameter, TResult>
        where TParameter : notnull
        where TResult : notnull
    {
        public abstract void Prepare(TParameter parameter);
    }
}
