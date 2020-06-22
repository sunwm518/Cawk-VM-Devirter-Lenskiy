namespace VMExample.Instructions
{
	internal class Clt : Base
	{
		public override void emu()
		{
			object obj = All.val.valueStack.Pop();
			object obj2 = All.val.valueStack.Pop();
			if ((int)obj2 < (int)obj)
			{
				All.val.valueStack.Push(1);
			}
			else
			{
				All.val.valueStack.Push(0);
			}
		}
	}
}
