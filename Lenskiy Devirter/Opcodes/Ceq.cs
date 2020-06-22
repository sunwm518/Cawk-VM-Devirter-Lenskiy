namespace VMExample.Instructions
{
	internal class Ceq : Base
	{
		public override void emu()
		{
			object obj = All.val.valueStack.Pop();
			object obj2 = All.val.valueStack.Pop();
			All.val.valueStack.Push((obj == obj2) ? 1 : 0);
		}
	}
}
