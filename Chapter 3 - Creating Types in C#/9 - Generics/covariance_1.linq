<Query Kind="Statements" />


/* COVARIANCE AND CONTRAVARIANCE

assume A is implicitly reference convertable to B (i.e., A subclasses or implements B); X is said to have a COVARIANT type
param if X<A> is implicitly convertable to X<B>

	IFoo<string> s = ...;
	IFoo<object> x = s;			// here, IFoo has a covariant T

interfaces and delegates permit covariant type params, but classes do not; arrays also support this (i.e., A[] can be
converted to B[] if A has an implicit reference conversion to B)

parameters are NOT automatically variant

*/

var bears = new Stack<Bear>();
Stack<Animal> animals = bears;          // compile time error; T is not covariant for Stack

// note the above prevents doing something like
/*

	animals.Push(new Camel());		// trying to add a camel to the stack of bears

*/


ZooCleaner.Wash_1(bears);			// T not covariant for Stack
ZooCleaner.Wash_2(bears);			// T contrained to be an Animal type


// note that for historical reasons, array types always support covariance; this of course introduces potential runtime
// errors if we attempt to add a type that subclasses the base class but does not align with the underlying data model

Bear[] bears_arr = new Bear[10];
Animal[] animals_arr = bears_arr;		// totally legal

animals_arr[0] = new Camel();			// runtime error


class ZooCleaner
{
	public static void Wash_1(Stack<Animal> animals)		// note that we could not call this method w/ Stack<Bear>
	{
	}
	
	public static void Wash_2<T>(Stack<T> animals) where T : Animal
	{
		
	}
}


class Animal { }
class Bear : Animal { }
class Camel : Animal { }

class Stack<T>
{
	int pos;
	T[] data = new T[100];
	public void Push(T obj) => data[pos++] = obj;
	public T Pop() => data[--pos];
}