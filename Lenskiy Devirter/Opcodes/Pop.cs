namespace VMExample.Instructions
{
	internal class Pop : Base
	{
		public override void emu()
		{
			object obj = All.val.valueStack.Pop();
		}
	}
}
