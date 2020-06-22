namespace VMExample.Instructions
{
	using Lenskiy_Devirter;

	internal class Ldarg : Base
	{
		public override void emu()
		{
			int num = Program.binr.ReadInt32();
			All.val.valueStack.Push(All.val.parameters[num]);
		}
	}
}
