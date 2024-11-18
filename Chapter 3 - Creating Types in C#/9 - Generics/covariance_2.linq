<Query Kind="Statements" />


/* DECLARING COVARIANT TYPE PARAMETERS

type params for interfaces and delegates can be declared covariant by marking the type with the
'out' keyword; this will ensure that the type params are fully type-safe

note that this means that T is used only in OUTPUT positions (i.e.,  return types for methods)

note that IEnumerable<T> and IEnumerator<T> both have covariant T, allowing you to e.g. cast
IEnumerable<string> to IEnumerable<object>

also note that co/contravariance only work w/ REFERENCE conversions (not BOXING conversions); so
IPoppable<string> could be implicitly converted to IPoppable<object>, but IPoppable<int> could not
be implicitly converted as such

*/


var bears = new Stack<Bear>();
bears.Push(new Bear());

IPoppable<Animal> animals = bears;			// legal; Stack<T> implements the covariant interface
Animal a = animals.Pop();

// both of these are also now legal	

ZooCleaner.Wash(animals);
ZooCleaner.Wash(bears);

class ZooCleaner
{
	public static void Wash(IPoppable<Animal> animals)
	{
		
	}
}

class Animal { }
class Bear : Animal { }
class Camel : Animal { }

class Stack<T> : IPoppable<T>				// Stack now implements interface w/ covariant type
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