<Query Kind="Statements" />


/*
INTERFACE BASICS

	- can only define functions (not fields)
	- members are implicitly abstract and public
	- class/struct can implement multiple interfaces (classes can only inherit from one class, and structs not at all)

interfaces can only define functions (methods, properties, indexers, and events), which are also the only
member types that can be marked as abstract

you can implicitly cast an object to any interface that it implements
*/


var e = new Countdown();
while (e.MoveNext())
{
	Console.WriteLine(e.Current);
}

internal class Countdown : IEnumerator
{
	private int count = 11;
	public bool MoveNext() => count-- > 0;
	public object Current => count;
	public void Reset() => throw new NotSupportedException();
}

// note that event though Countdown is internal, because IEnumerator is a public interface, an outside assembly could
// call those interface methods by casting to IEnumerator
//
// for the below, an outside assembly could do:
//		var e = (IEnumerator)Utils.GetCountDown();

public static class Utils
{
	public static object GetCountDown() => new Countdown();				// note the return type here needs to be object, since Countdown is internal
}
