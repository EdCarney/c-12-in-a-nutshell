<Query Kind="Statements" />


var c = new MyClass();

public class MyClass
{
	// FINALIZERS
	//
	// finalizers are akin to destructors in c++ in that they execute before the GC reclaims the memory
	// for an unreferenced object, and the syntax in c# also uses the ~
	//
	// note that in c# this is actually shorthand for overriding the Object::Finalize() method
	
	~MyClass()
	{
		Console.WriteLine("Finalizing...");
	}
}

// the compiler doesn't like the below code, but it is basically what the compiler expands
// the ~ shorthand into
/*
public class MyOtherClass
{
	protected override void Finalize()
	{
		base.Finalize();
	}
}
*/