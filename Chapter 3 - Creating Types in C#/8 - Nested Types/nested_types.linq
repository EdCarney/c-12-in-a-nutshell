<Query Kind="Statements" />


/* NESTED TYPES

a type declared within another type

a nested type is private within the enclosing class by default and can access the enclosing type's private
members; accessing a nested type requires qualification with the enclosing type's name (similar to a static
member of the type)

classes, structs, interfaces, delegates, and enums can all be nested within a CLASS or a STRUCT

these types of classes are heavily used by the compiler when generating private classes to capture state for
iterators and anon methods

*/

var red = TopLevel.Color.Red;

public class TopLevel
{
	public class Nested { }                     // nested class
	public enum Color { Red, White, Blue }      // nested enum
	
	private static int X;
	
	class NestedAgain
	{
		static void Foo() => Console.WriteLine(X);
	}
	
	protected class ProtectTheNest { }
}

public class SubTopLevel : TopLevel
{
	static void Foo()
	{
		new TopLevel.Nested();
	}
}