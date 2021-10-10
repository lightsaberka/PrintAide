using Filaaide.Core.Utilities;
using MvvmCross.ViewModels;
using MvvmValidation;

namespace Filaaide.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
	    /// <summary>
	    /// Validator for input validation.
	    /// </summary>
	    protected ValidationHelper Validator { get; private set; }

		/// <summary>
		/// Error messages for incorrect inputs.
		/// </summary>
		public ObservableDictionary<string, string> Errors { get; protected set; }

		protected BaseViewModel()
		{
			this.Validator = new ValidationHelper();
		}
    }
}
