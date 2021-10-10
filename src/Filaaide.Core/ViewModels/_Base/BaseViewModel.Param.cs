using MvvmCross.ViewModels;

namespace Filaaide.Core.ViewModels._Base
{
    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
        where TParameter : notnull
    {
        public abstract void Prepare(TParameter parameter);
    }
}
