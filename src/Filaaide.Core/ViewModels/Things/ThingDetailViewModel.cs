using Filaaide.Core.Model;

namespace Filaaide.Core.ViewModels.Things
{
	public class ThingDetailViewModel: BaseViewModel<Thing>
	{
		public Thing CurrentThing { get; set; }

		public override void Prepare(Thing parameter)
		{
			this.CurrentThing = parameter;
		}
	}
}