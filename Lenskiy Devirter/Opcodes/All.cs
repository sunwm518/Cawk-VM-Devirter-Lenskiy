using Lenskiy_Devirter;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace VMExample.Instructions
{
	public class All
	{

		public static Base[] tester2 = new Base[25]
		{
			new Ldstr(),
			new Call(),
			new Pop(),
			new Ldarg(),
			new Ldlen(),
			new ConvI4(),
			new Ceq(),
			new Ldc(),
			new Stloc(),
			new Ldloc(),
			new Brfalse(),
			new Ldnull(),
			new Br(),
			new NewArr(),
			new LdelemU1(),
			new Xor(),
			new ConvU1(),
			new StelemI1(),
			new Add(),
			new Clt(),
			new Brtrue(),
			new Rem(),
			new Nop(),
			new NewObj(),
			new Callvirt()
		};




		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool VirtualProtect(IntPtr lpAddress, IntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string dllToLoad);

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

		public static bool tester()
		{
			return false;
		}
		public static ValueStack val;

		public static void run(BinaryReader binr)
		{
			
			for (; ; )
			{
				byte b = binr.ReadByte();
				bool flag2 = b == byte.MaxValue;
				if (flag2)
				{
					break;
				}
				All.tester2[(int)b].emu();
			}
		}
	}
}
