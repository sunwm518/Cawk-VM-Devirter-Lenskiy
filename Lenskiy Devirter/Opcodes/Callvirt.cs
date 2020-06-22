using System;
using System.Collections.Generic;
using System.Reflection;

namespace VMExample.Instructions
{
	using Lenskiy_Devirter;

	internal class Callvirt : Base
	{
		public static Dictionary<int, MethodBase> cache = new Dictionary<int, MethodBase>();

		public override void emu()
		{
			int num = Program.binr.ReadInt32();
			object[] array = new object[2];
			for (int num2 = array.Length; num2 > 0; num2--)
			{
				array[num2 - 1] = All.val.valueStack.Pop();
			}
			Random random = (Random)All.val.valueStack.Pop();
			int num3 = random.Next(0, 250);
			All.val.valueStack.Push(num3);
		}
	}
}
