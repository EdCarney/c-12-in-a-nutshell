<Query Kind="Statements" />



class Test
{
	// note constant fields are evaluated at compile time (similar to C++ macros);
	// these can only be bools, chars, strings, enums, or the built-in numerics;
	// these fields must be initialized with a value
	public const string Message = "Hello there";
	
	// constants are similar to static readonly, but consts are more restrictive
	// in the allowed types and the allows inititialization semantics; also static
	// readonly fields are evaluated at runtime
	public static readonly double TwoPi = 2 * Math.PI;
	
	// note that static readonly are good for values that are exposed to other assemblies
	// and which may chnage later (e.g. assembly version); with a constant, any assembly
	// referencing the value would need to be recompiled, but with a readonly static
	// you can just drop in the new assembly version
}