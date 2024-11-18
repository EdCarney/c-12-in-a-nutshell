<Query Kind="Statements" />


/* CONTRAVARIANCE

basically, covariance in the reverse direction; if you have a type A that is implicitly reference convertible to B,
X<T> has a covariant T if X<A> allows reference conversion to X<B> (and this is only possible in OUTPUT positions)

contravariance goes the opposite direction, i.e. from X<B> to X<A>; this is designated with the 'in' modifier and is
only allowed for INPUT positions

note that in order to support these operations, you must commit to the idea of working through the interfaces that
support the co and contra variance

this is allowed because the more specific type can always be upcast to the parent type

*/


IPushable<Animal> animals = new Stack<Animal>();
IPushable<Bear> bears = animals;			// legal

bears.Push(new Bear());						// this is fine; there can never be a case where we cast an Animal to a Bear

IPushable<Camel> my_camels = new Stack<Animal>();
IPoppable<Animal> my_animals = new Stack<Camel>();

// IEnumerable supports covariance, meaning if you can do implicit reference conversion from A upcast to B, then you can
// convert IEnumerable<A> to IEnumerable<B>

IEnumerable<Animal> enumerable_animals = new List<Camel>();

// example using Comparer

var objComparer = Comparer<object>.Default;		// implements IComparer<object>
IComparer<string> strComparer = objComparer;
int result = strComparer.Compare("Alice", "Bob");

class Animal { }
class Bear : Animal { }
class Camel : Animal { }

class Stack<T> 
	: IPoppable<T>, IPushable<T>			// stack now implements co and contra variance
{
	int pos;
	T[] data = new T[100];
	public void Push(T obj) => data[pos++] = obj;
	public T Pop() => data[--pos];
}

public interface IPoppable<out T>			// T is covariant for this interface
{
	T Pop();
}

public interface IPushable<in T>			// T is contravariant for this interface
{
	void Push(T obj);
}

public interface IMyComparer<in T>
{
	int Compare(T a, T b);					// returns a value indicating the ordering of a and b
}