<Query Kind="Statements" />


// GENERAL STRUCT INFO
//
// structs are similar to classes except that structs are value types, and that structs don't support
// inheritance (excpet for being derived from System.ValueType
//
// structs don't support finalizers, or members being marked virtual, abstract, or protected (since
// inheritance isn't supported)
//
// structs are useful e.g. when you want assignment to copy the values of type then the type reference
// as with classes; also helps save space on the heap
//
// note that structs variables cannot be null, the default struct value is a struct with all its
// members set to their default values


// STRUCT CONSTRUCTION
//
// structs always have a default parameterless ctor that performs a bitwise zeroing of all fields in
// the struct; even if you create your own parameterless ctor, the implicit ctor still exists an can
// be accessed via 'default'
//
// note that the implicit ctor will bypass ALL other initialization, including field initializations;
// this can be confusing, probably best to keep structs simple and just not have field initializers or
// parameterless ctors at all
//
// you can design your structs so that their default value gets updated to a valid state, removing the
// need to have field initializations at all


Point p1 = new Point();		// calls my parameterless ctor; x and y are 1
Point p2 = default;			// calls implicit ctor; both x and y are 0 

Console.WriteLine(p1);
Console.WriteLine(p2);

struct Point
{
	int x = 1;						// note that before c#10 you couldn't define field initializers
	int y;
	string name;

	public string Name				// will still have a valid value even if the default ctor is used
	{
		get => name == default ? "none" : name;
		set => name = value;
	}
	
	public Point() => y = 1;		// also couldn't have your own parameterless ctor before c#10
	
	public override string ToString() => $"{x}, {y}";
}