<Query Kind="Statements" />


/* GENERIC METHODS

methods that declare TYPE PARAMETERS in their function signature

generally the type can be inferred by the compiler at the call site

within a generic type, a method is not always considered generic; it is only considered generic if it introduces
another generic type parameter (e.g. the Pop() method in the generic Stack<T> is NOT a generic method)

classes, structs, interfacces, and delegates are the only constructs that can introduce type parameters; all
other constructs can use type parameters, but cannot introduce new ones

generic type names and method names can be overloaded as long as the NUMBER of type parameters is different

*/


int x = 10;
int y = -2;
Swap(ref x, ref y);

static void Swap<T>(ref T x, ref T y)		// generic method
{
	var temp = x;
	x = y;
	y = x;
}

// these names do not conflict due to type number differences

class A { }
class A<T> { }
class A<T1, T2> { }