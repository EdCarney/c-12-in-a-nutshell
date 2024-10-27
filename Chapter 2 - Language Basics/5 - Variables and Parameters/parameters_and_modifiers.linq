<Query Kind="Program" />

void Main()
{
	// a method may have a sequence of parameters to define the set of args;
	// you can control how the params are passed with ref, in, and out keywords:
	//	- REF:   passed by reference; value must be assigned going in
	//	- IN:    passed by reference (read only); value must be assigned going in
	//	- OUT:   passed by reference; value must be assigned going out
	// - (none): passed by value; must be assigned going io
	
	
	// BY VALUE:
	// 
	// by default args are passed by value, meaning that a copy of the value is created when passed
	// into the method
	
	Console.WriteLine("\nPASS BY VALUE");
	Console.WriteLine("=========================");
	
	int x = 8;
	Foo_1(x);					// make a copy of x
	Console.WriteLine(x);		// x is still 8 here
	
	// reference types have their reference copied, but NOT the object
	
	var sb = new StringBuilder();
	Foo_2(sb);								// a copy of the reference is passed in
	Console.WriteLine(sb.ToString());		// prints "inside foo" because they refer to the same object
	
	
	// REF MODIFIER:
	//
	// this allows passing by reference, so that the variables will refer to the same memory locations;
	// this is true for value types and ref types (a reference to the reference is passed in this case)
	
	Console.WriteLine("\nREF MODIFIER");
	Console.WriteLine("=========================");
	
	int y = 8;
	Foo_3(ref y);					// tells the func to deal directly with y
	Console.WriteLine(y);			// y is now 9
	
	// the ref modifier is essential for implementing a swap method
	
	string str1 = "Penn";
	string str2 = "Teller";
	Swap(ref str1, ref str2);
	Console.WriteLine(str1);
	Console.WriteLine(str2);
	
	
	// OUT MODIFIER:
	//
	// similar to the ref modifier, except that an out param doesn't need to be assigned going into the function
	// and it must be assigned before it comes out of the function; commonly used to get multiple return values
	// back from a function; like ref, out parameters are passed by reference
	
	Console.WriteLine("\nOUT MODIFIER");
	Console.WriteLine("=========================");
	
	string a, b;
	Split("Stevie Ray Vaughn", out a, out b);
	Console.WriteLine(a);
	Console.WriteLine(b);
	
	// note you can use the discard (_) to ignore some out parameters; for backwards compatibility, if you have
	// an underscore declared as a variable somewhere, then the discard won't work
	
	Split("Stevie Ray Vaughn", out string firstName, out _);
	
	void Split(string name, out string firstNames, out string lastName)
	{
		int index = name.LastIndexOf(' ');
		firstNames =  name.Substring(0, index);		// only do a length of index so we don't grab the space
		lastName = name.Substring(index + 1);		// start at index + 1 to avoid the space
	}
	
	
	// IN MODIFIER
	//
	// similar to a ref parameter except that the arg's value cannot be modified by the method (generates a compile-time error);
	// useful when passing large value types since you can avoid the overhead of copying all the value data but still have
	// protection against mutation within the method
	
	Console.WriteLine("\nIN MODIFIER");
	Console.WriteLine("=========================");
	
	var mbs = new MyBigStruct();
	
	// to call the Foo_in overload you must specify the 'in' modifier
	
	Foo_in(mbs);		// calls the Foo_in instance without the 'in' modifier
	Foo_in(in mbs);		// calls the one with the 'in' modifier
	Bar_in(mbs);		// always calls the one with 'in' modifier
	Bar_in(in mbs);		// always calls the one with 'in' modifier
}

// note that overloading soley on the presence of 'in' is permitted
void Foo_in(   MyBigStruct a) { }
void Foo_in(in MyBigStruct a) { }
void Bar_in(in MyBigStruct a) { }

static void Foo_1(int p)
{
	p = p + 1;				// increment by 1
	Console.WriteLine(p);	// write new value
}

static void Foo_2(StringBuilder fooSb)
{
	fooSb.Append("inside foo");			// fooSb points to the same object, so this modifies the object sb points to
	fooSb = null;						// ...but fooSb is a copy of the reference, so this line doesn't impact sb
}

static void Foo_3(ref int p)
{
	p = p + 1;					// increment by 1
	Console.WriteLine(p);		// write new value
}

static void Swap(ref string a, ref string b)
{
	string temp = a;
	a = b;
	b = temp;
}

// recall that structs are value types
struct MyBigStruct
{
	int a, b, c;
	long x, y, z;
}
