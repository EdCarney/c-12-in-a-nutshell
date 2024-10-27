<Query Kind="Statements" />


// types of variables
//	- local variable
//	- parameter (value, ref, out, in)
//	- field (instance, static)
//	- array element

// local variables and parameters are stored on the stack; stack grows/shrinks
// as a method/function is entered or exited

static int Factorial(int x)
{
	if (x == 0)
		return 1;
	return x * Factorial(x - 1);	// the stack grows with each recursion
}

// reference-type variables are allocated on the heap; after allocation, a reference
// to the instance is returned
//
// the garbage collector periodically cleans up the heap; an object is elidgible for
// deallocation once it is not referenced by anything

var ref1 = new StringBuilder("object 1");
Console.WriteLine(ref1);
// the StringBuilder referenced by ref1 is now eligible for GC

var ref2 = new StringBuilder("object 2");
var ref3 = ref2;
// the StringBuilder referenced by ref2 is not eligible for GC since ref3 points to
// the same instance and it is used later

Console.WriteLine(ref3);

// note that value and reference instances live wherever the associated variable was declared;
// if the instance was declared as field within a class type or as an array element, that
// instance will live on the heap

// the heap also stored static fields, although they are never eligible for deletion