<Query Kind="Statements" />


// PARAMS MODIFER
//
// optionally applied to the last parameter of a method; allows the method to accept any number of args of a specified type;
// the parameter must be declared as a single-dimension array

int total1 = Sum(1, 2, 3, 4);
Console.WriteLine(total1);

int total2 = Sum(new int[] { 1, 2, 3, 4 });		// equivalent to the call for total1
Console.WriteLine(total2);

// params args are optional; if none are passed in, a zero-length array is generated

static int Sum(params int[] ints)		// params argument must be a single dimension array
{
	int sum = 0;
	for (int i = 0; i < ints.Length; i++)
		sum += ints[i];
	return sum;
}

// OPTIONAL PARAMETERS
//
// methods, ctors, and indexers can declare optional parameters; these specify default values in the declaration;
// these values are baked into the compiled code at the CALLING SIDE
//
// so the compiler basically just substitutes the lack of parameter with the default value in the compiled code;
// this means that adding an optional parameter to a public method called from another assembly requires recompilation
// of BOTH assemblies

Foo();

// optional parameters must be specified with one of these:
//	- constant expression
//	- parameterless ctor of a value type
//	- a default expression
// optional parameters can also not be marked as ref or out

// NAMED ARGUMENTS
//
// you can identify an argument by name on the calling side

Foo(x: 1, y:2);

static void Foo(int x = 23, int y = default)
{
	Console.WriteLine(x);
	Console.WriteLine(y);
}

// note that arg expressions are evaluated in the order they appear on the calling side; only really makes a difference
// if you have badly coded some interdependent side-effecting expressions

int a = 0;
Foo(y: ++a, x: --a);	// ++a is evaluated first here
