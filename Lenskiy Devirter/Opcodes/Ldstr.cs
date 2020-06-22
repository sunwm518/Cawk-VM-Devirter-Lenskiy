using Lenskiy_Devirter;

namespace VMExample.Instructions
{
	internal class Ldstr : Base
	{
		public override void emu()
		{
			string item = Program.binr.ReadString();
			All.val.valueStack.Push(item);
		}
	}
}
