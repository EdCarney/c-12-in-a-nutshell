<Query Kind="Statements" />


// INHERITANCE W/ PRIMARY CTORS
//
// recall primary ctors define the variables for a type in the class definition and expose them for
// use in the class, also replacing the default empty ctor with a primary one
//
// inheritance can be done with these classes via a colon (:) syntax with at the end of the primary
// ctor parameter list, similar to a subclass ctor calling a base class ctor

var b = new Base(1);

public class Base(int x)
{
	public int X => x;
}

public class Sub(int x, int y) : Base(x)
{
	public int Y => y;
}