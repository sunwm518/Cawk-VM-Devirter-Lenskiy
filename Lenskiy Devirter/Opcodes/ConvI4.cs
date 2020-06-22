namespace VMExample.Instructions
{
	internal class ConvI4 : Base
	{
		public override void emu()
		{
			object obj = All.val.valueStack.Pop();
			All.val.valueStack.Push((int)obj);
		}
	}
}
