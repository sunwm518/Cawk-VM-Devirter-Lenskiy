using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lenskiy_Devirter
{
    
		public class ValueStack
		{
			// Token: 0x04000001 RID: 1
			public Stack<object> valueStack = new Stack<object>();

			// Token: 0x04000002 RID: 2
			public object[] locals;

			// Token: 0x04000003 RID: 3
			public Dictionary<FieldInfo, object> fields = new Dictionary<FieldInfo, object>();

			// Token: 0x04000004 RID: 4
			public object[] parameters;
		}
	
}
