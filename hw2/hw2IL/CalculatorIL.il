.class public abstract sealed auto ansi beforefieldinit
  CalculatorIL
    extends [CORE_ASSEMBLY]System.Object
{

  .method public hidebysig static int32
    Calculate(
      int32 val1,
      string operation,
      int32 val2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 result,
      [1] int32 V_1,
      [2] int32 V_2
    )

    // [6 9 - 6 10]
    IL_0000: nop

    // [7 13 - 7 28]
    IL_0001: ldc.i4.0
    IL_0002: stloc.0      // result

    // [8 13 - 15 15]
    IL_0003: ldc.i4.1
    IL_0004: brtrue.s     IL_0007

    // [8 32 - 15 14]
    IL_0006: nop

    IL_0007: ldarg.1      // operation
    IL_0008: ldstr        "+"
    IL_000d: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0012: brtrue.s     IL_003d
    IL_0014: ldarg.1      // operation
    IL_0015: ldstr        "-"
    IL_001a: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_001f: brtrue.s     IL_0043
    IL_0021: ldarg.1      // operation
    IL_0022: ldstr        "*"
    IL_0027: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_002c: brtrue.s     IL_0049
    IL_002e: ldarg.1      // operation
    IL_002f: ldstr        "/"
    IL_0034: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0039: brtrue.s     IL_004f
    IL_003b: br.s         IL_0055

    // [10 24 - 10 35]
    IL_003d: ldarg.0      // val1
    IL_003e: ldarg.2      // val2
    IL_003f: add
    IL_0040: stloc.1      // V_1
    IL_0041: br.s         IL_0059

    // [11 24 - 11 35]
    IL_0043: ldarg.0      // val1
    IL_0044: ldarg.2      // val2
    IL_0045: sub
    IL_0046: stloc.1      // V_1
    IL_0047: br.s         IL_0059

    // [12 24 - 12 35]
    IL_0049: ldarg.0      // val1
    IL_004a: ldarg.2      // val2
    IL_004b: mul
    IL_004c: stloc.1      // V_1
    IL_004d: br.s         IL_0059

    // [13 24 - 13 35]
    IL_004f: ldarg.0      // val1
    IL_0050: ldarg.2      // val2
    IL_0051: div
    IL_0052: stloc.1      // V_1
    IL_0053: br.s         IL_0059

    // [14 22 - 14 28]
    IL_0055: ldloc.0      // result
    IL_0056: stloc.1      // V_1
    IL_0057: br.s         IL_0059

    IL_0059: ldc.i4.1
    IL_005a: brtrue.s     IL_005d

    // [8 13 - 15 15]
    IL_005c: nop

    IL_005d: ldloc.1      // V_1
    IL_005e: stloc.0      // result

    // [16 13 - 16 27]
    IL_005f: ldloc.0      // result
    IL_0060: stloc.2      // V_2
    IL_0061: br.s         IL_0063

    // [17 9 - 17 10]
    IL_0063: ldloc.2      // V_2
    IL_0064: ret

  } // end of method 
} // end of class 
