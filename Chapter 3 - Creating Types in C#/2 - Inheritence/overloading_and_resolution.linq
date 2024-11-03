<Query Kind="Program" />

void Main()
{
	var h = new House();
	var a = (Asset)h;
	
	Foo(h);				// calls Foo(House)
	Foo(a);				// calls Foo(Asset)
	
	Foo((dynamic)a);	// calls Foo(House) since a's type is actually House
}

// OVERLOADING AND RESOLUTION
//
// when a method is overloaded to accept args that are in the same inheritance heirarchy, the most
// specific type has precedence; this determination is made at compile time
//
// note if you cast the arg to a dynamic, then the decision on which overload to use is made instead
// at runtime, and it is based on the object's actual type


static void Foo(Asset a) { }
static void Foo(House h) { }

public class Asset
{
	public string Name;
}

public class House : Asset
{
	public decimal Liability;
}
