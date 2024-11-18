<Query Kind="Expression" />


/* C# GENERICS VS. C++ TEMPLATES

in both cases, there must be an understanding b/w the producer of the type and the consumer that will fill in the
placeholder types; the difference is that in c# the producer/open types (e.g. List<T>) can be compiled into a lib
and shared as a DLL

this works because the synthesis b/w the producer and consumer doesn't happen until runtime; c++ templates on the
other hand, do this synthesis at compile time and thus cannot be shared as DLLs (they exist as source code)

consider a Max<T> method in c#

	static T Max<T>(T a, T b) where T : IComparable<T>
		=> a.CompareTo(b) > 0 ? a : b;

why can't we instead to this?

	static T Max<T>(T a, T b)
		=> a > b ? a : b;			// compile time error

this generates an error because '>' is not defined for ALL possible values of T; this must be true to allow the compiler
to know that the type can be closed successfully at runtime

in c++, the method would look like this

	template <class T> T Max(T a, T b)
	{
		return a > b ? a : b;
	}

the validity of using '>' here is determined at compile time; and the type will fail to compile if '>' is not valid for
the class T used by the consumer

*/
