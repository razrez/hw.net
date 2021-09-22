// Type: hw1.Program 
// Assembly: hw1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3DBA35E-05CA-4912-B054-B62BB1B8BAB0
// Location: C:\Users\sharp\Desktop\hw.net\hw2\hw1\bin\Debug\net5.0\hw1.dll
// Sequence point data from C:\Users\sharp\Desktop\hw.net\hw2\hw1\bin\Debug\net5.0\hw1.pdb

.class public abstract sealed auto ansi beforefieldinit
  Program
    extends [System.Runtime]System.Object
{

  .method public hidebysig static int32
    Main(
      string[] args
    ) cil managed
  {
    .entrypoint
    .maxstack 6
    .locals init (
      [0] int32 parseRes,
      [1] int32 val1,
      [2] string operation,
      [3] int32 val2,
      [4] int32 result,
      [5] bool V_5,
      [6] int32 V_6
    )

    // [8 9 - 8 10]
    IL_0000: nop

    // [9 13 - 10 50]
    IL_0001: ldarg.0      // args
    IL_0002: ldloca.s     val1
    IL_0004: ldloca.s     operation
    IL_0006: ldloca.s     val2
    IL_0008: call         int32 [hw2IL]ParserIL::TryToParse(string[], int32&, string&, int32&)
    IL_000d: stloc.0      // parseRes

    // [12 13 - 12 31]
    IL_000e: ldloc.0      // parseRes
    IL_000f: ldc.i4.0
    IL_0010: cgt.un
    IL_0012: stloc.s      V_5

    IL_0014: ldloc.s      V_5
    IL_0016: brfalse.s    IL_001d

    // [12 32 - 12 48]
    IL_0018: ldloc.0      // parseRes
    IL_0019: stloc.s      V_6
    IL_001b: br.s         IL_0079

    // [14 13 - 14 70]
    IL_001d: ldloc.1      // val1
    IL_001e: ldloc.2      // operation
    IL_001f: ldloc.3      // val2
    IL_0020: call         int32 CalculatorIL::Calculate(int32, string, int32)
    IL_0025: stloc.s      result

    // [16 13 - 16 72]
    IL_0027: ldstr        "{0}{1}{2}={3}"
    IL_002c: ldc.i4.4
    IL_002d: newarr       [System.Runtime]System.Object
    IL_0032: dup
    IL_0033: ldc.i4.0
    IL_0034: ldarg.0      // args
    IL_0035: ldc.i4.0
    IL_0036: ldelem.ref
    IL_0037: stelem.ref
    IL_0038: dup
    IL_0039: ldc.i4.1
    IL_003a: ldarg.0      // args
    IL_003b: ldc.i4.1
    IL_003c: ldelem.ref
    IL_003d: stelem.ref
    IL_003e: dup
    IL_003f: ldc.i4.2
    IL_0040: ldarg.0      // args
    IL_0041: ldc.i4.2
    IL_0042: ldelem.ref
    IL_0043: stelem.ref
    IL_0044: dup
    IL_0045: ldc.i4.3
    IL_0046: ldloc.s      result
    IL_0048: box          [System.Runtime]System.Int32
    IL_004d: stelem.ref
    IL_004e: call         string [System.Runtime]System.String::Format(string, object[])
    IL_0053: call         void [System.Console]System.Console::WriteLine(string)
    IL_0058: nop

    // [18 13 - 18 76]
    IL_0059: ldloc.1      // val1
    IL_005a: ldloc.2      // operation
    IL_005b: ldloc.3      // val2
    IL_005c: call         int32 [hw2IL]CalculatorIL::Calculate(int32, string, int32)
    IL_0061: call         void [System.Console]System.Console::WriteLine(int32)
    IL_0066: nop

    // [19 13 - 19 57]
    IL_0067: ldloc.s      result
    IL_0069: call         int32 [hw2IL]CalculatorIL::Sqr(int32)
    IL_006e: call         void [System.Console]System.Console::WriteLine(int32)
    IL_0073: nop

    // [20 13 - 20 22]
    IL_0074: ldc.i4.0
    IL_0075: stloc.s      V_6
    IL_0077: br.s         IL_0079

    // [21 9 - 21 10]
    IL_0079: ldloc.s      V_6
    IL_007b: ret

  } // end of method Main
} // end of class Program
