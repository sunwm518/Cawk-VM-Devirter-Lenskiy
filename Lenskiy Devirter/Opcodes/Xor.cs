using System;

namespace VMExample.Instructions
{
	internal class Xor : Base
	{
		public override void emu()
		{
			object obj = All.val.valueStack.Pop();
			object value = All.val.valueStack.Pop();
			int num = Convert.ToByte(value) ^ (int)obj;
			All.val.valueStack.Push(num);
		}
	}
}
