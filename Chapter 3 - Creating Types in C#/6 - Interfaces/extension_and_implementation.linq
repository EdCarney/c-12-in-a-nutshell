<Query Kind="Statements" />


/*
EXTENSION and IMPLEMENTATION

interfaces can derive from other interfaces

implementing multiple interfaces can result in collisions in member signatures; these can be resolved
by EXPLICITLY IMPLEMENTING an interface member

the only way to call an explicitly implemented member is to cast the object to the interface

this is a bit of a hassle for the caller, but this could be desirable even if there isn't a name conflict
to help hide highly specialized members of a type; e.g., a type implementing ISerializable might chose to
explicitly implement that interface since generally there is little reason to expose those methods
*/

var w = new Widget();
w.Foo();							// calls I1.Foo()
((I1)w).Foo();						// calls I1.Foo()
((I2)w).Foo();						// calls I2.Foo()


interface I1 { void Foo(); }
interface I2 { int Foo(); }         // recall that return type is not part of signature

public class Widget : I1, I2
{
	public void Foo()
	{
		Console.WriteLine("Widget implementation of I1.Foo()");
	}
	

	int I2.Foo()					// need to explicitly define I2.Foo(); note that you cannot add an access modifier here
	{
		Console.WriteLine("Widget implementation of I2.Foo()");
		return 69;
	}
}