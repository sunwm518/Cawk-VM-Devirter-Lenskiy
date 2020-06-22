using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpCodes = dnlib.DotNet.Emit.OpCodes;
using OpCode = System.Reflection.Emit.OpCode;
using System.Reflection.Emit;
using System.IO;
using dnlib.DotNet;
using System.Reflection;

namespace Lenskiy_Devirter
{
    class OpcodeConverter
    {
        public static Instruction converter (OpCode opCode, object operand, BinaryReader binaryReader, Module moduled)
            {
            Instruction instr = new Instruction();
            Console.WriteLine("-==========" + opCode.Name + "-========== ");
           
            switch (opCode.Name)
            {
                case "add":
                    instr.OpCode =  OpCodes.Add;
                    break;
                case "ret":
                    instr.OpCode = OpCodes.Ret;
                    break;
                case "ldarga.s":
                    instr.OpCode = OpCodes.Ldarga_S;
                    break;
                case "ldc.i4":
                    instr.OpCode = OpCodes.Ldc_I4;
                    break;
                case "ldarga":
                    instr.OpCode = OpCodes.Ldarg;
                    break;
                case "arglist":
                    instr.OpCode = OpCodes.Arglist;
                    break;
                case "ldstr":
                    instr.OpCode = OpCodes.Ldstr;
                    instr.Operand = operand.ToString();
                    break;
                case "pop":
                    instr.OpCode = OpCodes.Pop;
                    break;
                case "ldarg":
                    instr.OpCode = OpCodes.Ldarg;
                    break;
                case"ldlen":
                    instr.OpCode = OpCodes.Ldlen;
                    break;
                case "convI4":
                    instr.OpCode = OpCodes.Conv_I4;
                    break;
                case"ceq":
                    instr.OpCode = OpCodes.Ceq;
                    break;
                case "ldc":
                    instr.OpCode = OpCodes.Ldc_I4;
                    break;
                case "stloc":
                    instr.OpCode = OpCodes.Stloc;
                        break;
                case "ldloc":
                    instr.OpCode = OpCodes.Ldloc;
                    break;
                case "brfalse":
                    instr.OpCode = OpCodes.Brfalse;
                    break;
                case "ldnull":
                    instr.OpCode = OpCodes.Ldnull;
                    break;
                case "br":
                    instr.OpCode = OpCodes.Nop;

                    break;
                case "newArr":
                    instr.OpCode = OpCodes.Newarr;
                    break;
                case "ldelemU1":
                    instr.OpCode = OpCodes.Ldelem_U1;
                    break;
                case "xor":
                    instr.OpCode = OpCodes.Xor;
                    break;
                case "convU1":
                    instr.OpCode = OpCodes.Conv_U1;
                    break;
                case "stelemI1":
                    instr.OpCode = OpCodes.Stelem_I1;
                    break;
                case "clt":
                    instr.OpCode = OpCodes.Clt;
                    break;
                case "brtrue":
                    instr.OpCode = OpCodes.Brtrue;
                    break;
                case "rem":
                    instr.OpCode = OpCodes.Rem;
                    break;
                case "nop":
                    instr.OpCode = OpCodes.Nop;
                    break;
                case "call":


                  
                    instr.OpCode = OpCodes.Call;
                    instr.Operand = operand;
                    break;
                case "newObj":
                    instr.OpCode = OpCodes.Newobj;
                    break;
                case "callvirt":
                    instr.OpCode = OpCodes.Callvirt;
                    break;
                default:
                    throw new Exception("Opcode Type Unknown ");
            }
            return instr;
            }

} }
    
