namespace VMExample.Instructions
{
	internal class Ldlen : Base
	{
		public override void emu()
		{
			byte[] array = (byte[])All.val.valueStack.Pop();
			All.val.valueStack.Push(array.Length);
		}
	}
}
