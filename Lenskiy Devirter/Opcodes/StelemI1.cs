using System;

namespace VMExample.Instructions
{
	internal class StelemI1 : Base
	{
		public override void emu()
		{
			object value = All.val.valueStack.Pop();
			object value2 = All.val.valueStack.Pop();
			byte[] array = (byte[])All.val.valueStack.Pop();
			array[Convert.ToInt32(value2)] = Convert.ToByte(Convert.ToInt32(value));
		}
	}
}
