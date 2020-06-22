using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lenskiy_Devirter
{
    class Inisialize
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true)]
        public static extern IntPtr e(IntPtr intptr, string str);
        public static Inisialize.a bc;

        // Token: 0x02000023 RID: 35
        // (Invoke) Token: 0x06000067 RID: 103
        public delegate void a(byte[] bytes, int len, byte[] key, int keylen);
    }
}
