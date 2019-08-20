
	using constant local                   using normal local
	---------------------------------------------------------------------
	.entrypoint                            .entrypoint
	.maxstack 2                            .maxstack 2
	.locals init (                         .locals init (
	    [0] int32 i)                           [0] int32 timesToLoop,
	L_0000: ldc.i4.0                           [1] int32 i)
	L_0001: stloc.0                        L_0000: ldc.i4.s 50 
	L_0002: br.s L_0008                    L_0002: stloc.0 
	L_0004: ldloc.0                        L_0003: ldc.i4.0  
	L_0005: ldc.i4.1                       L_0004: stloc.1 
	L_0006: add                            L_0005: br.s L_000b 
	L_0007: stloc.0                        L_0007: ldloc.1 
	L_0008: ldloc.0                        L_0008: ldc.i4.1 
	L_0009: ldc.i4.s 50                    L_0009: add
	L_000b: blt.s L_0004                   L_000a: stloc.1 
	L_000d: ret                            L_000b: ldloc.1 
	                                       L_000c: ldloc.0 
	                                       L_000d: blt.s L_0007
	                                       L_000f: ret 


编译器将所有变量用法替换为常量的值，这导致较小的堆栈。



----------
[https://codeday.me/bug/20170930/76784.html](https://codeday.me/bug/20170930/76784.html "博文")