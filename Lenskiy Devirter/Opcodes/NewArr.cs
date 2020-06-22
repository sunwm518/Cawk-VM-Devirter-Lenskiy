namespace VMExample.Instructions
{
	internal class NewArr : Base
	{
		public override void emu()
		{
			object obj = All.val.valueStack.Pop();
			All.val.valueStack.Push(new byte[(int)obj]);
		}
	}
}
