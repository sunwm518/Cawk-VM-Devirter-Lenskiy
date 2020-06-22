using dnlib.DotNet;
using dnlib.DotNet.Writer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using Vestris.ResourceLib;

using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VMExample.Instructions;

namespace Lenskiy_Devirter
{
    
    /////////////////////////////////////////////////////////Cawk Vm Devirter/////////////////////////////////////////////////////////////////////
    /// //////////////////////////////Coddded By Lord_Lenskiy////////////////////////For In4.Bz Club♥/////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////Девиртер Слегка Сырой, не поддерживает многие опкоды, не бейте плиз((((((//////
    class Program
    {
        public static Module mod;
        public static byte[] byteArrayResource;
       public static ModuleDefMD module;
        public static BinaryReader binr;

        static void Main(string[] args)
        {
           module = ModuleDefMD.Load(args[0]);
            AssemblyName assemblyName = AssemblyName.GetAssemblyName(args[0]);
            Assembly assembly = Assembly.Load(assemblyName);
            Module Module_L = assembly.GetModules()[0];
            mod = Module_L;
            foreach (EmbeddedResource res in module.Resources)
            {
                if (res.Name == "Eddy^CZ_")
                {
                    using (new StreamReader(res.GetResourceStream()))
                    {
                        byte[] ar = new byte[res.GetResourceStream().Length];
                        res.GetResourceStream().Read(ar, 0, ar.Length);
                        byteArrayResource = ar;
                    }
                }

            }
        

            byte[] buffer = null;

            foreach (EmbeddedResource res in module.Resources)
            {
                if (res.Name == "Eddy^CZ")
                {
                   
                        using (new StreamReader(res.GetResourceStream()))
                        {
                            byte[] arr = new byte[res.GetResourceStream().Length];
                        res.GetResourceStream().Read(arr, 0, arr.Length);
                            buffer = arr;
                        }
                    
                }
            }

            binr = new BinaryReader(new MemoryStream(buffer));
            All.val = new ValueStack();
            All.val.parameters = new object[1];
            All.val.parameters[0] = byteArrayResource;
            All.val.locals = new object[10];
            All.run(binr);



            bool flag = IntPtr.Size == 4;
            IntPtr ptr = default(IntPtr);
            if (flag)
            {



                ExtractEmbeddedDlls("NativePRo.dll", File.ReadAllBytes(Directory.GetCurrentDirectory()+"\\X86"));

                IntPtr intptr = LoadDll("NativePRo.dll");
                            ptr = Inisialize.e(intptr, "_a@16");

                

                
            }
            else
            {

                ExtractEmbeddedDlls("NativePRo.dll", File.ReadAllBytes("X64"));

                IntPtr intptr = LoadDll("NativePRo.dll");
                ptr = Inisialize.e(intptr, "a");


            }
            Inisialize.bc = (Inisialize.a)Marshal.GetDelegateForFunctionPointer(ptr, typeof(Inisialize.a));
            byteArrayResource = (byte[])All.val.locals[1];





            OpCode[] array = new OpCode[256];
            OpCode[] array2 = new OpCode[256];
            oneByteOpCodes = array;
            twoByteOpCodes = array2;
            Type typeFromHandle = typeof(OpCode);
            Type typeFromHandle2 = typeof(OpCodes);
            foreach (FieldInfo fieldInfo in typeFromHandle2.GetFields())
            {
                bool flag2 = fieldInfo.FieldType == typeFromHandle;
                if (flag2)
                {
                    OpCode opCode = (OpCode)fieldInfo.GetValue(null);
                    ushort num = (ushort)opCode.Value;
                    bool flag3 = opCode.Size == 1;
                    if (flag3)
                    {
                        byte b = (byte)num;
                       oneByteOpCodes[(int)b] = opCode;
                       // Console.WriteLine(opCode.Name);
                    }
                    else
                    {
                        byte b2 = (byte)(num | 65024);
                      twoByteOpCodes[(int)b2] = opCode;
                        //Console.WriteLine(opCode.Name);
                    }
                }
            }





            foreach (var type in module.Types)
            {
                try
                {
                    foreach (var method in type.Methods)
                    {
                        try
                        {
                            if (is_virualized(method))
                            {
                                List<dnlib.DotNet.Emit.Instruction> real = new List<dnlib.DotNet.Emit.Instruction>();
                                for (int i = 0; i < method.Body.Instructions.Count; i++)
                                {
                                    try
                                    {
                                        if (method.Body.Instructions[i].OpCode == dnlib.DotNet.Emit.OpCodes.Call)
                                        {
                                            if (method.Body.Instructions[i].Operand.ToString().Contains("Runner"))
                                            {

                                                #region Resolve Method
                                                int md = (int)((MethodDef)method).MDToken.Raw;
                                                MethodBase callingMethod = Module_L.ResolveMethod(md);
                                                dnlib.DotNet.Emit.Instruction instr = new dnlib.DotNet.Emit.Instruction();
                                                #endregion

                                                #region Параметры
                                                int position = method.Body.Instructions[i-4].GetLdcI4Value();
                                                int size = method.Body.Instructions[i - 3].GetLdcI4Value();
                                                int ID = method.Body.Instructions[i - 2].GetLdcI4Value();
                                                Console.WriteLine("Recovering Method - " + method.FullName + "_Keys --_--" + position.ToString() + "--_--" + size.ToString() + "--_--" + ID.ToString());
                                                #endregion

                                                #region Расшифровка Опкодов
                                                byte[] array4 = byteArrayGrabber(byteArrayResource, position, size);
                                                byte[] key = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(method.Name));
                                                byte[] ilasByteArray = callingMethod.GetMethodBody().GetILAsByteArray();
                                                Inisialize.bc(array4, array4.Length, ilasByteArray, ilasByteArray.Length);
                                                byte[] bytes = Decrypt(key, array4);
                                                #endregion

                                                #region Получение Опкодов из Ресурсов
                                                System.Reflection.MethodBody methodBody = callingMethod.GetMethodBody();
                                                BinaryReader binaryReader = new BinaryReader(new MemoryStream(bytes));
                                                ParameterInfo[] parameters2 = callingMethod.GetParameters();
                                                List<LocalBuilder> list = new List<LocalBuilder>();
                                                int num = 0;
                                                bool isStatic = callingMethod.IsStatic;
                                                Type[] array5;
                                                if (isStatic)
                                                {
                                                    array5 = new Type[parameters2.Length];
                                                }
                                                else
                                                {
                                                    array5 = new Type[parameters2.Length + 1];
                                                    array5[0] = callingMethod.DeclaringType;
                                                    num = 1;
                                                }
                                                for (int z = 0; z < parameters2.Length; z++)
                                                {
                                                    ParameterInfo parameterInfo = parameters2[z];
                                                    array5[num + z] = parameterInfo.ParameterType;
                                                }

                                                DynamicMethod dynamicMethod = new DynamicMethod("", (callingMethod.MemberType == MemberTypes.Constructor) ? null : ((MethodInfo)callingMethod).ReturnParameter.ParameterType, array5, Module_L, true);
                                                ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
                                                IList<LocalVariableInfo> localVariables = methodBody.LocalVariables;
                                                foreach (LocalVariableInfo localVariableInfo in localVariables)
                                                {
                                                    list.Add(ilgenerator.DeclareLocal(localVariableInfo.LocalType));
                                                }
                                                int count = binaryReader.ReadInt32();

                                                int num2 = binaryReader.ReadInt32();
                                                Dictionary<int, Label> dictionary = new Dictionary<int, Label>();
                                                for (int j = 0; j < num2; j++)
                                                {
                                                    Label value = ilgenerator.DefineLabel();
                                                    dictionary.Add(j, value);
                                                }

                                                for (int k = 0; k < num2; k++)
                                                {
                                                    short num3 = binaryReader.ReadInt16();
                                                    bool flags = num3 >= 0 && (int)num3 < oneByteOpCodes.Length;
                                                    OpCode opcode;
                                                    if (flags)
                                                    {
                                                        opcode = oneByteOpCodes[(int)num3];
                                                    }
                                                    else
                                                    {
                                                        byte b = (byte)((int)num3 | 65024);
                                                        opcode = twoByteOpCodes[(int)b];
                                                    }
                                                    #endregion


                                                    byte opType = binaryReader.ReadByte();
                                                    object a = OperandInitialiser.Initialise(opType, binaryReader, assembly.GetModules()[0], dictionary, list);
                                                    try
                                                    {
                                                        real.Add(OpcodeConverter.converter(opcode, a, binaryReader, assembly.GetModules()[0]));
                                                    }
                                                    catch
                                                    {

                                                    }

                                               

                                                  
                                                      
                                                    
                                                 
                                                   

                                                }







                                            
                                            }
                                        }
                                    }
                                    catch(Exception ex)
                                    {
                                    }
                                }
                                method.Body.Instructions.Clear();
                                foreach(var fes in real)
                                {
                                    method.Body.Instructions.Add(fes);

                                }
                            }
                        }
                        catch(Exception ex)
                        {
                        }
                    }
                }
                catch
                {

                }
            }












                    module.Write("lsd.exe", new ModuleWriterOptions(module)
            {
                MetaDataOptions =
                {
                    Flags = MetaDataFlags.PreserveAll
                },
                Logger = DummyLogger.NoThrowInstance
            });

        
            Console.WriteLine("=================================");
            Console.ReadLine();
        }


        public static void ExtractEmbeddedDlls(string dllName, byte[] resourceBytes)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string[] manifestResourceNames = executingAssembly.GetManifestResourceNames();
            AssemblyName name = executingAssembly.GetName();
           tempFolder = string.Format("{0}.{1}.{2}", name.Name, name.ProcessorArchitecture, name.Version);
            string text = Path.Combine(Path.GetTempPath(), tempFolder);
            bool flag = !Directory.Exists(text);
            if (flag)
            {
                Directory.CreateDirectory(text);
            }
            string environmentVariable = Environment.GetEnvironmentVariable("PATH");
            string[] array = environmentVariable.Split(new char[]
            {
                ';'
            });
            bool flag2 = false;
            foreach (string a in array)
            {
                bool flag3 = a == text;
                if (flag3)
                {
                    flag2 = true;
                    break;
                }
            }
            bool flag4 = !flag2;
            if (flag4)
            {
                Environment.SetEnvironmentVariable("PATH", text + ";" + environmentVariable);
            }
            string path = Path.Combine(text, dllName);
            bool flag5 = true;
            bool flag6 = File.Exists(path);
            if (flag6)
            {
                byte[] b = File.ReadAllBytes(path);
                bool flag7 = Equality(resourceBytes, b);
                if (flag7)
                {
                    flag5 = false;
                }
            }
            bool flag8 = flag5;
            if (flag8)
            {
                File.WriteAllBytes(path, resourceBytes);
            }
        }
        public static bool Equality(byte[] a1, byte[] b1)
        {
            bool flag = a1.Length == b1.Length;
            if (flag)
            {
                int num = 0;
                while (num < a1.Length && a1[num] == b1[num])
                {
                    num++;
                }
                bool flag2 = num == a1.Length;
                if (flag2)
                {
                    return true;
                }
            }
            return false;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
       public static extern IntPtr LoadLibraryEx(string dllToLoad, IntPtr hFile, uint flags);
        public static IntPtr LoadDll(string dllName)
        {
            bool flag = tempFolder == "";
            if (flag)
            {
                throw new Exception("Please call ExtractEmbeddedDlls before LoadDll");
            }
            IntPtr intPtr = LoadLibraryEx(dllName, IntPtr.Zero, 0U);
            bool flag2 = intPtr == IntPtr.Zero;
            if (flag2)
            {
                Exception inner = new Win32Exception();
                throw new DllNotFoundException("Unable to load library: " + dllName + " from " + tempFolder, inner);
            }
            return intPtr;
        }
        private static byte[] DecryptBytes(SymmetricAlgorithm alg, byte[] message)
        {
            bool flag = message == null || message.Length == 0;
            byte[] result;
            if (flag)
            {
                result = message;
            }
            else
            {
                bool flag2 = alg == null;
                if (flag2)
                {
                    throw new ArgumentNullException("alg is null");
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (ICryptoTransform cryptoTransform = alg.CreateDecryptor())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(message, 0, message.Length);
                            cryptoStream.FlushFinalBlock();
                            result = memoryStream.ToArray();
                        }
                    }
                }
            }
            return result;
        }
        public static byte[] Decrypt(byte[] key, byte[] message)
        {
            byte[] result;
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Key = key;
                rijndaelManaged.IV = key;
                result = DecryptBytes(rijndaelManaged, message);
            }
            Console.WriteLine(result.Length);
            return result;
        }
        public static byte[] byteArrayGrabber(byte[] bytes, int skip, int take)
        {
            byte[] array = new byte[take];
            int num = 0;
            int i = 0;
            while (i < take)
            {
                byte b = bytes[skip + i];
                array[num] = b;
                i++;
                num++;
            }
            return array;
        }
        public static bool is_virualized(MethodDef method)
        {
            try
            {
                for(int i =0; i < method.Body.Instructions.Count; i ++)
                {
                    if(method.Body.Instructions[i].OpCode == dnlib.DotNet.Emit.OpCodes.Call)
                    {
                        if (method.Body.Instructions[i].Operand.ToString().Contains("Runner"))
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
               
            }
            return false;
        }
        public static OpCode[] oneByteOpCodes;

        // Token: 0x0400001D RID: 29
        public static OpCode[] twoByteOpCodes;
        private static string tempFolder;
    }
}
