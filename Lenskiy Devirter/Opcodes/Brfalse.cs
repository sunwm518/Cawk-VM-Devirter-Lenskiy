using Lenskiy_Devirter;

namespace VMExample.Instructions
{
	internal class Brfalse : Base
	{
		public override void emu()
		{
			int num = Program.binr.ReadInt32();
			object obj = All.val.valueStack.Pop();
			if ((int)obj == 0)
			{
				Program.binr.BaseStream.Position = num;
			}
		}
	}
}
