<Query Kind="Statements" />


/* GENERIC CONSTRAINTS

by default, you can use any type as a type parameter; constraints can be applied to type parameters to require more
specific type args

type constraints can be:
	- base class (must inherit from the class)
	- interface (must implement interface)
	- 'class' (type must be a reference type)
	- 'class?' (type must be a nullable reference type)
	- 'struct' (type must be a non-nullable value type)
	- 'unmanaged' (since c#7; stronger version of 'struct'; must be a simple value type i.e. no related reference types)
	- 'new()' (type requires a parameterless ctor)
	- 'T' (naked type constraint)
	- 'notnull' (type must be a non-nullable reference type)

these constraints allow you to do things with the generic type that would otherwise be prohibited (e.g., use methods
as part of IMyInterface, construct a new instance of U)

from c#11, interface constraints also allow you to call static virtual/abstract members on the interface

*/

class SomeClass { }

interface IMyInterface<T>
{
	int CompareTo(T other);
}

interface IFoo
{
	static abstract void Bar();
}

class GenericClass<T, U> where T : SomeClass, IMyInterface<T>   // T must derive from SomeClass and implement IMyInterface
						where U : new()                         // U must have a parameterless ctor

{
	public T Max(T a, T b)
	{
		return a.CompareTo(b) > 0 ? a : b;
	}

	public int CompareTo(GenericClass<T, U> other)
	{
		return 0;
	}
}

class AnotherClass<T> where T : IFoo
{
	public void DoSomething(T a)
	{
		T.Bar();												// we are able to call the static abstract member of IFoo
	}
}

class Stack<T>
{
	Stack<U> FilteredStack<U>() where U : T						// the naked type constraint; U must derive from (or match) T
	{
		return new Stack<U>();
	}
}