.class public abstract sealed auto ansi beforefieldinit
  ParserIL
    extends [CORE_ASSEMBLY]System.Object
{

  .class nested private sealed auto ansi serializable beforefieldinit
    '<>c'
      extends [CORE_ASSEMBLY]System.Object
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )

    .field public static initonly class ParserIL/'<>c' '<>9'

    .field public static class [System.Runtime]System.Func`3<string, string, string> '<>9__1_0'

    .method private hidebysig static specialname rtspecialname void
      .cctor() cil managed
    {
      .maxstack 8

      IL_0000: newobj       instance void ParserIL/'<>c'::.ctor()
      IL_0005: stsfld       class ParserIL/'<>c' ParserIL/'<>c'::'<>9'
      IL_000a: ret

    } // end of method '<>c'::.cctor

    .method public hidebysig specialname rtspecialname instance void
      .ctor() cil managed
    {
      .maxstack 8

      IL_0000: ldarg.0      // this
      IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
      IL_0006: nop
      IL_0007: ret

    } // end of method '<>c'::.ctor

    .method assembly hidebysig instance string
      '<TryToParse>b__1_0'(
        string c,
        string n
      ) cil managed
    {
      .maxstack 8

      // [34 60 - 34 70]
      IL_0000: ldarg.1      // c
      IL_0001: ldstr        " "
      IL_0006: ldarg.2      // n
      IL_0007: call         string [System.Runtime]System.String::Concat(string, string, string)
      IL_000c: ret

    } // end of method '<>c'::'<TryToParse>b__1_0'
  } // end of class '<>c'

  .field private static initonly string[] ExpectedOperation

  .method public hidebysig static int32
    TryToParse(
      string[] args,
      [out] int32& val1,
      [out] string& operation,
      [out] int32& val2
    ) cil managed
  {
    .maxstack 6
    .locals init (
      [0] bool isVal1Int,
      [1] bool isVal2Int,
      [2] bool V_2,
      [3] int32 V_3,
      [4] bool V_4
    )

    // [18 9 - 18 10]
    IL_0000: nop

    // [19 13 - 19 61]
    IL_0001: ldarg.0      // args
    IL_0002: ldc.i4.0
    IL_0003: ldelem.ref
    IL_0004: ldarg.1      // val1
    IL_0005: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_000a: stloc.0      // isVal1Int

    // [20 13 - 20 33]
    IL_000b: ldarg.2      // operation
    IL_000c: ldarg.0      // args
    IL_000d: ldc.i4.1
    IL_000e: ldelem.ref
    IL_000f: stind.ref

    // [21 13 - 21 61]
    IL_0010: ldarg.0      // args
    IL_0011: ldc.i4.2
    IL_0012: ldelem.ref
    IL_0013: ldarg.3      // val2
    IL_0014: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_0019: stloc.1      // isVal2Int

    // [23 13 - 23 42]
    IL_001a: ldloc.0      // isVal1Int
    IL_001b: brfalse.s    IL_0023
    IL_001d: ldloc.1      // isVal2Int
    IL_001e: ldc.i4.0
    IL_001f: ceq
    IL_0021: br.s         IL_0024
    IL_0023: ldc.i4.1
    IL_0024: stloc.2      // V_2

    IL_0025: ldloc.2      // V_2
    IL_0026: brfalse.s    IL_0046

    // [24 13 - 24 14]
    IL_0028: nop

    // [25 17 - 25 101]
    IL_0029: ldarg.0      // args
    IL_002a: ldc.i4.0
    IL_002b: ldelem.ref
    IL_002c: ldarg.0      // args
    IL_002d: ldc.i4.1
    IL_002e: ldelem.ref
    IL_002f: ldarg.0      // args
    IL_0030: ldc.i4.2
    IL_0031: ldelem.ref
    IL_0032: ldstr        " is not a valid calculation syntax"
    IL_0037: call         string [System.Runtime]System.String::Concat(string, string, string, string)
    IL_003c: call         void [System.Console]System.Console::WriteLine(string)
    IL_0041: nop

    // [26 17 - 26 26]
    IL_0042: ldc.i4.1
    IL_0043: stloc.3      // V_3
    IL_0044: br.s         IL_00b7

    // [29 13 - 29 65]
    IL_0046: ldsfld       string[] ParserIL::ExpectedOperation
    IL_004b: ldarg.2      // operation
    IL_004c: ldind.ref
    IL_004d: callvirt     instance bool [System.Runtime]System.Collections.IList::Contains(object)
    IL_0052: stloc.s      V_4

    IL_0054: ldloc.s      V_4
    IL_0056: brfalse.s    IL_005c

    // [29 66 - 29 75]
    IL_0058: ldc.i4.0
    IL_0059: stloc.3      // V_3
    IL_005a: br.s         IL_00b7

    // [31 13 - 34 75]
    IL_005c: ldc.i4.5
    IL_005d: newarr       [System.Runtime]System.String
    IL_0062: dup
    IL_0063: ldc.i4.0
    IL_0064: ldarg.0      // args
    IL_0065: ldc.i4.0
    IL_0066: ldelem.ref
    IL_0067: stelem.ref
    IL_0068: dup
    IL_0069: ldc.i4.1
    IL_006a: ldarg.0      // args
    IL_006b: ldc.i4.1
    IL_006c: ldelem.ref
    IL_006d: stelem.ref
    IL_006e: dup
    IL_006f: ldc.i4.2
    IL_0070: ldarg.0      // args
    IL_0071: ldc.i4.2
    IL_0072: ldelem.ref
    IL_0073: stelem.ref
    IL_0074: dup
    IL_0075: ldc.i4.3
    IL_0076: ldstr        " is not a valid calculation syntax. Supported operations are "
    IL_007b: stelem.ref
    IL_007c: dup
    IL_007d: ldc.i4.4
    IL_007e: ldsfld       string[] ParserIL::ExpectedOperation
    IL_0083: ldsfld       class [System.Runtime]System.Func`3<string, string, string> ParserIL/'<>c'::'<>9__1_0'
    IL_0088: dup
    IL_0089: brtrue.s     IL_00a2
    IL_008b: pop
    IL_008c: ldsfld       class ParserIL/'<>c' ParserIL/'<>c'::'<>9'
    IL_0091: ldftn        instance string ParserIL/'<>c'::'<TryToParse>b__1_0'(string, string)
    IL_0097: newobj       instance void class [System.Runtime]System.Func`3<string, string, string>::.ctor(object, native int)
    IL_009c: dup
    IL_009d: stsfld       class [System.Runtime]System.Func`3<string, string, string> ParserIL/'<>c'::'<>9__1_0'
    IL_00a2: call         !!0/*string*/ [System.Linq]System.Linq.Enumerable::Aggregate<string>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*string*/>, class [System.Runtime]System.Func`3<!!0/*string*/, !!0/*string*/, !!0/*string*/>)
    IL_00a7: stelem.ref
    IL_00a8: call         string [System.Runtime]System.String::Concat(string[])
    IL_00ad: call         void [System.Console]System.Console::WriteLine(string)
    IL_00b2: nop

    // [35 13 - 35 22]
    IL_00b3: ldc.i4.2
    IL_00b4: stloc.3      // V_3
    IL_00b5: br.s         IL_00b7

    // [37 9 - 37 10]
    IL_00b7: ldloc.3      // V_3
    IL_00b8: ret

  } // end of method 

  .method private hidebysig static specialname rtspecialname void
    .cctor() cil managed
  {
    .maxstack 8

    // [9 9 - 15 11]
    IL_0000: ldc.i4.4
    IL_0001: newarr       [System.Runtime]System.String
    IL_0006: dup
    IL_0007: ldc.i4.0
    IL_0008: ldstr        "+"
    IL_000d: stelem.ref
    IL_000e: dup
    IL_000f: ldc.i4.1
    IL_0010: ldstr        "-"
    IL_0015: stelem.ref
    IL_0016: dup
    IL_0017: ldc.i4.2
    IL_0018: ldstr        "*"
    IL_001d: stelem.ref
    IL_001e: dup
    IL_001f: ldc.i4.3
    IL_0020: ldstr        "/"
    IL_0025: stelem.ref
    IL_0026: stsfld       string[] ParserIL::ExpectedOperation
    IL_002b: ret

  } // end of method 
} // end of class 