<Query Kind="Statements" />



/* BOXING

converting a struct to an interface causes boxing

calling an implicitly implemented member on a struct does not cause boxing (calling an explicitly
implemented member requires converting the struct to the interface type)
*/


var s = new MyStruct();

s.Foo();				// no boxing
((IMy)s).Foo();			// boxing

interface IMy { void Foo(); }
struct MyStruct : IMy
{
	public void Foo() => Console.WriteLine("foo");
}