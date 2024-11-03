<Query Kind="Statements" />



// CTOR and FIELD INITIALIZATION ORDER
//
//	- subclass -> baseclass
//		- fields initialized
//		- base class ctor params evaluated
//	- baseclass -> subclass
//		- ctor bodies executed

public class B
{
	int x = 1;				// third
	public B(int x)
	{
							// fourth
	}
}

public class D : B
{
	int y = 1;				// first
	public D(int x)
		: base(x + 1)		// second
	{
							// fifth
	}
}