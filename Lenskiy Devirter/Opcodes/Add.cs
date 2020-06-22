namespace VMExample.Instructions
{
	internal class Add : Base
	{
		public override void emu()
		{
			object obj = All.val.valueStack.Pop();
			object obj2 = All.val.valueStack.Pop();
			All.val.valueStack.Push((int)obj2 + (int)obj);
		}
	}
}
