<Query Kind="Statements" />


// c# allows you to define a local variable that references an element in an array or an object field;
// note this cannot point to an object property; generally this is intended for micro-optimizations
// in conjunction with ref returns

int[] numbers = { 0, 1, 2, 3, 4 };
ref int numRef = ref numbers[2];		// grabs a reference to the array element
numRef *= 10;
Console.WriteLine(numbers[2]);			// array element is now 20

var f = new Foo_1 { s = "foo" };		// grabs a reference to the object field
ref string strRef = ref f.s;
strRef = "bar";
Console.WriteLine(f.s);					// object field is modified

// a 'ref local' can be returned from a method; this is called a 'ref return'

ref string fooRef = ref Foo_2.GetX();
fooRef = "hello, world";
Console.WriteLine(Foo_2.x);

// you can also omit the ref modifier, then it just becomes a normal variable

string fooNonRef = Foo_2.GetX();		// legal

// while you can't 'ref local' a property, a property can be defined as ref to use a 'ref return';
// these will be implicitly writable, if you want the perf gain without the writability you can
// use a 'ref readonly' property

var my_foo = new Foo_3();
ref string propRef = ref my_foo.Prop_1;
ref readonly string unwritablePropRef = ref my_foo.Prop_2;

class Foo_1
{
	public string s;
}

class Foo_2
{
	public static string x = "some old value";
	
	public static ref string GetX()
	{
		return ref x;			// a ref return
	}
}

class Foo_3
{
	string x = "my x value";
	string y = "my y value";
	
	public ref string Prop_1 => ref x;				// property ref return; this is also implicitly writable (even though there is no setter)
	
	public ref readonly string Prop_2 => ref x;		// now the ref is not modifiable
}