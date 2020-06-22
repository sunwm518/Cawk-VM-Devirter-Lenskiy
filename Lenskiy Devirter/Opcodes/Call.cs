using Lenskiy_Devirter;
using System.Reflection;

namespace VMExample.Instructions
{
	internal class Call : Base
	{

		public override void emu()
		{
			int metadataToken = Program.binr.ReadInt32();
			MethodBase methodBase = Program.mod.ResolveMethod(metadataToken);
			if (methodBase.IsStatic)
			{
				object[] array = new object[methodBase.GetParameters().Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = All.val.valueStack.Pop();
				}
				if (!((MethodInfo)methodBase).ReturnType.ToString().Contains("System.Void"))
				{
					All.val.valueStack.Push(methodBase.Invoke(null, array));
				}
				else
				{
					methodBase.Invoke(null, array);
				}
			}
		}
	}
}
