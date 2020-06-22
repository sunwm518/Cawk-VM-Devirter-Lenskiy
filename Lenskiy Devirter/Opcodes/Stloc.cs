namespace VMExample.Instructions

{
	using Lenskiy_Devirter;

	internal class Stloc : Base
	{
		public override void emu()
		{
			object obj = All.val.valueStack.Pop();
			int num = Program.binr.ReadInt32();
			All.val.locals[num] = obj;
		}
	}
}
