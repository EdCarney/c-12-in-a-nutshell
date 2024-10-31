<Query Kind="Statements" />


class Test
{
	// methods signatures must be unique within the type (name and parameter types in order)

	// EXPRESSION-BODIED METHODS
	//
	// this name makes more sense now; normal methods have a body that is a series of statements,
	// whereas these methods are a single expression (literally expression bodied)
	int TimesTwo(int x) => x * 2;
	
	// LOCAL METHODS
	//
	// methods can be defined within another methods; these are visible only to the enclosisng
	// method; this can simplify the enclosing type
	//
	// by default these methods can access local variables and parameters defined in the enclosing
	// method (pros and cons)
	//
	// local methods can exist in many function kinds (e.g., accessors, ctors, other local methods,
	// lambda expressions w/ statement blocks)
	public void WriteCubes(int offset)
	{
		Console.WriteLine(Cube(3));
		Console.WriteLine(Cube(4));
		Console.WriteLine(Cube(5));
		
		int Cube(int value) => value * value * value + offset;	// references local offset param
	}
	
	// STATIC LOCAL METHODS
	//
	// from c#8 you can now mark local methods as static to prevent them from seeing the local
	// variables and params of the enclosing type
	public void WriteCubesStatic(int offset)
	{
		Console.WriteLine(Cube(3));
		Console.WriteLine(Cube(4));
		Console.WriteLine(Cube(5));
		
		static int Cube(int value) => value * value * value; // now unable to access offset param
	}
	
	// TOP-LEVEL STATEMENTS
	//
	// any methods declared in top-level statements are treated as local methods; this means that
	// they can access local variables unless marked static
	
	// OVERLOADING
	//
	// basic stuff, signature must differ, signature does not include the return type
	//
	// interestingly, whether a param is pass-by-ref or pass-by-value IS part of the signature;
	// so you can have a pass by value instance (default) AND a pass by reference instance (out/ref);
	// however, you can't have both a ref and an out, since they are both pass by reference
	//
	// also, params is NOT part of the signature, so you can't have a method taking an (int[])
	// overloaded with a method taking (params int[])
	
	void MyFoo(int x) => Console.WriteLine();
	void MyFoo(ref int x) => Console.WriteLine();
	// void MyFoo(out int x) => Console.WriteLine();	// compile-time error
}