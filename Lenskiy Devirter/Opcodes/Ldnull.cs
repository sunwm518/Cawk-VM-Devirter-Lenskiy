namespace VMExample.Instructions
{
	internal class Ldnull : Base
	{
		public override void emu()
		{
			All.val.valueStack.Push(null);
		}
	}
}
