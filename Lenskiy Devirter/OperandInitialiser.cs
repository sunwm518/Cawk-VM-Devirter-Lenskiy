using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Lenskiy_Devirter
{
    class OperandInitialiser
    {

       public static object Initialise (byte opType, BinaryReader binaryReader, Module module, Dictionary<int, Label> _allLabelsDictionary, List<LocalBuilder> allLocals)
        {
            object operand = null;
            switch ((int)opType)
            {
                case 0:
                    operand = null;

                    break;
                case 1:
                    int metadataToken = binaryReader.ReadInt32();
                    MethodBase methodBase = module.ResolveMethod(metadataToken);
                    bool flag = methodBase is MethodInfo;
                    if (flag)
                    {
                        operand = Program.module.Import(methodBase);
                    }
                    else
                    {
                        bool flag2 = methodBase is ConstructorInfo;
                        if (!flag2)
                        {
                            throw new Exception("Check resolvedMethodBase Type");
                        }
                        operand =  (ConstructorInfo)methodBase;
                    }
                        break;
                case 2:
                    string str = binaryReader.ReadString();
                    operand = str;
                    break;
                case 3:
                    int arg = binaryReader.ReadInt32();
                    operand = arg;
                    break;
                case 4:
                   
                    break;
                case 5:
                    int metadataTokens = binaryReader.ReadInt32();
                    FieldInfo field = module.ResolveField(metadataTokens);
                    operand =  field;
                    break;
                case 6:
                    int metadataToken3 = binaryReader.ReadInt32();
                    Type cls = module.ResolveType(metadataToken3);
                    operand = cls;
                    break;
                case 7:
                    int key = binaryReader.ReadInt32();
                    Label label = _allLabelsDictionary[key];
                    operand = label;
                    break;
                case 8:
                    byte arg1 = binaryReader.ReadByte();
                    operand = arg1;
                    break;
                case 9:
                    int num = binaryReader.ReadInt32();
                    Label[] array = new Label[num];
                    for (int i = 0; i < num; i++)
                    {
                        array[i] = _allLabelsDictionary[binaryReader.ReadInt32()];
                    }
                    operand = array;
                    break;
                case 10:
                    int key1 = binaryReader.ReadInt32();
                    Label label1 = _allLabelsDictionary[key1];
                    operand = label1;
                    break;
                case 11:
                    int metadataTokenss = binaryReader.ReadInt32();
                    byte b = binaryReader.ReadByte();
                    bool flags = b == 0;
                    if (flags)
                    {
                        FieldInfo fields = module.ResolveField(metadataTokenss);
                        operand = fields;
                    }
                    else
                    {
                        bool flag2 = b == 1;
                        if (flag2)
                        {
                            Type clss = module.ResolveType(metadataTokenss);
                            operand = clss;
                        }
                        else
                        {
                            bool flag3 = b == 2;
                            if (flag3)
                            {
                                MethodBase methodBases = module.ResolveMethod(metadataTokenss);
                                bool flag4 = methodBases is MethodInfo;
                                if (flag4)
                                {
                                    operand =  (MethodInfo)methodBases;
                                }
                                else
                                {
                                    bool flag5 = methodBases is ConstructorInfo;
                                    if (flag5)
                                    {
                                        operand =  (ConstructorInfo)methodBases;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 12:
                    int num1 = binaryReader.ReadInt32();
                    byte bs = binaryReader.ReadByte();
                    bool flagss = bs == 0;
                    if (flagss)
                    {
                        LocalBuilder local = allLocals[num1];
                        operand =  local;
                    }
                    else
                    {
                        operand =  num1;
                    }
                    break;
                case 13:
                    byte[] value = binaryReader.ReadBytes(4);
                    float arg2 = BitConverter.ToSingle(value, 0);
                    operand = arg2;
                    break;
                case 14:
                    double arg3 = binaryReader.ReadDouble();
                    operand = arg3;
                    break;
                case 15:
                    long arg4 = binaryReader.ReadInt64();
                    operand = arg4;
                    break;
            }
            return operand;
        }
    }
}
