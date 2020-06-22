using System;

namespace VMExample.Instructions
{
	internal class ConvU1 : Base
	{
		public override void emu()
		{
			object value = All.val.valueStack.Pop();
			byte b = Convert.ToByte(value);
			All.val.valueStack.Push((int)b);
		}
	}
}
