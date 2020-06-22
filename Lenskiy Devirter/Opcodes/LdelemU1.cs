namespace VMExample.Instructions
{
	internal class LdelemU1 : Base
	{
		public override void emu()
		{
			object obj = All.val.valueStack.Pop();
			byte[] array = (byte[])All.val.valueStack.Pop();
			All.val.valueStack.Push(array[(int)obj]);
		}
	}
}
