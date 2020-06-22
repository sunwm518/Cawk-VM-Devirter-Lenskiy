using Lenskiy_Devirter;

namespace VMExample.Instructions
{
	internal class Br : Base
	{
		public override void emu()
		{
			int num = Program.binr.ReadInt32();
			Program.binr.BaseStream.Position = num;
		}
	}
}
