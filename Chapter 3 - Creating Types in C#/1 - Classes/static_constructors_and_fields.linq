<Query Kind="Statements" />



Console.WriteLine("hello world");

Console.WriteLine(Foo.x);

class Test
{
	// MODULE INITIALIZERS
	//
	// from c#9 you can define module initializer methods that execute once per assembly when the
	// assembly is first loaded
	
	[System.Runtime.CompilerServices.ModuleInitializer]
	internal static void InitAssembly()
	{
		Console.WriteLine("Initializing assembly");
	}

	// STATIC CTORS
	//
	// a static ctor executes once PER TYPE (rather than per instance); a type can only define one
	// static ctor, and it must be parameterless and have the same name as the type
	//
	// the runtime automatically invokes the ctor just prior to the type being used (either being
	// instantiated or accessing a static member)
	//
	// note that if a static ctor throws an unhandled exception that the type becomes unusable for
	// the life of the application
	
	// static ctor
	static Test()
	{
		Console.WriteLine($"Initializing: {nameof(Test)}");
	}
	
	// FIELD INITIALIZATION ORDER
	//
	// static fields initialize just BEFORE the static ctor is called, and static fields will
	// initialize prior to the type being used
	//
	// the static fields initialize in the order in which the fields are declared
	
	public static int x = y;	// x will be 0
	public static int y = 3;	// y will be 3
}


public class Foo
{
	// here, Instance will initialize before X, and because for Instance we use the private ctor
	// which prints X prior to initialization, a zero will be printed first
	//
	// after this, any reference to X will show it as 3
	
	public static Foo Instance = new Foo();
	public static int X = 3;
	
	Foo() => Console.WriteLine(x);
}

