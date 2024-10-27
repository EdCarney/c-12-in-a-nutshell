<Query Kind="Statements" />


// c# enforces a DEFINITE ASSIGNMENT POLICY, which essentially means that you can't
// access uninitialized memory (outside of an unsafe or interop context); this has
// three implications:
//	- local variables must be assigned before they can be used
//	- non-optional function args must be supplied when a method is called
//	- other variables (e.g. fields, array elements) are automatically initialized by the runtime

int x;
/*
Console.WriteLine(x);			// compile-time error due to unassigned local variable
*/

int[] ints = new int[2];
Console.WriteLine(ints[0]);		// outputs 0 because array elements/fields are given their default value

Console.WriteLine(Test.x);		// outputs 0 because array elements/fields are given their default value
class Test { public static int x; }